using AutoMapper;
using TechLead_SGE.Server.Domain.DTOS.Controllers;
using TechLead_SGE.Server.Domain.Entities.Controllers;

namespace TechLead_SGE.Server.BL.Classes.Mapper
{
    /// <summary>
    /// Clase de Configuración de AutoMapper que hereda de Profile.
    /// </summary>
    public class AutoMapperSettings : Profile
    {
        /// <summary>
        /// Constructor de la Clase.
        /// </summary>
        public AutoMapperSettings()
        {           
            CreateMap<EmployeeEntitie, EmployeeDto>().ReverseMap();
        }
    }
}
