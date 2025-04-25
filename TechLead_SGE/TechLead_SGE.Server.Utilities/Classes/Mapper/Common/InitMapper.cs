using Microsoft.Extensions.DependencyInjection;

namespace TechLead_SGE.Server.Utilities.Classes.Mapper.Common
{
    /// <summary>
    /// Clase para la configuración inicial del Mapper.
    /// </summary>
    public static class InitMapper
    {
        /// <summary>
        /// Método para inicializar el swagger con ciertos párametros.
        /// </summary>
        /// <param name="Services">Objeto de tipo IServiceCollection.</param>
        /// <param name="TypeMapper">Objeto de tipo Type.</param>
        /// <returns>Objeto de tipo IServiceCollection.</returns>
        public static IServiceCollection ConfigureMapper(this IServiceCollection Services, Type TypeMapper)
        {
            Services.AddAutoMapper(TypeMapper);
            return Services;
        }
    }
}