using Core.Domain;
using Raven.Client.Indexes;
using System.Linq;

namespace InfinitiCars.RavenDB
{
    /// <summary>
    /// http://stackoverflow.com/questions/4253334/ravendb-map-reduce-example-using-net-client
    /// In current domain case : foreach user, how many preffered models he has
    /// </summary>
    public class UniqueVisitorsResult
    {
        public string UserId { get; set; }

        public int PrefferedModelsCount { get; set; }
    }

    public class UserPrefferedModelsIndex : AbstractIndexCreationTask<User, UniqueVisitorsResult>
    {
        public UserPrefferedModelsIndex()
        {
            Map = users => from user in users
                           select new
                           {
                               UserId = user.Id,
                               PrefferedModelsCount = user.PrefferedManufacturers.Count(),
                           };

            Reduce = results => from result in results
                                group result by result.PrefferedModelsCount into g
                                select new
                                {
                                    UserId = g.Key,
                                    PrefferedModelsCount = g.Sum(x => x.PrefferedModelsCount),
                                };
        }
    }
}