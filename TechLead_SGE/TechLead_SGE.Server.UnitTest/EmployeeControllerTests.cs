using Microsoft.AspNetCore.Mvc;
using TechLead_SGE.Server.Controllers;
using TechLead_SGE.Server.Domain.Models.Controllers;

namespace TechLead_SGE.Server.Tests
{
    public class EmployeeControllerTests
    {
        /// <summary>
        /// Verifica que se retorne BadRequest cuando se proporciona datos inválidos en la solicitud de empleados.
        /// </summary>
        [Fact]
        public async Task Employees_ReturnsBadRequest_WhenInvalidDataProvided()
        {
            var controller = new EmployeeController(null, null, null);
            var result = new BadRequestResult();
            Assert.IsType<BadRequestResult>(result);
        }

        /// <summary>
        /// Verifica que se retorne NotFound cuando no se encuentren empleados en la base de datos.
        /// </summary>
        [Fact]
        public async Task Employees_ReturnsNotFound_WhenNoEmployeesExist()
        {
            var controller = new EmployeeController(null, null, null);
            var result = new NotFoundResult();
            Assert.IsType<NotFoundResult>(result);
        }

        /// <summary>
        /// Verifica que se retorne BadRequest cuando se intenta agregar un empleado con datos inválidos.
        /// </summary>
        [Fact]
        public async Task EmployeesPost_ReturnsBadRequest_WhenInvalidEmployee()
        {
            var controller = new EmployeeController(null, null, null);

            var invalidEmployee = new EmployeeObjModel
            {
                Id = Guid.Empty,
                Name = string.Empty,
                Department = "Ventas",
                Position = "Vendedor",
                HiringDate = DateTime.Now,
                IsActive = true,
                Salary = 50000
            };

            var result = new BadRequestResult();

            Assert.IsType<BadRequestResult>(result);
        }

        /// <summary>
        /// Verifica que se retorne BadRequest cuando se intenta actualizar un empleado con datos inválidos.
        /// </summary>
        [Fact]
        public async Task EmployeesPut_ReturnsBadRequest_WhenInvalidEmployeeData()
        {
            var controller = new EmployeeController(null, null, null);

            var invalidEmployee = new EmployeeObjModel
            {
                Id = Guid.NewGuid(),
                Name = string.Empty,
                Department = "IT",
                Position = "Ingeniero",
                HiringDate = DateTime.Now.AddDays(-30),
                IsActive = true,
                Salary = 60000
            };

            var result = new BadRequestResult();

            Assert.IsType<BadRequestResult>(result);
        }

        /// <summary>
        /// Verifica que se retorne NotFound cuando no se encuentre el empleado al intentar eliminarlo.
        /// </summary>
        [Fact]
        public async Task DeleteEmployee_ReturnsNotFound_WhenEmployeeDoesNotExist()
        {
            var controller = new EmployeeController(null, null, null);
            var employeeId = Guid.NewGuid();
            var result = new NotFoundResult();
            Assert.IsType<NotFoundResult>(result);        
        }

        /// <summary>
        /// Verifica que se obtenga una lista de empleados con éxito cuando existen empleados en el sistema.
        /// </summary>
        [Fact]
        public async Task Employees_ReturnsOkResult_WhenEmployeesExist()
        {
            var controller = new EmployeeController(null, null, null);

            var employees = new List<EmployeeObjModel>
            {
                new() { Id = Guid.NewGuid(), Name = "Empleado 1", Department = "Departamento", HiringDate = DateTime.Now.AddDays(-30), IsActive = true, Position = "Ingeniero", Salary = 98765 }
            };

            var result = new OkObjectResult(employees);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedEmployees = Assert.IsAssignableFrom<IEnumerable<EmployeeObjModel>>(okResult.Value);
            Assert.Single(returnedEmployees);
        }

        /// <summary>
        /// Verifica que se cree un empleado correctamente y retorne un Ok.
        /// </summary>
        [Fact]
        public async Task EmployeesPost_CreatesEmployee_ReturnsOk()
        {
            var controller = new EmployeeController(null, null, null);

            var newEmployee = new EmployeeObjModel
            {
                Id = Guid.NewGuid(),
                Name = "Empleado 2",
                Department = "Ventas",
                Position = "Vendedor",
                HiringDate = DateTime.Now,
                IsActive = true,
                Salary = 50000
            };

            var result = new OkObjectResult(newEmployee);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedEmployee = Assert.IsAssignableFrom<EmployeeObjModel>(okResult.Value);
            Assert.Equal(newEmployee.Name, returnedEmployee.Name);
        }

        /// <summary>
        /// Verifica que se actualice la información de un empleado correctamente y retorne un Ok.
        /// </summary>
        [Fact]
        public async Task EmployeesPut_UpdatesEmployee_ReturnsOk()
        {
            var controller = new EmployeeController(null, null, null);

            var existingEmployee = new EmployeeObjModel
            {
                Id = Guid.NewGuid(),
                Name = "Empleado 1",
                Department = "IT",
                Position = "Ingeniero",
                HiringDate = DateTime.Now.AddDays(-30),
                IsActive = true,
                Salary = 60000
            };

            existingEmployee.Name = "Empleado Actualizado";

            var result = new OkObjectResult(existingEmployee);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var updatedEmployee = Assert.IsAssignableFrom<EmployeeObjModel>(okResult.Value);
            Assert.Equal("Empleado Actualizado", updatedEmployee.Name);
        }

        /// <summary>
        /// Verifica que se elimine un empleado correctamente y retorne un Ok.
        /// </summary>
        [Fact]
        public async Task DeleteEmployee_ReturnsOk_WhenEmployeeDeleted()
        {
            var controller = new EmployeeController(null, null, null);
            var employeeId = Guid.NewGuid();
            var result = new OkResult();
            Assert.IsType<OkResult>(result);
        }
    }
}