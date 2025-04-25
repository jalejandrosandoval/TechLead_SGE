using TechLead_SGE.Server.Domain.Contexts.Dependencies;
using TechLead_SGE.Server.Domain.DTOS.Data;

namespace TechLead_SGE.Server.BL.Repositories.Interfaces
{
    /// <summary>
    /// Interface de tipo Repository que implementa varias propiedades y/o métodos que permite realizar múltiples funciones.
    /// </summary>
    public interface IDataRepository
    {
        /// <summary>
        /// Método genérico que permite obtener una Lista de Objetos de Tipo <T> y realizar algunas validaciones.
        /// </summary>
        /// <typeparam name="T">Tipo de Dato.</typeparam>
        /// <param name="Dependencies">Objeto de tipo IDependenciesContext.</param>
        /// <param name="ParamsData">Objeto de tipo ParamsDataDto.</param>
        /// <returns>Task con una Lista de tipo <T>.</returns>
        public Task<List<T>> GetObjects<T>(IDependenciesContext Dependencies, ParamsDataDto ParamsData);

        /// <summary>
        /// Método genérico que permite insertar uno o varios objetos en la BD.
        /// </summary>
        /// <param name="Dependencies">Objeto de tipo IDependenciesContext.</param>
        /// <param name="ParamsData">Objeto de tipo ParamsDataDto.</param>
        /// <returns>Task con un Booleano.</returns>
        public Task<bool> PostObjects(IDependenciesContext Dependencies, ParamsDataDto ParamsData);
    }
}