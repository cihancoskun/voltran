using System.Collections.Generic;

namespace Voltran.Web.Data.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public string LicensePlate { get; set; } 

        public virtual ICollection<District> Districts { get; set; }
    }
}