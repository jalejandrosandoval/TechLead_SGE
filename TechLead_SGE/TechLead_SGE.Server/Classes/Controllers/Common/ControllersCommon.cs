using Microsoft.AspNetCore.Mvc;
using TechLead_SGE.Server.BL.Classes.Config;

namespace TechLead_SGE.Server.Classes.Controllers.Common
{
    /// <summary>
    /// Clase que permite inicializar la configuración Inicial de los Controladores.
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("")]
    public class ControllersCommon : ControllerBase
    {
        /// <summary>
        /// Objeto de Tipo InitConfig.
        /// </summary>
        internal InitConfig Init_Config { get; set; } = new InitConfig();

        /// <summary>
        /// Objeto de Tipo ValidationsInControllers.
        /// </summary>
        internal ValidationsInControllers Validations { get; set; } = new ();

        /// <summary>
        /// Constructor de la Clase con Parámetros.
        /// </summary>
        /// <param name="IConfig">Objeto de Tipo IConfiguration.</param>
        public ControllersCommon(IConfiguration IConfig)
        {
            Init_Config = new();

            if (IConfig != null)
                Init_Config = new(IConfig);
        }
    }
}