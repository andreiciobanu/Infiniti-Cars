using System.Linq;
using Core.Domain;
using Raven.Client.Listeners;
using Raven.Json.Linq;

namespace InfinitiCars.RavenDB
{
    /// <summary>
    /// http://ayende.com/blog/66562/ravendb-migrations-when-to-execute
    /// </summary>
    public class UserVersion1ToVersion2Converter : IDocumentConversionListener
    {
        public void DocumentToEntity(string key, object entity, RavenJObject document, RavenJObject metadata)
        {
            var c = entity as User;

            if (c == null)
            {
                return;
            }

            if (metadata.Value<int>("Customer-Schema-Version") >= 2)
            {
                return;
            }

            c.Description = document.Value<string>("DescriptionUpdated").Split().First();
        }

        public void EntityToDocument(string key, object entity, RavenJObject document, RavenJObject metadata)
        {
            var c = entity as User;

            if (c == null)
            {
                return;
            }

            metadata["Customer-Schema-Version"] = 2;

            document["DescriptionUpdated"] = c.Description;
        }
    }
}