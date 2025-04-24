namespace TechLead_SGE.Server.BL.Models.Exceptions
{
    /// <summary>
    /// Modelo para representar como objetos los mensajes de Excepciones a Mostrar.
    /// </summary>
    public class MessageExceptionsModel
    {
        /// <summary>
        /// Mensaje del Error.
        /// </summary>
        public string MessageError { get; set; } = string.Empty;

        /// <summary>
        /// Nombre del Método donde se generó la Excepción.
        /// </summary>
        public string NameMethod { get; set; } = string.Empty;

        /// <summary>
        /// Objeto correspondiente a la Excepción.
        /// </summary>
        public object? Exception { get; set; }

        /// <summary>
        /// Objeto correspondiente a la Descripción del Error de la Excepción.
        /// </summary>
        public object? DescriptionException { get; set; }
    }
}