using TechLead_SGE.Server.Domain.Contexts.Dependencies;
using TechLead_SGE.Server.Domain.Entities.Data;
using TechLead_SGE.Server.Domain.Interfaces.Data;

namespace TechLead_SGE.Server.Domain.Models.Data
{
    /// <summary>
    /// Modelo que permite maperar los objectos para las Acciones hacia la BD, el cuál hereda propiedades de IActions.
    /// </summary>
    /// <param name="Dependencies">Objeto de Tipo IDependenciesContext.</param>
    public class ContextDataModel(IDependenciesContext Dependencies) : IContextData
    {
        /// <summary>
        /// Cadena de conexión de la Base de Datos.
        /// </summary>
        public string Cnx_Bd { get; set; } = Dependencies.ConfigurationsDto!.CNX_BD;

        /// <summary>
        /// TimeOut de conexión de la Base de Datos.
        /// </summary>
        public int TimeOut { get; set; } = 300;

        /// <summary>
        /// Objeto de tipo ValidationsInDataManager.
        /// </summary>
        public ContextDataValidations Validations { get; set; } = new();

        /// <summary>
        /// Objeto de Tipo IDependenciesContext.
        /// </summary>
        public IDependenciesContext Dependencies { get; set; } = Dependencies;
    }
}
