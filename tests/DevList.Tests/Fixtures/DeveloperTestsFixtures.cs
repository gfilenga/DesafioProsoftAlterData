using DevList.Domain.Models;
using DnsClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DevList.Tests.Fixtures
{
    [CollectionDefinition(nameof(DeveloperCollection))]
    public class DeveloperCollection : ICollectionFixture<DeveloperTestsFixtures>
    { }
    public class DeveloperTestsFixtures : IDisposable
    {
        public Developer GenerateValidDeveloper()
        {
            return new Developer()
            {
                Avatar = "https:cloudflare.com.br/fake.jpg",
                Email = "guilherme.filenga@prosoft.com.br",
                Linguagem = "c#",
                Login = "guilha22",
                Name = "Guilherme Filenga",
                Squad = "onboarding"
            };
        }

        public void Dispose()
        {
        }
    }
}
