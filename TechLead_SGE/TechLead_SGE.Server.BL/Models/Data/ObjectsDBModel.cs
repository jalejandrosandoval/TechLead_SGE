using System.Data;

namespace TechLead_SGE.Server.BL.Models.Data
{
    /// <summary>
    /// Modelo de Datos que permite mapear como objetos los diferentes parámetros que se envían a la BD.
    /// </summary>
    public class ObjectsDBModel
    {
        /// <summary>
        /// Nombre del Parámetro.
        /// </summary>
        public string NameParam { get; set; } = string.Empty;

        /// <summary>
        /// Tipo de Dato del Parámetro.
        /// </summary>
        public SqlDbType TypeParam { get; set; }

        /// <summary>
        /// Valor del Parámetro.
        /// </summary>
        public object ValueParam { get; set; } = string.Empty;

        /// <summary>
        /// Tamaño del Parámetro.
        /// </summary>
        public int SizeParam { get; set; } = 0;

        /// <summary>
        /// Dirección del Parámetro.
        /// </summary>
        public ParameterDirection DirectionParam { get; set; }
    }
}
