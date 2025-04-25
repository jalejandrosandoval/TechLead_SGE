using Microsoft.EntityFrameworkCore;
using TechLead_SGE.Server.Domain.Entities.Controllers;

namespace TechLead_SGE.Server.Domain.Interfaces.Data
{
    /// <summary>
    /// Interface que permite mapear diferentes propiedades para AppDbContext EF.
    /// </summary>
    public interface IAppDbContext
    {
        /// <summary>
        /// Objeto de Tipo DBSet de EmployeeEntitie.
        /// </summary>
        public DbSet<EmployeeEntitie> Employees { get; set; }

        /// <summary>
        /// Método que permite realizar un guardadk de forma asincrónica los cambios realizados en el contexto en la base de datos.
        /// </summary>
        /// <param name="cancellationToken">Token para cancelar la operación.</param>
        /// <returns>Un número entero que representa la cantidad de entidades afectadas.</returns>
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
