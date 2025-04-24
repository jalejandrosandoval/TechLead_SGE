using TechLead_SGE.Server.Utilities.Classes.Tools;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TechLead_SGE.Server.Utilities.Classes.Swagger.Common
{
    /// <summary>
    /// Clase que permite tener ciertas Herramientas para utilizar con Swagger.
    /// </summary>
    internal static class ToolsSwagger
    {
        /// <summary>
        /// Método para obtener los XML Docs por el Nombre del Ensamblado.
        /// </summary>
        /// <param name="Options">Objeto de tipo SwaggerGenOptions.</param>
        /// <param name="ListAssemblies">Objeto de tipo List de Strings que correponde al Listado de Ensamblados a obtener la documentación.</param>
        /// <returns>Objeto de tipo SwaggerGenOptions.</returns>
        internal static SwaggerGenOptions GetDocsByAssemblyName(this SwaggerGenOptions Options, List<string> ListAssemblies)
        {
            foreach (string Assembly in ListAssemblies)
                Options.IncludeXmlDocs(Assembly);

            return Options;
        }

        /// <summary>
        /// Método para incluir los XML Docs en el Swagger.
        /// </summary>
        /// <param name="Options">Objeto de tipo SwaggerGenOptions.</param>
        /// <param name="NameFileXML">Objeto de tipo string que corresponde al Nombre del Ensamblado.</param>
        /// <returns>Objeto de tipo SwaggerGenOptions.</returns>
        internal static SwaggerGenOptions IncludeXmlDocs(this SwaggerGenOptions Options, string NameFileXML)
        {
            if (!string.IsNullOrEmpty(NameFileXML))
            {
                string PathFileAssemblyDomain = Path.Combine(AppContext.BaseDirectory, NameFileXML);

                if (PathFileAssemblyDomain.ExistFileByPath())
                    Options.IncludeXmlComments(PathFileAssemblyDomain);

                return Options;
            }

            return Options;
        }
    }
}