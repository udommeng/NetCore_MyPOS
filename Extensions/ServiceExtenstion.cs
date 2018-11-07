using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyPOS.Database;

namespace MyPOS.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureDatabase(this IServiceCollection Services, IConfiguration Config)
        {
            Services.AddDbContext<DatabaseContext>(options =>
                 options.UseSqlServer(Config.GetConnectionString("DefaultConnection_sql_server")));

            // Services.AddDbContext<DatabaseContext>(options =>
            //     options.UseMySql(Config.GetConnectionString("DefaultConnection_my_sql")));

            // Services.AddDbContext<DatabaseContext>(options =>
            //    options.UseSqlite(Config.GetConnectionString("DefaultConnection_sqlite")));

            // Create Database when Database not found
            var serviceProvider = Services.BuildServiceProvider();
            DBinitialize.INIT(serviceProvider);
        }
    }
}