// Modelo de datos para un empleado
// Este modelo define la estructura de un empleado en la aplicación. Contiene propiedades como id, name, position, department, salary, hiringDate y isActive.
// Estas propiedades representan la información básica de un empleado, como su identificador, nombre, puesto, departamento, salario, fecha de contratación y estado activo.
// // El constructor inicializa estas propiedades con valores predeterminados. Por ejemplo, el id se inicializa como una cadena vacía, el nombre como una cadena vacía, el salario como 0 y la fecha de contratación como la fecha actual en formato ISO.
// // La propiedad isActive se inicializa como true, lo que indica que el empleado está activo por defecto.
// // Este modelo se utiliza en la aplicación para representar y gestionar la información de los empleados.
export class Employee {
    id: string;
    name: string;
    position: string;
    department: string;
    salary: number;
    hiringDate: string;
    isActive: boolean;

    constructor() {
        this.id = "";
        this.name = "";
        this.position = "";
        this.department = "";
        this.salary = 0;
        this.hiringDate = new Date().toISOString().split("T")[0];
        this.isActive = true;
    }
}