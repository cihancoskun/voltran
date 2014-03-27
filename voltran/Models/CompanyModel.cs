using Voltran.Web.Data.Entities;

namespace Voltran.Web.Models
{
    public class CompanyModel : BaseModel
    {
        public long Id { get; set; }
        public string Name { get; set; } 
        public string Address { get; set; }
        public string LogoUrl { get; set; } 
        public bool IsActive { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Name)
                   && !string.IsNullOrEmpty(Address)
                   && IsActive;
        }

        public static CompanyModel Map(Company company)
        {
            var model = new CompanyModel
            {
                Id = company.Id,
                Name = company.Name, 
                Address = company.Address,
                LogoUrl = company.LogoUrl, 
                IsActive = company.IsActive
            };
            return model;
        }
    }
}