using TechLead_SGE.Server.Utilities.Classes.Tools;
using TechLead_SGE.Server.Utilities.Models.Swagger;
using Microsoft.Extensions.Configuration;

namespace TechLead_SGE.Server.Utilities.Classes.Swagger.Common
{
    /// <summary>
    /// Clase que permite realizar validaciones e inicializacion para el Swagger.
    /// </summary>
    internal class ValidationsSwagger
    {
        /// <summary>
        /// Objeto de tipo ParamsSwaggerModel.
        /// </summary>
        internal ParamsSwaggerModel Params = new();

        /// <summary>
        /// Método que permite inicializar los párametros transversales obteniendolos desde el AppSettings.json.
        /// </summary>
        /// <param name="ConfigManag">Objeto de tipo IConfiguration.</param>
        internal void InitParamsSwagger(IConfiguration ConfigManag)
        {
            if (ConfigManag != null)
            {
                Params.EnvironmentAPI = "Environment:EnvironmentAPI".GetConfigValue(ConfigManag);
                Params.EnableSwagger = "Swagger:EnableSwagger".GetConfigValue(ConfigManag);
                Params.DocsSwagger = new()
                {
                    VersionAPI = "Swagger:DocsSwagger:VersionAPI".GetConfigValue(ConfigManag),
                    Title = "Swagger:DocsSwagger:Title".GetConfigValue(ConfigManag),
                    TermsOfService = "Swagger:DocsSwagger:TermsOfService".GetConfigValue(ConfigManag),
                    Description = "Swagger:DocsSwagger:Description".GetConfigValue(ConfigManag),
                    Contact = new()
                    {
                        Name = "Swagger:DocsSwagger:Contact:Name".GetConfigValue(ConfigManag),
                        Url = "Swagger:DocsSwagger:Contact:Url".GetConfigValue(ConfigManag)
                    },
                    License = new()
                    {
                        Name = "Swagger:DocsSwagger:License:Name".GetConfigValue(ConfigManag),
                        Url = "Swagger:DocsSwagger:License:Url".GetConfigValue(ConfigManag)
                    },
                    DocsXml = "Swagger:DocsSwagger:DocsXml".GetConfigValueArray(ConfigManag)
                };
            }
        }

        /// <summary>
        /// Método que permite realizar validaciones a los párametros del SWAGGER.
        /// </summary>
        /// <returns>Booleano que corresponde al estado de las validaciones.</returns>
        internal bool ValidParamsSwagger()
        {
            bool validations = false;

            if (!string.IsNullOrEmpty(Params.EnableSwagger) &&
               !string.IsNullOrEmpty(Params.EnvironmentAPI) &&
               !string.IsNullOrEmpty(Params.DocsSwagger.VersionAPI) &&
               !string.IsNullOrEmpty(Params.DocsSwagger.Title) &&
               !string.IsNullOrEmpty(Params.DocsSwagger.TermsOfService) &&
               !string.IsNullOrEmpty(Params.DocsSwagger.Description) &&
               !string.IsNullOrEmpty(Params.DocsSwagger.Contact.Name) &&
               !string.IsNullOrEmpty(Params.DocsSwagger.Contact.Url) &&
               !string.IsNullOrEmpty(Params.DocsSwagger.License.Name) &&
               !string.IsNullOrEmpty(Params.DocsSwagger.License.Url) &&
               !Params.EnableSwagger.HasInvalidSuffix() &&
               !Params.EnvironmentAPI.HasInvalidSuffix() &&
               !Params.DocsSwagger.VersionAPI.HasInvalidSuffix() &&
               !Params.DocsSwagger.Title.HasInvalidSuffix() &&
               !Params.DocsSwagger.TermsOfService.HasInvalidSuffix() &&
               !Params.DocsSwagger.Description.HasInvalidSuffix() &&
               !Params.DocsSwagger.Contact.Name.HasInvalidSuffix() &&
               !Params.DocsSwagger.Contact.Url.HasInvalidSuffix() &&
               !Params.DocsSwagger.License.Name.HasInvalidSuffix() &&
               !Params.DocsSwagger.License.Url.HasInvalidSuffix() &&
               Params.DocsSwagger.DocsXml.Count > 0)
                validations = true;

            return validations;
        }
    }
}
