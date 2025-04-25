using Microsoft.Extensions.Configuration;
using TechLead_SGE.Server.Domain.DTOS.Config;

namespace TechLead_SGE.Server.BL.Services.Interfaces
{
    /// <summary>
    /// Interface de tipo Service que implementa varias propiedades y/o métodos que permite realizar múltiples funciones.
    /// </summary>
    public interface IValoresGlobalesService
    {
        /// <summary>
        /// Método que permite obtener todos los valores de configuración a partir de ciertos parámetros.
        /// </summary>
        /// <param name="configuration">Objeto de Tipo IConfiguration que permite reconocer ciertas propiedaes del IConfiguration.</param>
        /// <returns>Objeto de tipo ConfigDto.</returns>
        public ConfigDto GetConfigutation(IConfiguration configuration);
    }
}