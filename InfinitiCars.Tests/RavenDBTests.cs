using System.Collections.Generic;
using System.Linq;
using Core.Domain;
using InfinitiCars.RavenDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Raven.Client.Document;
using Raven.Client.Embedded;
using Raven.Client.Indexes;

namespace InfinitiCars.Tests
{
    [TestClass]
    public class RavenDBTests
    {
        private DocumentStore documentStore;

        [TestInitialize]
        public void Initialize()
        {
            documentStore = new EmbeddableDocumentStore();

            //stackoverflow.com/questions/22096738/nuget-package-ravendb-embedded-unable-to-find-a-version-of-ravendb-database-t
            documentStore.Initialize();

            IndexCreation.CreateIndexes(typeof(UserPrefferedModelsIndex).Assembly, documentStore);
        }

        [TestMethod]
        public void MapReduce()
        {
            using (var session = documentStore.OpenSession())
            {
                var user1 = new User
                    {
                        Description = "test",
                        Name = "tes 1",
                        PrefferedManufacturers = new List<Make>
                            {
                                new Make {Name = "Audi"},
                                 new Make {Name = "Test"}
                            }
                    };

                var user2 = new User
                {
                    Description = "test",
                    Name = "tes 1",
                    PrefferedManufacturers = new List<Make>
                            {
                                new Make {Name = "Mercedes"},
                                new Make {Name = "Lexus"}
                            }
                };

                var user3 = new User
                {
                    Description = "test",
                    Name = "tes 1",
                    PrefferedManufacturers = new List<Make>
                            {
                                new Make {Name = "Mercedes"},
                                new Make {Name = "Lexus"}
                            }
                };

                session.Store(user1);
                session.Store(user2);
                session.Store(user3);
                session.SaveChanges();

                var stored = session.Query<User>().Count();

                Assert.AreEqual(stored, 3);

                var result = session.Query<User, UserPrefferedModelsIndex>();

                var count = result.Count();

                Assert.AreEqual(2, count);
            }
        }

        [TestCleanup]
        public void CleanUp()
        {
            documentStore.Dispose();
        }
    }
}
