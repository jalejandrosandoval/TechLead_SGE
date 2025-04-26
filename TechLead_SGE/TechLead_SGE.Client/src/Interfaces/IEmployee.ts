// Dependencias
import { Employee } from "../Models/Employee";

// Este interface para el modal de empleado
// Define las propiedades que se esperan recibir en el componente del modal de empleado
// visible: un booleano que indica si el modal debe mostrarse o no.
// onHide: una función que se ejecuta para ocultar el modal.
// onSaveEmployee: una función que se ejecuta para guardar el empleado.
// employee: un objeto de tipo Employee que representa al empleado actual. Puede ser nulo si no hay empleado seleccionado.
// El componente del modal de empleado utiliza estas propiedades para mostrar y gestionar la información del empleado.
export interface IEmployeeModalProps {
    visible: boolean;
    onHide: () => void;
    onSaveEmployee: (employee: Employee) => void;
    employee?: Employee | null;
}