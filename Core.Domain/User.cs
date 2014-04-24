using System.Collections.Generic;

namespace Core.Domain
{
    public class User : BaseEntity
    {
        public User()
        {
            PrefferedManufacturers = new List<Make>();
        }

        public string Name { get; set; }

        public IEnumerable<Make> PrefferedManufacturers { get; set; }

        /// <summary>
        /// Used only to see how to rename property
        /// </summary>
        public string Description { get; set; }
    }
}