using System.Data.Entity;

using Voltran.Web.Services.Data;

namespace Voltran.Web.Services
{
    public class BaseService
    {
        public readonly VoltranDbContext Context;

        public BaseService(VoltranDbContext context = null)
        {
            if (context == null)
            {
                context = new VoltranDbContext();
            }

            Context = context;
        }
    }
}