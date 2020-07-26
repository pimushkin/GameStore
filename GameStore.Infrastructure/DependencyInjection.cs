using GameStore.Application.Interfaces;
using GameStore.Infrastructure.Persistence.MSSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IUnitOfWork = GameStore.Application.Interfaces.IUnitOfWork;
using UnitOfWork = GameStore.Infrastructure.Persistence.MSSQL.UnitOfWork;

namespace GameStore.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<ApplicationDbContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
