namespace TechLead_SGE.Server.Utilities.Models.Swagger
{
    /// <summary>
    /// Modelo de parámetros para la documentación de Swagger.
    /// </summary>
    internal class ParamsSwaggerModel
    {
        /// <summary>
        /// Clase que permite obtener la información de la licencia.
        /// </summary>
        internal class License
        {
            /// <summary>
            /// Nombre de la licencia.
            /// </summary>
            internal string Name { get; set; } = string.Empty;
            /// <summary>
            /// URL de la licencia.
            /// </summary>
            internal string Url { get; set; } = string.Empty;
        }

        /// <summary>
        /// Clase que permite obtener la información del contacto.
        /// </summary>
        internal class Contact
        {
            /// <summary>
            /// Nombre del contacto.
            /// </summary>
            internal string Name { get; set; } = string.Empty;
            /// <summary>
            /// URL del contacto.
            /// </summary>
            internal string Url { get; set; } = string.Empty;
        }

        /// <summary>
        /// Clase que permite obtener la información de la documentación que tendrá Swwager.
        /// </summary>
        internal class Docs
        {
            /// <summary>
            /// Versión de la API.
            /// </summary>
            internal string VersionAPI { get; set; } = string.Empty;

            /// <summary>
            /// Título de la API.
            /// </summary>
            internal string Title { get; set; } = string.Empty;

            /// <summary>
            /// Descripción de la API.
            /// </summary>
            internal string Description { get; set; } = string.Empty;

            /// <summary>
            /// Términos de servicio de la API.
            /// </summary>
            internal string TermsOfService { get; set; } = string.Empty;

            /// <summary>
            /// Objeto de tipo Contact.
            /// </summary>
            internal Contact Contact { get; set; } = new();

            /// <summary>
            /// Objeto de tipo License.
            /// </summary>
            internal License License { get; set; } = new();

            /// <summary>
            /// Lista de XML Docs.
            /// </summary>
            internal List<string> DocsXml { get; set; } = [];
        }

        /// <summary>
        /// Ambiente del API.
        /// </summary>
        internal string EnvironmentAPI { get; set; } = string.Empty;

        /// <summary>
        /// Valor que corresponde a si se quiere o no activar el swagger de acuerdo al ambiente.
        /// </summary>
        internal string EnableSwagger { get; set; } = string.Empty;

        /// <summary>
        /// Objeto de tipo Docs.
        /// </summary>
        internal Docs DocsSwagger { get; set; } = new();
    }
}