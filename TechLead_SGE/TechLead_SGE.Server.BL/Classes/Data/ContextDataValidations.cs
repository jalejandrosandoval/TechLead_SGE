using TechLead_SGE.Server.BL.Models.Exceptions;

namespace TechLead_SGE.Server.BL.Classes.Data
{
    /// <summary>
    /// Clase para realizar validaciones en el contexto del manejo de las Acciones hacia la BD.
    /// </summary>
    /// <param name="NameMethod">Objeto de tipo string que corresponde al Nombre del Método.</param>
    /// <param name="Ex">Objeto de tipo Exception.</param>
    public class ContextDataValidations(string? NameMethod = "", Exception? Ex = null)
    {
        /// <summary>
        /// Objeto de tipo MessageExceptionsModel.
        /// </summary>
        public MessageExceptionsModel MessageException { get; set; } = GetExceptions(NameMethod!, Ex!);

        /// <summary>
        /// Método que permite obtener todas las Excepciones que se generen en algún método de la BD.
        /// </summary>
        /// <param name="NameMethod">Objeto de tipo string que corresponde al Nombre del Método.</param>
        /// <param name="Ex">Objeto de tipo Exception.</param>
        /// <returns>Objeto de tipo MessageExceptionsModel.</returns>
        private static MessageExceptionsModel GetExceptions(string NameMethod, Exception Ex)
        {
            MessageExceptionsModel messageExceptions = new();

            if (!string.IsNullOrEmpty(NameMethod) && Ex != null)
            {
                messageExceptions = new()
                {
                    MessageError = "Error en la ejecución del método: " + NameMethod,
                    NameMethod = NameMethod,
                    DescriptionException = "Ha ocurrido el siguiente error en el método: " + NameMethod + " - " + Ex.Message,
                    Exception = Ex
                };
            }

            return messageExceptions;
        }
    }
}