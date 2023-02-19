﻿using DevList.Domain.Interfaces;
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

        public DevsController(ILogger<DevsController> logger, IDeveloperService developerService)
        {
            _logger = logger;
            _developerService = developerService;
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
        public ActionResult<Developer> Insert([FromBody] Developer developer)
        {
            try
            {
                _developerService.Insert(developer);

                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, developer);
                return new StatusCodeResult(500);
            }
        }

        [HttpPut]
        public ActionResult<Developer> Update([FromBody] Developer developer)
        {
            try
            {
                _developerService.Update(developer);

                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, developer);
                return new StatusCodeResult(500);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            try
            {
                _developerService.Delete(id);

                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, id);
                return new StatusCodeResult(500);
            }
        }

    }
}