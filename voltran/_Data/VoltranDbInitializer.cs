using System.Data.Entity;

namespace Voltran.Web.Services.Data
{
    public class VoltranDbInitializer : MigrateDatabaseToLatestVersion<VoltranDbContext, VoltranDbMigrationConfiguration>
    {

    }
}