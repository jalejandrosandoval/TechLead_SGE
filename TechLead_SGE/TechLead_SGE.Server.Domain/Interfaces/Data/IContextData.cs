﻿using TechLead_SGE.Server.Domain.Contexts.Dependencies;
using TechLead_SGE.Server.Domain.Entities.Data;

namespace TechLead_SGE.Server.Domain.Interfaces.Data
{
    /// <summary>
    /// Interface que permite mapear los objetos para realizar las diferentes acciones hacia la BD.
    /// </summary>
    public interface IContextData
    {
        /// <summary>
        /// Cadena de conexión de la Base de Datos.
        /// </summary>
        public string Cnx_Bd { get; set; }

        /// <summary>
        /// TimeOut de conexión de la Base de Datos.
        /// </summary>
        public int TimeOut { get; set; }

        /// <summary>
        /// Objeto de tipo ValidationsInDataManager.
        /// </summary>
        public ContextDataValidations Validations { get; set; }

        /// <summary>
        /// Objeto de Tipo IDependenciesContext.
        /// </summary>
        public IDependenciesContext Dependencies { get; set; }
    }
}