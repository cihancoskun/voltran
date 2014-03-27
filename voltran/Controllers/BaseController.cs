using System.Threading;
using System.Web.Mvc;

using Voltran.Web.Helpers;
using Voltran.Web.Models;

namespace Voltran.Web.Controllers
{
    public class BaseController : Controller
    {
        public HtmlHelper _htmlHelper;
       

        public BaseController()
        {
            _htmlHelper = new HtmlHelper(new ViewContext(), new ViewPage());
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            SetLanguage();

            base.OnActionExecuting(filterContext);
        }

        public void SetLanguage()
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = ConstHelper.CultureTR;
                Thread.CurrentThread.CurrentUICulture = ConstHelper.CultureTR;

                var langCookie = Request.Cookies[ConstHelper.__Lang];
                if (langCookie == null) return;

                var lang = langCookie.Value;
                if (lang != ConstHelper.en) return;

                Thread.CurrentThread.CurrentCulture = ConstHelper.CultureEN;
                Thread.CurrentThread.CurrentUICulture = ConstHelper.CultureEN; 

            }
            catch { }
        }

        public RedirectResult RedirectToHome()
        {
            return Redirect("/");
        }

        public void SetPleaseTryAgain(BaseModel model)
        {
            model.Msg = _htmlHelper.LocalizationString("please_check_the_fields_and_try_again");
        }
    }
}