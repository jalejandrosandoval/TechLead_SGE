namespace TechLead_SGE.Server.BL.Models.Data
{
    /// <summary>
    /// Modelo para los diferentes tipos de Métodos para acceder a la Data.
    /// </summary>
    public class EnumTypesForApi
    {
        /// <summary>
        /// Lista Enumerada para establecer los diferentes tipos de Operaciones para acceder a la Data.
        /// </summary>
        public enum EnumTypeOperation
        {
            /// <summary>
            /// Método para realizar la obtención de un Objeto.
            /// </summary>
            Get,

            /// <summary>
            /// Método para realizar la inserción de un Objeto.
            /// </summary>
            Post,

            /// <summary>
            /// Método para realizar la actualización de un Objeto.
            /// </summary>
            Update
        }

        /// <summary>
        /// Lista Enumerada para establecer los tipos de las Acciones para acceder a la Data.
        /// </summary>
        public enum EnumActions
        {
            /// <summary>
            /// Acciones de Envío de Correos.
            /// </summary>
            EmployeeActions
        }

        /// <summary>
        /// Lista Enumerada para establecer los diferentes nombre de las Acicones para acceder a la Data.
        /// </summary>
        public enum EnumActionsDetails
        {
            /// <summary>
            /// Método que permite obtener los Empleados.
            /// </summary>
            GetEmployees,
        }
    }
}
