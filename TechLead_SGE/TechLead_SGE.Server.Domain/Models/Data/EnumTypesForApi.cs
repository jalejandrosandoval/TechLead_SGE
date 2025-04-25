namespace TechLead_SGE.Server.Domain.Models.Data
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
            Put,

            /// <summary>
            /// Método pararealizar la eliminación de un Objeto.
            /// </summary>
            Delete
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

            /// <summary>
            /// Método que permite crear un nuevo Empleado.
            /// </summary>
            PostEmployee,

            /// <summary>
            /// Método que permite actualizar la información de un Empleado.
            /// </summary>
            PutEmployee,

            /// <summary>
            /// Método que permite eliminar un Empleado.
            /// </summary>
            DeleteEmployee
        }
    }
}
