using System.Reflection;
using TechLead_SGE.Server.Domain.Entities.Controllers;
using TechLead_SGE.Server.Domain.Entities.Excepctions;
using TechLead_SGE.Server.Domain.Interfaces.Data;

namespace TechLead_SGE.Server.BL.Classes.Data.Actions
{
    /// <summary>
    /// Clase que permite realizar diferentes acciones hacia la BD para los Empleados.
    /// </summary>
    /// <param name="Actions">Objeto de tipo Actions.</param>
    public class EmployeeActions(IContextData Actions)
    {
        /// <summary>
        /// Método que permite retornar un listado de todos los Empleados.
        /// </summary>
        /// <returns>Lista de Objetos.</returns>
        /// <param name="EmployeeID">Objeto de Tipo Guid.</param>
        /// <exception cref="ApiException">Obtiene una excepción si el PA falla o retorna algún error.</exception>
        internal List<object> GetEmployees(Guid? EmployeeID = null)
        {
            try
            {
                List<object> Employees = [];

                if(EmployeeID == null)
                    Employees = [.. Actions.Dependencies.Context!.Employees.OrderBy(emp => emp.Name)];
                else if(EmployeeID != null)
                    Employees =  [Actions.Dependencies.Context!.Employees.Find(EmployeeID)];

                return Employees;
            }
            catch (Exception ex)
            {
                Actions.Validations = new(MethodBase.GetCurrentMethod()!.Name, ex);
                throw new ApiException(Actions.Validations.MessageException);
            }
        }

        /// <summary>
        /// Método que permite insertar la información de un Empleado.
        /// </summary>
        /// <param name="EmployeeData">Objeto de Tipo EmployeeEntitie.</param>
        /// <returns>Bool.</returns>
        /// <exception cref="ApiException">Obtiene una excepción si el PA falla o retorna algún error.</exception>
        internal bool PostEmployee(EmployeeEntitie EmployeeData)
        {
            try
            {
                EmployeeData.Id = Guid.NewGuid();
                EmployeeData.HiringDate = DateTime.UtcNow;
                EmployeeData.IsActive = true;

                Actions.Dependencies.Context!.Employees.Add(EmployeeData);
                Actions.Dependencies.Context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Actions.Validations = new(MethodBase.GetCurrentMethod()!.Name, ex);
                throw new ApiException(Actions.Validations.MessageException);
            }
        }

        /// <summary>
        /// Método que permite insertar la información de un Empleado.
        /// </summary>
        /// <param name="EmployeeID">Objeto de Tipo Guid.</param>
        /// <param name="EmployeeData">Objeto de Tipo EmployeeEntitie.</param>
        /// <returns>Bool.</returns>
        /// <exception cref="ApiException">Obtiene una excepción si el PA falla o retorna algún error.</exception>
        internal bool PutEmployee(Guid EmployeeID, EmployeeEntitie EmployeeData)
        {
            try
            {
                EmployeeEntitie Employee = Actions.Dependencies.Context!.Employees.Find(EmployeeID)!;

                if (Employee! == null)
                    throw new Exception("Empleado no encontrado...");

                Employee.Name = EmployeeData.Name;
                Employee.Position = EmployeeData.Position;
                Employee.Department = EmployeeData.Department;
                Employee.Salary = EmployeeData.Salary;
                Employee.HiringDate = EmployeeData.HiringDate;
                Employee.IsActive = EmployeeData.IsActive;

                Actions.Dependencies.Context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Actions.Validations = new(MethodBase.GetCurrentMethod()!.Name, ex);
                throw new ApiException(Actions.Validations.MessageException);
            }
        }

        /// <summary>
        /// Método que permite Eliminar o Desactivar un Empleado.
        /// </summary>
        /// <param name="EmployeeID">Objeto de Tipo Guid.</param>
        /// <returns>Bool.</returns>
        /// <exception cref="ApiException"></exception>
        internal bool DeleteEmployee(Guid EmployeeID)
        {
            try
            {
                EmployeeEntitie Employee = Actions.Dependencies.Context!.Employees.Find(EmployeeID)!;

                if(Employee! == null)
                    throw new Exception("Empleado no encontrado.");

                Employee.IsActive = false;

                Actions.Dependencies.Context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Actions.Validations = new(MethodBase.GetCurrentMethod()!.Name, ex);
                throw new ApiException(Actions.Validations.MessageException);
            }
        }
    }
}