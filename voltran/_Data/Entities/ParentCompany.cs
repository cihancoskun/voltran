using System.Collections.Generic;

namespace Voltran.Web.Data.Entities
{
    public class ParentCompany : BaseEntity
    {
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string Address { get; set; }
          
        public virtual ICollection<Company> Companies { get; set; }  

    }
}