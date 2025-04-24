using Microsoft.AspNetCore.Mvc;
using TechLead_SGE.Server.BL.DTOS.Controllers;
using TechLead_SGE.Server.BL.DTOS.Data;
using TechLead_SGE.Server.Classes.Controllers.Common;
using static TechLead_SGE.Server.BL.Models.Data.EnumTypesForApi;

namespace TechLead_SGE.Server.Controllers
{
    /// <summary>
    /// Controlador que permite el manejo de los diferentes ítems de los Empleados que existen en la BD y que hereda ciertas propiedades de ControllersCommon.
    /// </summary>
    /// <param name="IConfig">Objeto de Tipo IConfiguration.</param>
    public class EmployeeController(IConfiguration IConfig) : ControllersCommon(IConfig)
    {
        /// <summary>
        /// Endpoint que permite obtener un listado de los Empleados.
        /// </summary>
        /// <remarks>
        /// Endpoint que permite obtener un listado con todos los Empleados Registrados.
        /// 
        /// Ejemplo:
        ///
        ///     GET GetEmployees/
        ///     [
        ///         {
        ///             "idEmployee": 1234,
        ///             "name": "Nombre del Empleado",
        ///             "position": "Posición o Cargo",
        ///             "department": "Departamento o Área",
        ///             "salary": 1.2345,
        ///             "hiringDate": "Fecha de Contratación",
        ///             "isActive": "Estado del Empleado"
        ///         }
        ///     ]
        /// 
        /// </remarks>
        /// <returns>Task.</returns>
        /// <response code="200"> OK: Se encontró el Listado de Empleados.</response>
        /// <response code="400"> BadRequest: El Servidor NO puede procesar la petición, por favor verificar la información suministrada.</response>
        /// <response code="401"> Unauthorized: No se permite ejecutar la operación, NO Autorizado.</response>
        /// <response code="404"> Not Found: No se encuentra ningún Empleado Registrado o Activo.</response>
        /// <response code="500"> Internal Server Error: Error NO controlado.</response>
        [HttpGet]
        [Route("GetEmployees/")]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                ParamsDataDto ParamsData = new()
                {
                    ActionsName = EnumActions.EmployeeActions,
                    ActionDetails = EnumActionsDetails.GetEmployees
                };

                List<EmployeeDto> Employees = await Init_Config.dataService.GetObjects<EmployeeDto>(Init_Config.ConfigurationsDto, ParamsData);

                return Init_Config.Validations.ValidateListObjResult(Employees, "OK....");
            }
            catch (Exception ex)
            {
                return Init_Config.Validations.CatchError(ex);
            }
        }
    }
}
