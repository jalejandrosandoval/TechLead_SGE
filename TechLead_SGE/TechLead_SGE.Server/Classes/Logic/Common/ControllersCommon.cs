using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechLead_SGE.Server.BL.Classes.Config;
using TechLead_SGE.Server.Domain.Contexts.Dependencies;
using TechLead_SGE.Server.Domain.Interfaces.Data;

namespace TechLead_SGE.Server.Classes.Logic.Common
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
        /// Objeto de Tipo DependenciesContext.
        /// </summary>
        internal DependenciesContext Dependencies { get; set; }

        /// <summary>
        /// Constructor de la Clase con Parámetros.
        /// </summary>
        /// <param name="IConfig">Objeto de Tipo IConfiguration.</param>
        /// <param name="Context">Objeto de Tipo IAppDbContext.</param>
        /// <param name="Mapper">Objeto de Tipo IMapper.</param>
        public ControllersCommon(IConfiguration IConfig, IAppDbContext Context, IMapper Mapper)
        {
            Init_Config = new();
            Dependencies = new();

            if (IConfig != null)
            {
                Init_Config = new(IConfig);
                Dependencies.ConfigurationsDto = Init_Config.ConfigurationsDto;
            }

            if(Context != null)
                Dependencies.Context = Context;

            if(Mapper != null)
                Dependencies.Mapper = Mapper;
        }
    }
}