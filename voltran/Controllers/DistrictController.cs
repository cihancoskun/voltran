using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Voltran.Web.Helpers;
using Voltran.Web.Models;
using Voltran.Web.Services;

namespace Voltran.Web.Controllers
{
    [AllowAnonymous]
    public class DistrictController : BaseController
    {
        private readonly IFeedbackService _feedbackService;
        private readonly ICityService _cityService;
        private readonly ICompanyService _companyService;


        public DistrictController(
            IFeedbackService feedbackService,
            ICityService cityService,
            ICompanyService companyService)
        {
            _feedbackService = feedbackService;
            _cityService = cityService;
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult> Companies(string id)
        {
            long districtId;

            if (!long.TryParse(id, out districtId)) return RedirectToHome();

            var listEntity = await _companyService.GetCompanies(districtId);

            var listModel = listEntity.Select(CompanyModel.Map).ToList();

            return View(listModel);
        }

        [HttpGet]
        public async Task<ActionResult> Boxes(string id)
        {
            long districtId;

            if (!long.TryParse(id, out districtId)) return RedirectToHome();

            var listEntity = await _companyService.GetCompanies(districtId);
              
            var listModel = listEntity.Select(BoxModel.Map).ToList();
             
            return View(listModel);
        }
    }
}