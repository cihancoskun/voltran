using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Voltran.Web.Models;
using Voltran.Web.Services;

namespace Voltran.Web.Controllers
{
    [AllowAnonymous]
    public class CompanyController : BaseController
    {
        private readonly IFeedbackService _feedbackService;
        private readonly ICompanyService _companyService;
        private readonly IImageService _imageService;


        public CompanyController(
            IFeedbackService feedbackService,
            ICompanyService companyService,
            IImageService imageService)
        {
            _feedbackService = feedbackService;
            _companyService = companyService;
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<ActionResult> Detail(string id)
        {
            long companyId;

            if (!long.TryParse(id, out companyId)) return RedirectToHome();

            var entity = await _companyService.GetCompany(companyId);

            var model = CompanyModel.Map(entity);

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Page(string id)
        {
            long companyId;

            if (!long.TryParse(id, out companyId)) return RedirectToHome();

            var companyEntity = await _companyService.GetCompany(companyId);

            var imageEntity = await _imageService.GetImagesOfCompany(companyId);

            var model = CompanyPageModel.Map(companyEntity, imageEntity);

            return View(model);
        }
    }
}