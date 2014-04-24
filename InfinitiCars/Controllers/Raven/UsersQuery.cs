using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain;
using Raven.Client;

namespace InfinitiCars.Controllers.Raven
{
    /// <summary>
    /// http://www.wekeroad.com/2014/03/04/repositories-and-unitofwork-are-not-a-good-idea/
    /// </summary>
    public class UsersQuery
    {
        private readonly IDocumentSession documentSession;

        public UsersQuery(IDocumentSession documentSession)
        {
            this.documentSession = documentSession;
        }

        public IEnumerable<Make> Execute(Guid id)
        {
            var user = documentSession.Load<User>(id);

            if (user == null)
            {
                return Enumerable.Empty<Make>();
            }

            // all the makes
            var userPreffered = new List<Guid>();

            if (user.PrefferedManufacturers != null)
            {
                // all the preffered for this user
                userPreffered = user.PrefferedManufacturers.Select(x => x.Id).ToList();
            }

            if (!userPreffered.Any())
            {
                return documentSession.Query<Make>();
            }

            var prefferedMakes = new List<Make>();

            // DO NOT CONVERT
            foreach (var item in documentSession.Query<Make>())
            {
                if (!userPreffered.Contains(item.Id))
                {
                    prefferedMakes.Add(item);
                }
            }

            return prefferedMakes;
        }
    }
}