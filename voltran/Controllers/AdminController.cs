using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Voltran.Web.Models;
using Voltran.Web.Services;

namespace Voltran.Web.Controllers
{
    [AllowAnonymous]
    public class AdminController : BaseController
    {
        private readonly IFeedbackService _feedbackService;
        private readonly ICityService _cityService;
        private readonly IDistrictService _districtService;


        public AdminController(
            IFeedbackService feedbackService,
            ICityService cityService,
            IDistrictService districtService)
        {
            _feedbackService = feedbackService;
            _cityService = cityService;
            _districtService = districtService;
        }

    }
}