using System.Runtime.Serialization;
using TechLead_SGE.Server.Domain.Entities.Controllers;

namespace TechLead_SGE.Server.Domain.Models.Controllers
{
    /// <summary>
    /// Modelo que representa como una objeto a un Empleado dentro del sistema.
    /// </summary>
    [Serializable, DataContract]
    public class EmployeeObjModel : EmployeeEntitie
    {
        /// <summary>
        /// Identificador único del empleado (GUID).
        /// </summary>
        private new Guid Id { get; set; } = new Guid();
    }
}