using AutoMapper;
using TechLead_SGE.Server.Domain.DTOS.Config;
using TechLead_SGE.Server.Domain.Interfaces.Data;

namespace TechLead_SGE.Server.Domain.Contexts.Dependencies
{
    /// <summary>
    /// Clase que permite manejar como Objetos el contexto de las dependencias.
    /// </summary>
    public class DependenciesContext : IDependenciesContext
    {
        /// <summary>
        /// Objeto de tipo ConfigDto.
        /// </summary>
        public ConfigDto? ConfigurationsDto { get; set; }

        /// <summary>
        /// Objeto de Tipo IAppDbContext.
        /// </summary>
        public IAppDbContext? Context { get; set; }

        /// <summary>
        /// Objeto de Tipo IMapper.
        /// </summary>
        public IMapper? Mapper { get; set; }
    }
}
