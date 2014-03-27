using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Voltran.Web.Models;
using Voltran.Web.Services;

namespace Voltran.Web.Controllers
{
    [AllowAnonymous]
    public class CityController : BaseController
    {
        private readonly IFeedbackService _feedbackService;
        private readonly ICityService _cityService;
        private readonly IDistrictService _districtService;


        public CityController(
            IFeedbackService feedbackService,
            ICityService cityService,
            IDistrictService districtService)
        {
            _feedbackService = feedbackService;
            _cityService = cityService;
            _districtService = districtService;
        }

        [HttpGet]
        public async Task<ActionResult> Districts(string id)
        {
            long cityId;

            if (!long.TryParse(id, out cityId)) return RedirectToHome();

            var listDistrictEntity = await _districtService.GetDistricts(cityId);

            var listDistrictModel = listDistrictEntity.Select(DistrictModel.Map).ToList();

            return View(listDistrictModel);
        } 
    }
}