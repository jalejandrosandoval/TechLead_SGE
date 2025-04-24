using TechLead_SGE.Server.BL.DTOS.Config;
using TechLead_SGE.Server.BL.Repositories.Implements;
using TechLead_SGE.Server.BL.Services.Implements;
using TechLead_SGE.Server.Classes.Controllers.Common;

namespace TechLead_SGE.Server.Classes.Config
{
    /// <summary>
    /// Clase que permite inicializar la configuración Inicial de la aplicación.
    /// </summary>
    internal class InitConfig
    {
        /// <summary>
        /// Servicio de tipo DataService que permite interactuar con ciertos métodos de este.
        /// </summary>
        internal readonly DataService dataService = new(new DataRepository());

        /// <summary>
        /// Servicio de tipo ValoresGlobalesService que permite interactuar con ciertos métodos de este.
        /// </summary>
        private readonly ValoresGlobalesService valoresGlobalesService = new(new ValoresGlobalesRepository());

        /// <summary>
        /// Objeto de tipo ConfigDto.
        /// </summary>
        internal ConfigDto ConfigurationsDto { get; set; } = new();

        /// <summary>
        /// Objeto de tipo ValidationsController.
        /// </summary>
        internal ValidationsInControllers Validations { get; set; } = new();

        /// <summary>
        /// Constructor de la Clase con Parámetros.
        /// </summary>
        /// <param name="IConfig">Objeto de Tipo IConfiguration que permite reconocer ciertas propiedaes del IConfiguration.</param>
        public InitConfig(IConfiguration? IConfig = null)
        {
            if (IConfig != null)
                ConfigurationsDto = valoresGlobalesService.GetConfigutation(IConfig);
        }
    }
}