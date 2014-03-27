using System.Web.Security;

namespace Voltran.Web.Services
{ 
    public class AuthService : IAuthService
    {
        public void SignIn(long id, string name, string email, string roleName, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(string.Format("{0}|{1}|{2}|{3}", id, name, email, roleName), createPersistentCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
    public interface IAuthService
    {
        void SignIn(long id, string name, string email, string roleName, bool createPersistentCookie);

        void SignOut();
    }
}