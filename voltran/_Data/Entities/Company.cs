using System.Collections.Generic;
namespace Voltran.Web.Data.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string BoxImgUrl { get; set; }
        public int BoxNumber { get; set; }
        public string Address { get; set; }

        public string CityLicensePlate { get; set; }
        public string DistrictName { get; set; }
        public string ParentCompanyName { get; set; }


        public long DistrictId { get; set; }
        public District District { get; set; }

        public long? ParentCompanyId { get; set; }
        public ParentCompany ParentCompany { get; set; }

        public virtual ICollection<ImagesOfCompany> ImagesOfCompany { get; set; }  
    }
}