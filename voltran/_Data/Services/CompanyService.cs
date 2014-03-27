using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voltran.Web.Data.Entities;
using Voltran.Web.Models;

namespace Voltran.Web.Services
{
    public class CompanyService : BaseService, ICompanyService
    {
        public Task<Company> GetCompany(long id)
        {
            if (id < 1) return null;

            var query = Context.Companies.Where(x => !x.IsDeleted
                                                        && x.Id == id
                                                        && x.IsActive);
            var result = query.FirstOrDefault();

            return Task.FromResult(result);
        }

        public Task<List<Company>> GetCompanies(long districtId)
        { 
            if (districtId < 1) return null;
            
            var query = Context.Companies.Where(x => !x.IsDeleted
                                                        && x.DistrictId == districtId
                                                        && x.IsActive);

            var result = query.OrderBy(x => x.Id).ToList();

            return Task.FromResult(result);
        }

        public Task<bool> CreateCompany(CompanyModel model)
        {
            throw new System.NotImplementedException();
        } 
    }
     
    public interface ICompanyService
    {
        Task<Company> GetCompany(long id);
        Task<List<Company>> GetCompanies(long districtId);
        Task<bool> CreateCompany(CompanyModel model);
    }
}