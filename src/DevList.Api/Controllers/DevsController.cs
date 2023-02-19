using DevList.Api.Messaging;
using DevList.Domain.Interfaces;
using DevList.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevsController : ControllerBase
    {
        private readonly ILogger<DevsController> _logger;
        private readonly IDeveloperService _developerService;
        private readonly IServiceBusProducer _serviceBusProducer;

        public DevsController(ILogger<DevsController> logger, IDeveloperService developerService, IServiceBusProducer serviceBusProducer)
        {
            _logger = logger;
            _developerService = developerService;
            _serviceBusProducer = serviceBusProducer;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Developer>> GetAll()
        {
            try
            {
                var result = _developerService.QueryAll();

                return Ok(result.ToList());
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Developer> Get([FromRoute] Guid id)
        {
            try
            {
                var result = _developerService.Query(id);

                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, id);
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Developer>> InsertAsync([FromBody] Developer developer)
        {
            try
            {
                _developerService.Insert(developer);

                await _serviceBusProducer.SendMessageAsync(new Message
                {
                    Action = "POST",
                    Developer = developer
                });

                return Ok(developer);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, developer);
                return new StatusCodeResult(500);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Developer>> UpdateAsync([FromBody] Developer developer)
        {
            try
            {
                _developerService.Update(developer);
                
                await _serviceBusProducer.SendMessageAsync(new Message
                {
                    Action = "PUT",
                    Developer = developer
                });

                return Ok(developer);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, developer);
                return new StatusCodeResult(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
        {
            try
            {
                _developerService.Delete(id);

                await _serviceBusProducer.SendMessageAsync(new Message
                {
                    Action = "DELETE",
                    Developer = new Developer { Id = id } 
                });

                return Ok(id);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, id);
                return new StatusCodeResult(500);
            }
        }

    }
}
