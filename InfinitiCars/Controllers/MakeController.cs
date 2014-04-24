using Core.Domain;
using InfinitiCars.Controllers.Raven;
using System;
using System.Linq;
using System.Web.Http;

namespace InfinitiCars.Controllers
{
    public class MakeController : RavenAPIController
    {
        public IHttpActionResult Get()
        {
            return Ok(Session.Query<Make>().ToList());
        }

        public IHttpActionResult Get(Guid id)
        {
            return Ok(Session.Load<Make>(id));
        }

        public IHttpActionResult Post(Make viewModel)
        {
            Session.Store(viewModel);
            Session.SaveChanges();

            return Created(Url.Link("DefaultApi", new { controller = "Make", id = viewModel.Id }), viewModel);
        }

        public IHttpActionResult GetModelsForMake(Guid id)
        {
            return Ok(Session.Load<Make>(id).Models);
        }

        public IHttpActionResult GetPrefferedModelsByUser(Guid id)
        {
            var user = Session.Load<User>(id);

            if (user != null)
            {
                if (user.PrefferedManufacturers != null)
                {
                    return Ok(user.PrefferedManufacturers);
                }
            }

            return Ok(Enumerable.Empty<Make>());
        }

        public IHttpActionResult GetNonPrefferedMakesByUser(Guid id)
        {
            var query = new UsersQuery(Session);

            return Ok(query.Execute(id));
        }

        public IHttpActionResult Put(Guid id, Make locationViewModel)
        {
            Session.Store(locationViewModel);

            Session.SaveChanges();

            return Ok(locationViewModel);
        }

        public IHttpActionResult Delete(Guid id)
        {
            var todelete = Session.Load<Make>(id);

            Session.Delete(todelete);

            Session.SaveChanges();

            return Ok();
        }
    }
}