using TechLead_SGE.Server.Utilities.Classes.Tools;
using TechLead_SGE.Server.Utilities.Models.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TechLead_SGE.Server.Utilities.Classes.Swagger.Common
{
    /// <summary>
    /// Clase para la configuración inicial del Swagger.
    /// </summary>
    public static class InitSwagger
    {
        /// <summary>
        /// Objeto de tipo ValidationsSwagger.
        /// </summary>
        private static readonly ValidationsSwagger Validations = new();

        /// <summary>
        /// Método para inicializar el swagger con ciertos párametros.
        /// </summary>
        /// <param name="Services">Objeto de tipo IServiceCollection.</param>
        /// <param name="Configuration">Objeto de tipo IConfiguration.</param>
        /// <returns>Objeto de tipo IServiceCollection.</returns>
        public static IServiceCollection ConfigureSwaggerApi(this IServiceCollection Services, IConfiguration Configuration)
        {
            Validations.InitParamsSwagger(Configuration);
            bool validations = Validations.ValidParamsSwagger();

            if (validations)
            {
                if (Validations.Params.EnableSwagger.ToLower().ToString() == "false")
                    return Services;

                Services.AddSwaggerGen(
                    options =>
                    {
                        // Options Docs
                        GetOptionsDocsSwagger(options, Validations.Params);

                        options.IgnoreObsoleteActions();
                        options.ResolveConflictingActions(apiDescriptions => apiDescriptions.FirstOrDefault());

                        options.GetDocsByAssemblyName(Validations.Params.DocsSwagger.DocsXml);
                    }
                );
            }

            return Services;
        }

        /// <summary>
        /// Método para inicializar el swagger con ciertos parámetros e Iniciar la Carga Gráfica.
        /// </summary>
        /// <param name="Services">Objeto de tipo IServiceCollection.</param>
        /// <param name="Configuration">Objeto de tipo IConfiguration.</param>
        /// <param name="App">Objeto de tipo WebApplication.</param>
        /// <returns>Objeto de tipo IServiceCollection.</returns>
        public static IServiceCollection ConfigureSwaggerApiUI(this IServiceCollection Services, IConfiguration Configuration, WebApplication App)
        {
            Validations.InitParamsSwagger(Configuration);
            bool validations = Validations.ValidParamsSwagger();

            if (validations && !string.IsNullOrEmpty(Validations.Params.EnableSwagger) && 
                !Validations.Params.EnableSwagger.HasInvalidSuffix())
            {
                if (Validations.Params.EnableSwagger.ToLower().ToString() == "false")
                    return Services;

                App.UseSwagger();
                App.UseSwaggerUI();
            }

            return Services;
        }

        /// <summary>
        /// Método para obtener las opciones de la documentación del Swagger.
        /// </summary>
        /// <param name="Options">Objeto de tipo SwaggerGenOptions.</param>
        /// <param name="Params">Objeto de tipo ParamsSwagger.</param>
        private static void GetOptionsDocsSwagger(SwaggerGenOptions Options, ParamsSwaggerModel Params)
        {
            Options.SwaggerDoc(Params.DocsSwagger.VersionAPI, new OpenApiInfo
            {
                Version = Params.DocsSwagger.VersionAPI,
                Title = Params.DocsSwagger.Title + " - " + Params.EnvironmentAPI,
                Description = Params.DocsSwagger.Description,
                TermsOfService = new Uri(Params.DocsSwagger.TermsOfService),
                Contact = new OpenApiContact
                {
                    Name = Params.DocsSwagger.Contact.Name,
                    Url = new Uri(Params.DocsSwagger.Contact.Url)
                },
                License = new OpenApiLicense
                {
                    Name = Params.DocsSwagger.License.Name,
                    Url = new Uri(Params.DocsSwagger.License.Url)
                }
            });
        }
    }
}