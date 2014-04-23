using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voltran.Web.Data.Entities;
using Voltran.Web.Models;

namespace Voltran.Web.Services
{
    public class DistrictService :  BaseService, IDistrictService
    {
        public Task<List<District>> GetDistricts(long cityId)
        {
            if (cityId < 1) return null;

            var query = Context.Districts.Where(x => !x.IsDeleted
                                                        && x.CityId == cityId 
                                                        && x.IsActive);

            var result = query.OrderBy(x => x.Id).ToList();

            return Task.FromResult(result);
        }

        public Task<bool> CreateDistrict(DistrictModel model)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IDistrictService
    {
        Task<bool> CreateDistrict(DistrictModel model);
        Task<List<District>> GetDistricts(long cityId);
    }

}