using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechLead_SGE.Server.BL.Classes.Config;
using TechLead_SGE.Server.Domain.Entities.Controllers;
using TechLead_SGE.Server.Domain.Interfaces.Data;

namespace TechLead_SGE.Server.Data.DBContext.Common
{
    /// <summary>
    /// Clase de Inicialización del DbContext.
    /// </summary>
    public static class InitDBContext
    {
        /// <summary>
        /// Método que permite realizar la configuración del DBContext.
        /// </summary>
        /// <param name="Services">Objeto de tipo IServiceCollection.</param>
        /// <param name="Configuration">Objeto de tipo IConfiguration.</param>
        /// <returns>Objeto de tipo IServiceCollection.</returns>
        public static IServiceCollection ConfigureDbContextApi(this IServiceCollection Services, IConfiguration Configuration)
        {
            Services.AddDbContext<AppDbContext>(
                options =>
                {
                    options.UseSqlServer(new InitConfig(Configuration).ConfigurationsDto.CNX_BD);
                }
            );
            
            Services.AddScoped<IAppDbContext, AppDbContext>();

            using (var scope = Services.BuildServiceProvider().CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                SeedInitDataDBContext(dbContext);
            }

            return Services;
        }

        /// <summary>
        /// Método para insertar datos iniciales en la base de datos.
        /// </summary>
        /// <param name="dbContext">Instancia del DbContext.</param>
        private static void SeedInitDataDBContext(AppDbContext dbContext)
        {
            dbContext.Database.Migrate();

            if (!dbContext.Employees.Any())
            {
                dbContext.Employees.AddRange(
                    new EmployeeEntitie
                    {
                        Id = Guid.NewGuid(),
                        Name = "Camila Herrera",
                        Position = "Desarrolladora Backend",
                        Department = "Tecnología",
                        Salary = 7500000,
                        HiringDate = DateTime.Now.AddDays(-new Random().Next(30, 465)),
                        IsActive = true
                    },
                    new EmployeeEntitie
                    {
                        Id = Guid.NewGuid(),
                        Name = "David Méndez",
                        Position = "Ingeniero DevOps",
                        Department = "Infraestructura",
                        Salary = 6400000,
                        HiringDate = DateTime.Now.AddDays(-new Random().Next(10, 256)),
                        IsActive = true
                    },
                    new EmployeeEntitie
                    {
                        Id = Guid.NewGuid(),
                        Name = "Laura Sánchez",
                        Position = "Analista QA",
                        Department = "Calidad",
                        Salary = 4800000,
                        HiringDate = DateTime.Now.AddDays(-new Random().Next(45, 259)),
                        IsActive = true
                    },
                    new EmployeeEntitie
                    {
                        Id = Guid.NewGuid(),
                        Name = "Julián Castillo",
                        Position = "Diseñador UX/UI",
                        Department = "Diseño",
                        Salary = 4200000,
                        HiringDate = DateTime.Now.AddDays(-new Random().Next(145, 730)),
                        IsActive = false
                    }
                );

                dbContext.SaveChanges();
            }

        }
    }
}