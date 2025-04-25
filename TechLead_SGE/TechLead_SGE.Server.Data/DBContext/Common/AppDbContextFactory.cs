using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TechLead_SGE.Server.Data.DBContext.Common
{
    /// <summary>
    /// Fábrica para crear instancias de AppDbContext en tiempo de diseño (migraciones, etc.).
    /// </summary>
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        /// <summary>
        /// Método que permite crear la BD con EF en tiempo de Diseño.
        /// </summary>
        /// <param name="args">Objeto de tipo Array de String.</param>
        /// <returns>Objeto de Tipo AppDbContext.</returns>
        public AppDbContext CreateDbContext(string[] args)
        {
            string basePath = Path.Combine(Directory.GetCurrentDirectory(), "../TechLead_SGE.Server");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                                                .SetBasePath(basePath)
                                                .AddJsonFile("appsettings.json", optional: false)
                                                .Build();

            DbContextOptionsBuilder<AppDbContext> optionsBuilder = new();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("CNX_BD"));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
