using TalaTask.API.src.Infraestrutura.Repositorios.Impl.Memory;
using TalaTask.API.src.Infraestrutura.Repositorios.Interfaces;
using TalaTask.API.src.Negocio;

namespace TalaTask.API.src.Utils
{
    public static class Dependencias
    {
        public static IServiceCollection RegistraDependencias(this IServiceCollection services)
        {
            services.AddSingleton<IEmpleadoRepository, EmpleadoRepository>();
            services.AddSingleton<ITareaRepository, TareaRepository>();
            services.AddSingleton<IAsignacionRepository, AsignacionRepository>();


            services.AddTransient<EmpleadoServices>();
            services.AddTransient<TareaServices>();
            services.AddTransient<AsignacionesServices>();
            services.AddTransient<ReportesServices>();
            return services;
        }
    }
}