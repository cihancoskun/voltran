using System.Threading.Tasks;
using System.Web.Mvc;
using Voltran.Web.Models;
using Voltran.Web.Services;

namespace Voltran.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public UserController(
            IAuthService authService,
            IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpGet, AllowAnonymous]
        public ActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<ActionResult> Login(LoginModel model)
        { 
            if (!model.IsValid())
            {
                SetPleaseTryAgain(model); 
                return View(model);
            }

            var authenticated = await _userService.Authenticate(model.Email, model.Password);
            if (!authenticated) return View(model);

            var user = await _userService.GetByEmail(model.Email);
            _authService.SignIn(user.Id,user.Name,user.Email,user.RoleName,true);

            return Redirect(!string.IsNullOrEmpty(model.ReturnUrl) ? model.ReturnUrl : "/"); 
        }

        [HttpGet, AllowAnonymous]
        public ActionResult Logout()
        {
            _authService.SignOut();
            return RedirectToHome();
        } 
    }
}