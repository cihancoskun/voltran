using System.Security.Principal;

namespace Voltran.Web.Helpers
{
    public static class IdentityHelper
    {
        public static string GetId(this IIdentity identity)
        {
            return identity.IsAuthenticated ? identity.Name.Split('|')[0] : string.Empty;
        }

        public static string GetFullName(this IIdentity identity)
        {
            return identity.IsAuthenticated ? identity.Name.Split('|')[1] : string.Empty;
        }

        public static string GetEmail(this IIdentity identity)
        {
            return identity.IsAuthenticated ? identity.Name.Split('|')[2] : string.Empty;
        }

        public static string GetRoleName(this IIdentity identity)
        {
            return identity.IsAuthenticated ? identity.Name.Split('|')[3] : string.Empty;
        }
    }
}