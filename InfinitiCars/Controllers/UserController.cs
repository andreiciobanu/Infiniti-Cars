using System;
using System.Linq;
using System.Web.Http;
using Core.Domain;
using InfinitiCars.Controllers.Raven;

namespace InfinitiCars.Controllers
{
    public class UserController : RavenAPIController
    {
        public IHttpActionResult Get()
        {
            return Ok(Session.Query<User>().ToList());
        }

        public IHttpActionResult Get(Guid id)
        {
            return Ok(Session.Load<User>(id));
        }

        public IHttpActionResult Post(User viewModel)
        {
            Session.Store(viewModel);
            Session.SaveChanges();

            return Created(Url.Link("DefaultApi", new { controller = "User", id = viewModel.Id }), viewModel);
            //return InternalServerError();
        }

        public IHttpActionResult Put(Guid id, User locationViewModel)
        {
            Session.Store(locationViewModel);
            Session.SaveChanges();

            return Ok(locationViewModel);
            //return InternalServerError();
        }

        public IHttpActionResult Delete(Guid id)
        {
            var todelete = Session.Load<User>(id);
            Session.Delete(todelete);
            Session.SaveChanges();

            return Ok();
        }
    }
}