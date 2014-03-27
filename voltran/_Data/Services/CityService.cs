using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voltran.Web.Data.Entities;
using Voltran.Web.Models;

namespace Voltran.Web.Services
{
    public class CityService : BaseService, ICityService
    {
        public Task<List<City>> GetCities()
        {
            var query = Context.Cities.Where(x => !x.IsDeleted
                                                        && x.IsActive);

            var result = query.OrderBy(x => x.Id).ToList();

            return Task.FromResult(result);
        }
         
        public Task<bool> CreateCity(CityModel model)
        {
            throw new System.NotImplementedException();
        } 
    }

    public interface ICityService
    {
        Task<List<City>> GetCities(); 
        Task<bool> CreateCity(CityModel model);
    }
}