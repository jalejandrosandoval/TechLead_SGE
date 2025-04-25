namespace TechLead_SGE.Server.Domain.Models.Data
{
    /// <summary>
    /// Modelo para representar los Parámetros de las Consultas hacia la Base de Datos.
    /// </summary>
    public class ParamsDataModel
    {
        /// <summary>
        /// Valor del Parámetro.
        /// </summary>
        public object ValueParam { get; set; } = new object();
    }
}