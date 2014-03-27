using System.Linq;
using Voltran.Web.Data.Entities;
using Voltran.Web.Models;
using Voltran.Web.Services;
using System.Threading.Tasks;
using System.Web.Mvc;
using Voltran.Web.Helpers;

namespace Voltran.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    { 
        private readonly IFeedbackService _feedbackService;
        private readonly ICityService _cityService;
        

        public HomeController( 
             IFeedbackService feedbackService,
             ICityService cityService)
        { 
            _feedbackService = feedbackService;
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<ViewResult> Index()
        {
            var listEntity = await _cityService.GetCities();

            var listModel = listEntity.Select(CityModel.Map).ToList();

            return View(listModel);
        }
         
        [HttpGet]
        public ViewResult Error()
        {
            return View();
        }
    }
}