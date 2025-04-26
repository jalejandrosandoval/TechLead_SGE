import { Employee } from "../Models/Employee";

export interface IEmployeeModalProps {
    visible: boolean;
    onHide: () => void;
    onSaveEmployee: (employee: Employee) => void;
    employee?: Employee | null;
}