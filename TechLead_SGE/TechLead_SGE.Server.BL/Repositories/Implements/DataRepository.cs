using TechLead_SGE.Server.BL.DTOS.Config;
using TechLead_SGE.Server.BL.DTOS.Data;
using TechLead_SGE.Server.BL.Classes.Logic.Data.Init;
using TechLead_SGE.Server.BL.Repositories.Interfaces;

namespace TechLead_SGE.Server.BL.Repositories.Implements
{
    /// <summary>
    /// Clase de Tipo Repository que implementa o hereda de la clase IDataRepository varias propiedades y/o métodos. 
    /// </summary>
    public class DataRepository : IDataRepository
    {
        /// <summary>
        /// Método genérico que permite obtener una Lista de Objetos de Tipo <T> y realizar algunas validaciones.
        /// </summary>
        /// <typeparam name="T">Tipo de Dato.</typeparam>
        /// <param name="Config">Objeto de tipo ConfigDto.</param>
        /// <param name="ParamsData">Objeto de tipo ParamsDataDto.</param>
        /// <returns>Task con una Lista de tipo <T>.</returns>
        public async Task<List<T>> GetObjects<T>(ConfigDto Config, ParamsDataDto ParamsData)
        {
            InitData initData = new(Config);

            List<T> result = await initData.GetObjects<T>(ParamsData);

            if (result != null)
                return result;
            else
                return await Task.FromResult(new List<T>());
        }

        /// <summary>
        /// Método genérico que permite insertar uno o varios objetos en la BD.
        /// </summary>
        /// <param name="Config">Objeto de tipo ConfigDto.</param>
        /// <param name="ParamsData">Objeto de tipo ParamsDataDto.</param>
        /// <returns>Task con un Booleano.</returns>
        public async Task<bool> PostObjects(ConfigDto Config, ParamsDataDto ParamsData)
        {
            InitData initData = new(Config);

            bool result = await initData.PostObjects(ParamsData);

            if (result)
                return result;
            else
                return await Task.FromResult(result);
        }
    }
}