using Core.Domain;
using InfinitiCars.Controllers.Raven;
using Raven.Client;
using Raven.Client.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace InfinitiCars.Controllers
{
    public class SampleController : RavenDbController
    {
        public Task<IList<string>> GetDocs()
        {
            return Session.Query<User>().Select(data => data.Name).ToListAsync();
        }

        public async Task<HttpResponseMessage> Put([FromBody]string value)
        {
            await Session.StoreAsync(new User
                {
                    Name = value
                });

            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}