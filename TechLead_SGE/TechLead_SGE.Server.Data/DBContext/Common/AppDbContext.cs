using Microsoft.EntityFrameworkCore;
using TechLead_SGE.Server.Domain.Entities.Controllers;
using TechLead_SGE.Server.Domain.Interfaces.Data;

namespace TechLead_SGE.Server.Data.DBContext.Common
{
    /// Clase que representa el contexto de la BD utilizando EF, la cuál se encarga de interactuar 
    /// con la BD y contener las configuraciones necesarias para las tablas y relaciones.
    /// <summary>
    /// Constructor que pasa las opciones de configuración al DbContext base.
    /// </summary>
    /// <param name="DBOptions">Opciones de configuración para el contexto de base de datos.</param>
    public class AppDbContext(DbContextOptions<AppDbContext> DBOptions) : DbContext(DBOptions), IAppDbContext
    {
        /// <summary>
        /// Representa la tabla de empleados en la base de datos.
        /// </summary>
        public DbSet<EmployeeEntitie> Employees { get; set; }

        /// <summary>
        /// Método para configurar las relaciones y otras configuraciones del modelo.
        /// Aquí se definen las configuraciones de las tablas y las propiedades del modelo.
        /// </summary>
        /// <param name="Builder">El objeto ModelBuilder que permite configurar el modelo.</param>
        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);

            // Creación de la Tabla Employees.
            Builder.Entity<EmployeeEntitie>().ToTable("Employees");

            // Configuración de Propiedades Adicionales.
            Builder.Entity<EmployeeEntitie>()
                        .Property(e => e.IsActive)
                        .IsRequired()
                        .HasDefaultValue(true);
        }

        /// <summary>
        /// Método que permite realizar un guardadk de forma asincrónica los cambios realizados en el contexto en la base de datos.
        /// </summary>
        /// <param name="cancellationToken">Token para cancelar la operación.</param>
        /// <returns>Un número entero que representa la cantidad de entidades afectadas.</returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}