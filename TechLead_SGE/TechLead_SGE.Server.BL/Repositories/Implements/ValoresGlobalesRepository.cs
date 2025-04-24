using Microsoft.Extensions.Configuration;
using TechLead_SGE.Server.BL.DTOS.Config;
using TechLead_SGE.Server.BL.Repositories.Interfaces;

namespace TechLead_SGE.Server.BL.Repositories.Implements
{
    /// <summary>
    /// Clase de Tipo Repository que implementa o hereda de la clase IValoresGlobalesRepository varias propiedades y/o métodos. 
    /// </summary>
    public class ValoresGlobalesRepository : IValoresGlobalesRepository
    {
        /// <summary>
        /// Método que permite obtener todos los valores de configuración a partir de ciertos parámetros.
        /// </summary>
        /// <param name="configuration">Objeto de Tipo IConfiguration que permite reconocer ciertas propiedaes del IConfiguration.</param>
        /// <returns>Objeto de tipo ConfigDto.</returns>
        public ConfigDto GetConfigutation(IConfiguration configuration)
        {
            ConfigDto configDto = new();

            if(configuration != null)
                configDto = GetConfigDto(configuration);

            return configDto;
        }

        /// <summary>
        /// Método intermedio que permite obtener los valores de configuración a partir de ciertos parámetros.
        /// </summary>
        /// <param name="configuration">Objeto de Tipo IConfiguration que permite reconocer ciertas propiedaes del IConfiguration.</param>
        /// <returns>Objeto de tipo ConfigDto.</returns>
        private static ConfigDto GetConfigDto(IConfiguration configuration)
        {
            ConfigDto configDto = new() {
                CNX_BD = configuration.GetConnectionString("CNX_BD")! ?? string.Empty                
            };

            return configDto;
        }
    }
}