using System.Collections.Generic;

namespace Voltran.Web.Data.Entities
{
    public class District : BaseEntity
    {
        public string Name { get; set; }

        public string CityLicensePlate { get; set; }

        public long CityId { get; set; }
        public City City { get; set; }

        public virtual ICollection<Company> Companies { get; set; }  
    }
}