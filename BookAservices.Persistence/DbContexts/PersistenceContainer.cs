using BookAservices.Application.Contract;
using BookAservices.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookAservices.Persistence.DbContexts
{
    public static class PersistenceContainer
    {
        public static IServiceCollection AddPersistenceContainer(this IServiceCollection services,IConfiguration configuration) 
        {
            services.AddDbContext<ServicesDbContext>(Options =>
            {
                Options.UseSqlServer(configuration.GetConnectionString("SqlCon"));
            });
            services.AddScoped(typeof(IGenricInterface<>), typeof(IGenricRepository<>));
            services.AddScoped(typeof(IInterfaceServices), typeof(IServicesRepository));
            services.AddScoped(typeof(IInterfaceDifferenceData), typeof(IDifferenceDataRepository));
            services.AddScoped(typeof(IInterfaceDifferences), typeof(IDifferencesRepository));
            services.AddScoped(typeof(IInterfaceOptionsDifference), typeof(IOptionsDifferenceRepository));
            services.AddScoped(typeof(IInterfaceOrder), typeof(IOrderRepository));
            services.AddScoped(typeof(IInterfaceOrderDetails), typeof(IOrderDetailsRepository));
            services.AddScoped(typeof(IInterfaceServiceRequest), typeof(IServiceRequestRepository));
            services.AddScoped(typeof(IInterfaceOptionsDifferenceData), typeof(IOptionsDifferenceDataRepository));






            return services;
        }
    }
}
