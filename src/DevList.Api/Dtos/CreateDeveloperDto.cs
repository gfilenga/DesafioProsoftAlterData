using DevList.Domain.Models;

namespace DevList.Api.Dtos
{
    public class CreateDeveloperDto
    {
        public string? Name { get; set; }
        public string? Avatar { get; set; }
        public string? Squad { get; set; }
        public string? Login { get; set; }
        public string? Email { get; set; }
        public string? Linguagem { get; set; }

        public Developer ToDomain(CreateDeveloperDto dto)
        {
            return new Developer 
            { 
                Name = dto.Name, 
                Avatar = dto.Avatar, 
                Squad = dto.Squad, 
                Login = dto.Login, 
                Email = dto.Email, 
                Linguagem = dto.Linguagem 
            };    
        }
    }
}
