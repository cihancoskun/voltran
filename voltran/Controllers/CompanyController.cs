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
        private readonly IQuestionService _questionService;


        public CompanyController(
            IFeedbackService feedbackService,
            ICompanyService companyService,
            IImageService imageService,
             IQuestionService questionService)
        {
            _feedbackService = feedbackService;
            _companyService = companyService;
            _imageService = imageService;
            _questionService = questionService;
        }

        [HttpGet]
        public async Task<ActionResult> Detail(long id)
        {
            if (id < 1) return RedirectToHome();

            var companyId = id;
              
            var entity = await _companyService.GetCompany(companyId);

            var model = CompanyModel.Map(entity);

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Page(long id = 0)
        {
            if (id < 1) return RedirectToHome();

            var companyId = id;
              
            var companyEntity = await _companyService.GetCompany(companyId);

            var questionEntity = await _questionService.GetFirstQuestion(companyId);

            var model = CompanyPageModel.Map(companyEntity, questionEntity);

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken] 
        public async Task<JsonResult> IsAnswerCorrect(long questionId, string answer)
        {
            var result = new ResponseModel { IsOk = false };

            var isOk = await _questionService.IsAnswerCorrect(questionId,answer);
            if (!isOk) return Json(result, JsonRequestBehavior.DenyGet);

            var nextQuestion = await _questionService.GetNextQuestion(questionId);

            result.IsOk = true;
            result.Result = nextQuestion;

            return Json(result, JsonRequestBehavior.DenyGet);
        }
    }
}