using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;

namespace TechLead_SGE.Server.Utilities.Classes.Tools
{
    /// <summary>
    /// Clase que permite tener ciertas Herramientas durante la ejecución de la Aplicación.
    /// </summary>
    public static class Tools
    {
        /// <summary>
        /// Método que permite conocer si un string es un número entero.
        /// </summary>
        /// <param name="Value">Valor string para verificar.</param>
        /// <returns>Booleano que determina si la cadena son números.</returns>
        public static bool IsNumericByString(this string Value)
        {
            bool IsNumber = int.TryParse(Value, out _);
            return IsNumber;
        }

        /// <summary>
        /// Método que permite evaluar si una cadena contiene números.
        /// </summary>
        /// <param name="Value">Valor string para verificar.</param>
        /// <returns>Booleano que determina si la cadena contiene números.</returns>
        public static bool ContainsNumbers(this string Value)
        {
            bool ContainsNumbers = Regex.IsMatch(Value, @"\d", RegexOptions.None, TimeSpan.FromMilliseconds(100));
            return ContainsNumbers;
        }

        /// <summary>
        /// Método que permite conocer si un string contiene caracteres especiales.
        /// </summary>
        /// <param name="Value">Valor string para verificar.</param>
        /// <returns>Booleano que determina si la cadena contiene carateres especiales.</returns>
        public static bool ContainsSpecialChars(this string Value)
        {
            char[] SpecialChars = ['%', '$', '!', '?', '/', '>', '<', '=', '&'];
            bool ContainsSpecialChars = Array.Exists(SpecialChars, Value.Contains);
            return ContainsSpecialChars;
        }

        /// <summary>
        /// Método que permite validar si un valor tiene un sufijo inválido.
        /// </summary>
        /// <param name="Value">Valor string para verificar.</param>
        /// <returns>Booleano que determina si la cadena contiene un sufijo de reemplazo.</returns>
        public static bool HasInvalidSuffix(this string Value)
        {
            return Value.EndsWith("__");
        }

        /// <summary>
        /// Método que permite obtener el valor de una llave en el appsettings.json y verificar si está presente en el 
        /// appsetting.json.
        /// </summary>
        /// <param name="Key">Llave a obtener del appsettings.json.</param>
        /// <param name="Configuration">Objeto de tipo IConfiguration.</param>
        /// <returns>Valor de Llave del appsettings.json.</returns>
        /// <exception cref="KeyNotFoundException">Excepción por si no se encuentra la llave en el appsettings.json</exception>
        public static string GetConfigValue(this string Key, IConfiguration Configuration)
        {
            string Value = Configuration[Key]!;

            if (string.IsNullOrEmpty(Value))
                throw new KeyNotFoundException("La Llave " + Key + " no se encuentra definida en el appsettings.json...");

            return Value;
        }

        /// <summary>
        /// Método que permite obtener un array de valores de una llave en el appsettings.json.
        /// </summary>
        /// <param name="Key">Llave a obtener del appsettings.json.</param>
        /// <param name="Configuration">Objeto de tipo IConfiguration.</param>
        /// <returns>Array de valores de la llave del appsettings.json.</returns>
        /// <exception cref="KeyNotFoundException">Excepción por si no se encuentra la llave en el appsettings.json</exception>
        public static List<string> GetConfigValueArray(this string Key, IConfiguration Configuration)
        {
            var section = Configuration.GetSection(Key);
            if (!section.Exists())
                throw new KeyNotFoundException("La Llave " + Key + " no se encuentra definida en el appsettings.json...");

            return section.Get<List<string>>() ?? throw new KeyNotFoundException("La Llave " + Key + " no contiene un array válido en el appsettings.json...");
        }

        /// <summary>
        /// Método que permite conocer si un archivo existe en una ruta específica.
        /// </summary>
        /// <param name="PathFile">Ruta del Archivo a validar.</param>
        /// <returns>Booleano que determina si existe o no el archivo en la ruta específica.</returns>
        public static bool ExistFileByPath(this string PathFile)
        {
            bool ExistFile = Path.Exists(PathFile);
            return ExistFile;
        }
    }
}