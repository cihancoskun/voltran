using Voltran.Web.Helpers;

namespace Voltran.Web.Models
{
    public class LoginModel : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Password)
                   && !string.IsNullOrEmpty(Email)
                   && Email.IsEmail();
        }
    }
}