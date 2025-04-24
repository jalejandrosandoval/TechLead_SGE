using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechLead_SGE.Server.BL.Classes.Config;

namespace TechLead_SGE.Server.Data.DBContext.Common
{
    /// <summary>
    /// Clase de Inicialización del DbContext.
    /// </summary>
    public static class InitDBContext
    {
        /// <summary>
        /// Método que permite realizar la configuración del DBContext.
        /// </summary>
        /// <param name="Services">Objeto de tipo IServiceCollection.</param>
        /// <param name="Configuration">Objeto de tipo IConfiguration.</param>
        /// <returns>Objeto de tipo IServiceCollection.</returns>
        public static IServiceCollection ConfigureDbContextApi(this IServiceCollection Services, IConfiguration Configuration)
        {
            Services.AddDbContext<AppDbContext>(
                options =>
                {
                    options.UseSqlServer(new InitConfig(Configuration).ConfigurationsDto.CNX_BD);
                }
            );

            return Services;
        }
    }
}