using DevList.Domain.Models;
using DevList.Tests.Fixtures;
using FluentAssertions;

namespace DevList.Tests.Models
{
    [Collection(nameof(DeveloperCollection))]
    public class DeveloperTests
    {
        private readonly DeveloperTestsFixtures _devFixture;

        public DeveloperTests(DeveloperTestsFixtures devFixture)
        {
            _devFixture = devFixture;
        }

        [Fact]
        public void Developer_UpdateModel_ShouldUpdateTimerField()
        {
            // Arrange
            var developer = _devFixture.GenerateValidDeveloper();

            // Act
            developer.UpdateModel();

            // Assert
            developer.UpdatedAt.Should().BeAfter(developer.CreatedAt);
        }
    }
}