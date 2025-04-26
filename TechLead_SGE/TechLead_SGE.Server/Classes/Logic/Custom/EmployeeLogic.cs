using Microsoft.AspNetCore.Mvc;
using TechLead_SGE.Server.BL.Classes.Config;
using TechLead_SGE.Server.Classes.Logic.Common;
using TechLead_SGE.Server.Domain.Contexts.Dependencies;
using TechLead_SGE.Server.Domain.DTOS.Controllers;
using TechLead_SGE.Server.Domain.DTOS.Data;
using TechLead_SGE.Server.Domain.Models.Controllers;
using static TechLead_SGE.Server.Domain.Models.Data.EnumTypesForApi;

namespace TechLead_SGE.Server.Classes.Logic.Custom
{
    /// <summary>
    /// Clase que permite dar manejo a la lógica transversal del Controlador de Employees.
    /// </summary>
    internal static class EmployeeLogic
    {
        /// <summary>
        /// Método que permite obtener los empleados de acuerdo a ciertos parámetros.
        /// </summary>
        /// <param name="Init_Config">Objeto de Tipo InitConfig.</param>
        /// <param name="Validations">Objeto de Tipo ValidationsInControllers.</param>
        /// <param name="Dependencies">Objeto de Tipo IDependenciesContext.</param>
        /// <param name="EmployeeID">Objeto de Tipo Guid.</param>
        /// <returns></returns>
        internal static async Task<ActionResult> GetEmployeesParams(InitConfig Init_Config, 
            ValidationsInControllers Validations, 
            IDependenciesContext Dependencies, 
            Guid? EmployeeID = null)
        {
            try
            {
                ParamsDataDto ParamsData = new()
                {
                    ActionsName = EnumActions.EmployeeActions,
                    ActionDetails = EnumActionsDetails.GetEmployees
                };

                if (ValidationGUID(EmployeeID))
                    ParamsData.ParamsData = [new() { ValueParam = null! }];
                else if (!ValidationGUID(EmployeeID))
                {
                    if (EmployeeID.IsValidGuid())
                        ParamsData.ParamsData = [new() { ValueParam = EmployeeID! }];
                    else
                    {
                        string Message = "Verifique la información suministrada, ya que contiene una Estructura Invalida..";
                        return Validations.ResultBadRequest(Message);
                    }
                }

                List<EmployeeDto> Employees = await Init_Config.dataService.GetObjects<EmployeeDto>(Dependencies, ParamsData);
                return ValidationsResultEmployees(Validations, Employees);
            }
            catch (Exception ex)
            {
                return Validations.CatchError(ex);
            }
        }

        /// <summary>
        /// Método que permite validar si el GUID proporcionado es nulo o no.
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <returns></returns>
        private static bool ValidationGUID(Guid? EmployeeID = null)
        {
            bool IsValid = false;

            if (EmployeeID == null)
                IsValid = false;
            else if (EmployeeID != null)
                IsValid = true;

            return IsValid;
        }
        /// <summary>
        /// Método que permite realizar la operación de los empleados de acuerdo a ciertos parámetros.
        /// </summary>
        /// <param name="Init_Config">Objeto de Tipo InitConfig.</param>
        /// <param name="Validations">Objeto de Tipo ValidationsInControllers.</param>
        /// <param name="Dependencies">Objeto de Tipo IDependenciesContext.</param>
        /// <param name="TypeOperation">Objeto de Tipo EnumTypeOperation.</param>
        /// <param name="EmployeeObj">Objetode Tipo EmployeeObjModel.</param>
        /// <param name="EmployeeID">Objeto de Tipo Guid.</param>
        /// <returns></returns>
        internal async static Task<ActionResult> OperationEmployeesParams(InitConfig Init_Config,
            ValidationsInControllers Validations,
            IDependenciesContext Dependencies,
            EnumTypeOperation TypeOperation,
            Guid? EmployeeID = null,
            EmployeeObjModel? EmployeeObj = null)
        {
            try
            {
                ParamsDataDto ParamsData = new()
                {
                    ActionsName = EnumActions.EmployeeActions
                };

                switch(TypeOperation)
                {
                    case EnumTypeOperation.Post:
                        ParamsData.ActionDetails = EnumActionsDetails.PostEmployee;
                        ParamsData.ParamsData = [new() { ValueParam = EmployeeObj! }];
                        break;
                    case EnumTypeOperation.Put:
                        ParamsData.ActionDetails = EnumActionsDetails.PutEmployee;
                        ParamsData.ParamsData = [new() { ValueParam = EmployeeID! }, new() { ValueParam = EmployeeObj! }];
                        break;
                    case EnumTypeOperation.Delete:
                        ParamsData.ActionDetails = EnumActionsDetails.DeleteEmployee;
                        ParamsData.ParamsData = [new() { ValueParam = EmployeeID! }];
                        break;
                }

                bool postObj = await Init_Config.dataService.PostObjects(Dependencies, ParamsData);

                return Validations.ValidateObjBoolResult(postObj, "No se pudo realizar la operació al listado de Control...");
            }
            catch (Exception ex)
            {
                return Validations.CatchError(ex);
            }
        }

        /// <summary>
        /// Métodoque permite realizar validaciones sobre el resultado de los Empleados.
        /// </summary>
        /// <param name="Validations">Objeto de Tipo ValidationsInControllers.</param>
        /// <param name="Employees">Objeto de Tipo Lista de EmployeeDto.</param>
        /// <returns>Objeto de Tipo ActionResult.</returns>
        private static ActionResult ValidationsResultEmployees(ValidationsInControllers Validations, List<EmployeeDto> Employees)
        {
            ActionResult actionResult = null!;

            string MessageError = "No se encuentra ningún Empleado Registrado o Activo...";

            if (Employees.Count > 1)
                actionResult = Validations.ValidateListObjResult(Employees, MessageError);
            else if(Employees.Count == 1)
                actionResult = Validations.ValidateObjResult(Employees[0], MessageError);

            return actionResult!;
        }

        /// <summary>
        /// Método que permite realizar una validación de si un string proporcionado es un GUID válido.
        /// </summary>
        /// <param name="EmployeeID">Objeto de Tipo Guid.</param>
        /// <returns>Bool.</returns>
        internal static bool IsValidGuid(this Guid? EmployeeID) => EmployeeID != Guid.Empty;
    }
}
