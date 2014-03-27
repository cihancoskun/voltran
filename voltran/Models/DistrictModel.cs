using Voltran.Web.Data.Entities;

namespace Voltran.Web.Models
{
    public class DistrictModel : BaseModel
    {
        public long Id { get; set; }
        public string Name { get; set; } 
        public bool IsActive { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Name)
                && IsActive;
        }

        public static DistrictModel Map(District district)
        {
            var model = new DistrictModel
            {
                Id = district.Id,
                Name = district.Name,
                IsActive = district.IsActive
            };
            return model;
        }
    }
}