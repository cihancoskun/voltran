using Voltran.Web.Data.Entities;

namespace Voltran.Web.Models
{
    public class CityModel : BaseModel
    {
        public long Id { get; set; }
        public string Name { get; set; } 
        public string LicensePlate{ get; set; }
        public bool IsActive { get; set; }
        
        public bool IsValid()
        {
            return !string.IsNullOrEmpty(LicensePlate)
                   && (LicensePlate.Contains("34")
                       || LicensePlate.Contains("35")
                       || LicensePlate.Contains("06"))
                   && IsActive;
        }

        public static CityModel Map(City city)
        {
            var model = new CityModel
            {
                Id = city.Id,
                Name = city.Name,
                LicensePlate = city.LicensePlate
            }; 
            return model;
        }
    }
}