using DevList.Domain.Interfaces;
using DevList.Domain.Models;
using DevList.Domain.Services;
using DevList.Infra.Interfaces;
using DevList.Infra.Repositories;
using DevList.Tests.Fixtures;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevList.Tests.Services
{
    [Collection(nameof(DeveloperCollection))]
    public class DeveloperServiceTests
    {
        private readonly DeveloperTestsFixtures _devFixture;

        public DeveloperServiceTests(DeveloperTestsFixtures devFixture)
        {
            _devFixture = devFixture;
        }

        [Fact]
        public void DeveloperService_Insert_ShouldInsertValidDeveloper()
        {
            // Arrange
            var developer = _devFixture.GenerateValidDeveloper();
            var developerRepo = new Mock<IRepository<Developer>>();

            var developerService = new DeveloperService(developerRepo.Object);

            // Act
            developerService.Insert(developer);

            // Assert
            developerRepo.Verify(r => r.Insert(developer), Times.Once);
        }
    }
}
