using System.Collections.Generic;

namespace Core.Domain
{
    public class Make : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<Model> Models { get; set; }
    }
}