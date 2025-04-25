using TechLead_SGE.Server.BL.Repositories.Interfaces;
using TechLead_SGE.Server.BL.Services.Interfaces;
using TechLead_SGE.Server.Domain.Contexts.Dependencies;
using TechLead_SGE.Server.Domain.DTOS.Data;

namespace TechLead_SGE.Server.BL.Services.Implements
{
    /// <summary>
    /// Clase de Tipo Repository que implementa o hereda de la clase IDataService varias propiedades y/o métodos. 
    /// </summary>
    /// <param name="GenericRepository">Párametro de tipo IDataRepository.</param>
    public class DataService(IDataRepository GenericRepository) : IDataService
    {
        /// <summary>
        /// Método genérico que permite obtener una Lista de Objetos de Tipo <T> y realizar algunas validaciones.
        /// </summary>
        /// <typeparam name="T">Tipo de Dato.</typeparam>
        /// <param name="Dependencies">Objeto de tipo IDependenciesContext.</param>
        /// <param name="ParamsData">Objeto de tipo ParamsDataDto.</param>
        /// <returns>Task con una Lista de tipo <T>.</returns>
        public async Task<List<T>> GetObjects<T>(IDependenciesContext Dependencies, ParamsDataDto ParamsData)
        {
            return await GenericRepository.GetObjects<T>(Dependencies, ParamsData);
        }

        /// <summary>
        /// Método genérico que permite insertar uno o varios objetos en la BD.
        /// </summary>
        /// <param name="Dependencies">Objeto de tipo IDependenciesContext.</param>
        /// <param name="ParamsData">Objeto de tipo ParamsDataDto.</param>
        /// <returns>Task con un Booleano.</returns>
        public async Task<bool> PostObjects(IDependenciesContext Dependencies, ParamsDataDto ParamsData)
        {
            return await GenericRepository.PostObjects(Dependencies, ParamsData);
        }
    }
}