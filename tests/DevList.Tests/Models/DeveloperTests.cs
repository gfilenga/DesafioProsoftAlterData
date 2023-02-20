using DevList.Domain.Models;
using FluentAssertions;

namespace DevList.Tests.Models
{
    public class DeveloperTests
    {
        [Fact]
        public void Developer_UpdateModel_ShouldUpdateTimerField()
        {
            // Arrange
            var developer = new Developer()
            {
                Avatar = "https:cloudflare.com.br/fake.jpg",
                Email = "guilherme.filenga@prosoft.com.br",
                Linguagem = "c#",
                Login = "guilha22",
                Name = "Guilherme Filenga",
                Squad = "onboarding"
            };

            // Act
            developer.UpdateModel();

            // Assert
            developer.UpdatedAt.Should().BeAfter(developer.CreatedAt);
        }
    }
}