using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace TechLead_SGE.Server.BL.Entities.Controllers
{
    /// <summary>
    /// Modelo que representa como una entidad a un empleado dentro del sistema.
    /// </summary>
    [DataContract, Serializable]

    public class EmployeeEntitie
    {
        /// <summary>
        /// Identificador único del empleado (GUID).
        /// </summary>
        [Key] // Especifica que esta propiedad es la clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public Guid Id { get; set; } = new Guid();

        /// <summary>
        /// Nombre completo del empleado.
        /// </summary>
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        [DefaultValue("Nombre del Empleado")]
        [DataMember]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Puesto o cargo que ocupa el empleado en la empresa.
        /// </summary>
        [Required(ErrorMessage = "El puesto es obligatorio.")]
        [StringLength(50, ErrorMessage = "El puesto no puede superar los 50 caracteres.")]
        [DefaultValue("Puesto")]
        [DataMember] 
        public string Position { get; set; } = string.Empty;

        /// <summary>
        /// Departamento al que pertenece el empleado.
        /// </summary>
        [Required(ErrorMessage = "El departamento es obligatorio.")]
        [StringLength(50, ErrorMessage = "El departamento no puede superar los 50 caracteres.")]
        [DefaultValue("Deparamento")]
        [DataMember] 
        public string Department { get; set; } = string.Empty;

        /// <summary>
        /// Salario del empleado. Este valor no puede ser negativo.
        /// </summary>
        [Required(ErrorMessage = "El salario es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El salario debe ser mayor o igual a 0.")]
        [DefaultValue(1400000)]
        [DataMember] 
        public decimal Salary { get; set; }

        /// <summary>
        /// Fecha de contratación del empleado.
        /// </summary>
        [Required(ErrorMessage = "La fecha de contratación es obligatoria.")]
        [DefaultValue(typeof(DateTime), "2025-04-01")]
        [DataMember]
        public DateTime HiringDate { get; set; }

        /// <summary>
        /// Indica si el empleado está activo o no.
        /// </summary>
        [Required(ErrorMessage = "El estado es obligatorio.")]
        [DefaultValue(true)]
        [DataMember]
        public bool IsActive { get; set; }
    }
}
