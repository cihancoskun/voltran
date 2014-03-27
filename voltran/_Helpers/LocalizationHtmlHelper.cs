using System.Collections.Generic;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Voltran.Web.Helpers
{
    public static class LocalizationHtmlHelper
    {
        public static string LocalizationString(this HtmlHelper helper, string key)
        {
            try
            {
                return ((Dictionary<string, string>)HttpContext.Current.Application[Thread.CurrentThread.CurrentUICulture.Name])[key];
            }
            catch { return key; }
        }
    }
}