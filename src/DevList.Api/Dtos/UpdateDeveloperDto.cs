using DevList.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace DevList.Api.Dtos
{
    public class UpdateDeveloperDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} só pode ter até {1} caracteres")]
        public string Name { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "O campo {0} só pode ter até {1} caracteres")]
        public string? Avatar { get; set; }
        [StringLength(50, ErrorMessage = "O campo {0} só pode ter até {1} caracteres")]
        public string? Squad { get; set; }
        [StringLength(50, ErrorMessage = "O campo {0} só pode ter até {1} caracteres")]
        public string? Login { get; set; }

        [EmailAddress]
        [StringLength(90, ErrorMessage = "O campo {0} só pode ter até {1} caracteres")]
        public string? Email { get; set; }

        [StringLength(20, ErrorMessage = "O campo {0} só pode ter até {1} caracteres")]
        public string? Linguagem { get; set; }

        public Developer ToDomain(UpdateDeveloperDto dto)
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
}
