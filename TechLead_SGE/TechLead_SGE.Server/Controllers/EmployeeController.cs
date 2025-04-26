using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechLead_SGE.Server.Classes.Logic.Common;
using TechLead_SGE.Server.Classes.Logic.Custom;
using TechLead_SGE.Server.Data.DBContext.Common;
using TechLead_SGE.Server.Domain.Models.Controllers;
using static TechLead_SGE.Server.Domain.Models.Data.EnumTypesForApi;

namespace TechLead_SGE.Server.Controllers
{
    /// <summary>
    /// Controlador que permite el manejo de los diferentes ítems de los Empleados que existen en la BD y que hereda ciertas propiedades de ControllersCommon.
    /// </summary>
    /// <param name="IConfig">Objeto de Tipo IConfiguration.</param>
    /// <param name="Context">Objeto de Tipo AppDbContext.</param>
    /// <param name="Mapper">Objeto de Tipo IMapper.</param>
    public class EmployeeController(IConfiguration IConfig, AppDbContext Context, IMapper Mapper) : ControllersCommon(IConfig, Context, Mapper)
    {
        /// <summary>
        /// Endpoint que permite obtener un listado de los Empleados.
        /// </summary>
        /// <remarks>
        /// Endpoint que permite obtener un listado con todos los Empleados Registrados.
        /// 
        /// Ejemplo:
        ///
        ///     GET Employees/
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
        [Route("Employees/")]
        public async Task<ActionResult> Employees() =>
            await EmployeeLogic.GetEmployeesParams(Init_Config, Validations, Dependencies);

        /// <summary>
        /// Endpoint que permite obtener el detalle de los Empleados de acuerdo a su ID.
        /// </summary>
        /// <remarks>
        /// Endpoint que permite obtener el detalle de un empleado registrado de acuerdo a su ID.
        /// 
        /// Ejemplo:
        ///
        ///     GET Employees/{ID}
        ///     {
        ///         "idEmployee": 1234,
        ///         "name": "Nombre del Empleado",
        ///         "position": "Posición o Cargo",
        ///         "department": "Departamento o Área",
        ///         "salary": 1.2345,
        ///         "hiringDate": "Fecha de Contratación",
        ///         "isActive": "Estado del Empleado"
        ///     }
        /// 
        /// </remarks>
        /// <returns>Task.</returns>
        /// <response code="200"> OK: Se encontró el detalle del Empleados.</response>
        /// <response code="400"> BadRequest: El Servidor NO puede procesar la petición, por favor verificar la información suministrada.</response>
        /// <response code="401"> Unauthorized: No se permite ejecutar la operación, NO Autorizado.</response>
        /// <response code="404"> Not Found: No se encuentra ningún Empleado Registrado o Activo.</response>
        /// <response code="500"> Internal Server Error: Error NO controlado.</response>
        [HttpGet]
        [Route("Employees/{ID}")]
        public async Task<ActionResult> Employees(Guid ID) =>
            await EmployeeLogic.GetEmployeesParams(Init_Config, Validations, Dependencies, ID);

        /// <summary>
        /// Endpoint que permite insertar la información de un Empleado.
        /// </summary> 
        /// <remarks>
        /// Endpoint que permite la creación de un Empleado, de acuerdo a la siguiente información suminstrada:
        /// 
        /// Ejemplo:
        ///
        ///     POST Employees/{ID}
        ///     {
        ///         "name": "Nombre del Empleado",
        ///         "position": "Posición o Cargo",
        ///         "department": "Departamento o Área",
        ///         "salary": 1.2345,
        ///         "hiringDate": "Fecha de Contratación",
        ///         "isActive": "Estado del Empleado"
        ///     }
        /// 
        /// </remarks>
        /// <param name="EmployeeObj">Objeto de Tipo EmployeeObjModel.</param>
        /// <returns>Task.</returns>
        /// <response code="200"> OK: Se creó el Empleado, de acuerdo a la información suministrada.</response>
        /// <response code="400"> BadRequest: El Servidor NO puede procesar la petición, por favor verificar la información suministrada.</response>
        /// <response code="401"> Unauthorized: No se permite ejecutar la operación, NO Autorizado.</response>
        /// <response code="404"> Not Found: No se encuentra ningún Empleado Registrado o Activo.</response>
        /// <response code="500"> Internal Server Error: Error NO controlado.</response>
        [HttpPost]
        [Route("Employees/")]
        public async Task<ActionResult> Employees(EmployeeObjModel EmployeeObj)
        {
            Validations.ParamsIsValid();
            return await EmployeeLogic.OperationEmployeesParams(Init_Config, Validations, Dependencies, EnumTypeOperation.Post, null, EmployeeObj);
        }

        /// <summary>
        /// Endpoint que permite actualizar la información de un Empleado.
        /// </summary> 
        /// <remarks>
        /// Endpoint que permite la actualización de un Empleado, de acuerdo a la siguiente información suminstrada:
        /// 
        /// Ejemplo:
        ///
        ///     PUT Employees/{ID}
        ///     {
        ///         "name": "Nombre del Empleado",
        ///         "position": "Posición o Cargo",
        ///         "department": "Departamento o Área",
        ///         "salary": 1.2345,
        ///         "hiringDate": "Fecha de Contratación",
        ///         "isActive": "Estado del Empleado"
        ///     }
        /// 
        /// </remarks>
        /// <param name="ID">Objeto de Tipo Guid.</param>
        /// <param name="EmployeeObj">Objeto de Tipo EmployeeObjModel.</param>
        /// <returns>Task.</returns>
        /// <response code="200"> OK: Se actualizó el Empleado, de acuerdo a la información suministrada.</response>
        /// <response code="400"> BadRequest: El Servidor NO puede procesar la petición, por favor verificar la información suministrada.</response>
        /// <response code="401"> Unauthorized: No se permite ejecutar la operación, NO Autorizado.</response>
        /// <response code="404"> Not Found: No se encuentra ningún Empleado Registrado o Activo.</response>
        /// <response code="500"> Internal Server Error: Error NO controlado.</response>
        [HttpPut]
        [Route("Employees/{ID}")]
        public async Task<ActionResult> Employees(Guid ID, EmployeeObjModel EmployeeObj)
        {
            Validations.ParamsIsValid();
            return await EmployeeLogic.OperationEmployeesParams(Init_Config, Validations, Dependencies, EnumTypeOperation.Put, ID, EmployeeObj);
        }

        [HttpDelete]
        [Route("DeleteEmployees/{ID}")]
        public async Task<ActionResult> DeleteEmployees(Guid ID)
        {
            Validations.ParamsIsValid();
            return await EmployeeLogic.OperationEmployeesParams(Init_Config, Validations, Dependencies, EnumTypeOperation.Delete, ID);
        }
    }
}