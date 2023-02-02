using KostaTestTask.Interfaces;
using KostaTestTask.Managers.DBManager;
using KostaTestTask.Options;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace KostaTestTask.Extensions
{
    public static class DBExtension
    {
        public static IServiceCollection AddDBServices(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeManager, DBEmployeeManager>();
            services.AddTransient<IDepartmentManager, DBDepartmentManager>();
            services.AddTransient<IDBExecuter, DBExecuter>();
            services.AddTransient<SqlConnection>(serviceProvider => {
                IOptions<DBOptions> options = serviceProvider.GetRequiredService<IOptions<DBOptions>>();
                var databaseOptions = options.Value;
                var cnn = new SqlConnection(databaseOptions.ConnectSettings);
                return cnn;
            });
            return services;
        }
    }
}
