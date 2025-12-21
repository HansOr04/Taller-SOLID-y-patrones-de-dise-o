using Best_Practices.Infraestructure.Factories;
using Best_Practices.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Best_Practices.Infraestructure.DependencyInjection
{
    public class ServicesConfiguration
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Repository como Singleton para simular persistencia en memoria
            // Cuando la base de datos esté lista, cambiar a Scoped con DBVehicleRepository
            services.AddSingleton<IVehicleRepository, InMemoryVehicleRepository>();
            
            // Registrar todas las factories como Transient
            services.AddTransient<IVehicleFactory, FordMustangFactory>();
            services.AddTransient<IVehicleFactory, FordExplorerFactory>();
            services.AddTransient<IVehicleFactory, FordEscapeFactory>();
        }
    }
}
