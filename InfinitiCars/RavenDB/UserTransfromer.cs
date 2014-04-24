using Core.Domain;
using Raven.Client.Indexes;
using System.Linq;

namespace InfinitiCars.RavenDB
{
    /// <summary>
    /// http://ayende.com/blog/161346/robs-sprint-result-transformers
    /// </summary>
    public class UserTransfromer : AbstractTransformerCreationTask<User>
    {
        public UserTransfromer()
        {
            TransformResults = users =>
                               from user in users
                               select new
                               {
                                   user.Name,
                                   PrefferedMakes = LoadDocument<Make>(user.PrefferedManufacturers.Select(x => x.Id.ToString()))
                               };
        }
    }
}