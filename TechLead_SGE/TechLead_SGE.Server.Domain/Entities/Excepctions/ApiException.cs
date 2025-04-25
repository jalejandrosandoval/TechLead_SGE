using TechLead_SGE.Server.Domain.Models.Exceptions;

namespace TechLead_SGE.Server.Domain.Entities.Excepctions
{
    /// <summary>
    /// Clase que representa una excepción que se lanza cuando la respuesta de los Métodos no es la esperada.
    /// </summary>
    public class ApiException : Exception
    {
        /// <summary>
        /// Objeto de Tipo MessageExceptions. 
        /// </summary>
        public MessageExceptionsModel MessageException { get; set; } = new();

        /// <summary>
        /// Método Constructor que inicializa una excepción que se lanza cuando la respuesta de los Métodos no es la esperada.
        /// </summary>
        public ApiException() : base() { }

        /// <summary>
        /// Método Constructor que inicializa una excepción que se lanza cuando la respuesta de los Métodos no es la esperada.
        /// </summary>
        /// <param name="message">String que corresponde al mensaje de la excepción que se desea lanzar.</param>
        public ApiException(string? message) : base(message) { }

        /// <summary>
        /// Método Constructor que inicializa una excepción que se lanza cuando la respuesta de la API a consumir no es la esperada o adecuada.
        /// </summary>
        /// <param name="_messageExceptions">Objeto de tipo MessageExceptionsModel.</param>
        public ApiException(MessageExceptionsModel _messageExceptions) : base() { MessageException = _messageExceptions; }

        /// <summary>
        /// Método Constructor que inicializa una excepción que se lanza cuando la respuesta de la API a consumir no es la esperada o adecuada.
        /// </summary>
        /// <param name="innerException">Objeto de Tipo Exception que corresponde a la excepción que causo la actual excepción.</param>
        public ApiException(Exception innerException) : base(innerException.Message, innerException) { }
    }
}
