/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
/* eslint-disable react-refresh/only-export-components */
import { Dialog } from "primereact/dialog";
import { Toast } from "primereact/toast";
import { useEffect, useMemo, useRef, useState } from "react";
import { Employee } from "../../../Models/Employee";
import { ApiService } from "../../../Services/ApiServices/ApiServiceTechLeadSGE";
import ConfirmationDialog from "../../Shared/ConfirmationDialog/ConfirmationDialog";
import "./EmployeeModal.css";
import { IEmployeeModalProps } from "../../../Interfaces/IEmployee";

const defaultFormData: Employee = new Employee();

export const EmployeeValidation = {
    validateName: (name: string): string | null => {
        if (name.length < 8 || name.length > 100) {
            return "El nombre debe tener entre 8 y 100 caracteres.";
        }
        return null;
    },
    validatePosition: (position: string): string | null => {
        if (position.length < 3 || position.length > 50) {
            return "El puesto debe tener entre 3 y 50 caracteres.";
        }
        return null;
    },
    validateDepartment: (department: string): string | null => {
        if (department.length < 2 || department.length > 50) {
            return "El departamento debe tener entre 2 y 50 caracteres.";
        }
        return null;
    },
    validateSalary: (salary: number): string | null => {
        if (salary < 0) {
            return "El salario debe ser mayor o igual a 0.";
        }
        return null;
    },
    validateHiringDate: (hiringDate: string): string | null => {
        const parsedDate = new Date(hiringDate);
        if (isNaN(parsedDate.getTime())) {
            return "La fecha de contratación no es válida.";
        }
        return null;
    },
};

const EmployeeModal: React.FC<IEmployeeModalProps> = ({ visible, onHide, onSaveEmployee, employee }) => {
    const [formData, setFormData] = useState<Employee>(defaultFormData);
    const [isConfirmationVisible, setIsConfirmationVisible] = useState(false);
    const [formErrors, setFormErrors] = useState<any>({});
    const toast = useRef<Toast>(null);

    useEffect(() => {
        if (employee) {
            setFormData((prev) => ({
                ...prev,
                ...employee,
                hiringDate: employee.hiringDate
                    ? formatDateToYYYYMMDD(employee.hiringDate)
                    : "",
            }));
        } else {
            setFormData(defaultFormData);
        }
    }, [employee]);    

    const formatDateToYYYYMMDD = (date: string | Date): string => {
        const parsedDate = new Date(date);
        if (isNaN(parsedDate.getTime())) {
            return "";
        }
        const year = parsedDate.getFullYear();
        const month = String(parsedDate.getMonth() + 1).padStart(2, "0");
        const day = String(parsedDate.getDate()).padStart(2, "0");
        return `${year}-${month}-${day}`;
    };

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { id, value } = e.target;
        setFormData((prev) => ({
            ...prev,
            [id]: id === "salary" ? parseFloat(value) || 0 : value
        }));
    };

    const validateForm = (): boolean => {
        const errors: any = {};
        errors.name = EmployeeValidation.validateName(formData.name);
        errors.position = EmployeeValidation.validatePosition(formData.position);
        errors.department = EmployeeValidation.validateDepartment(formData.department);
        errors.salary = EmployeeValidation.validateSalary(formData.salary);
        errors.hiringDate = EmployeeValidation.validateHiringDate(formData.hiringDate);

        setFormErrors(errors);

        // Retorna verdadero si no hay errores
        return Object.values(errors).every((error) => error === null);
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        if (!validateForm()) return; // Si hay errores, no continúa

        const dataToSend = { ...formData };

        // Eliminar la propiedad 'id' si estamos creando un nuevo empleado
        if (!employee) {
            delete dataToSend.id;
        }

        try {
            if (employee) {                
                await ApiService.updateEmployee(dataToSend);
                toast.current?.show({
                    severity: "success",
                    summary: "Éxito",
                    detail: "Empleado actualizado correctamente...",
                    life: 3000,
                });
            } else {                
                await ApiService.createEmployee(dataToSend);
                toast.current?.show({
                    severity: "success",
                    summary: "Éxito",
                    detail: "Empleado agregado correctamente...",
                    life: 3000,
                });
            }
            onSaveEmployee(dataToSend); 
            setFormData(defaultFormData); 
            onHide(); 
        } catch (error) {
            toast.current?.show({
                severity: "error",
                summary: "Error",
                detail: "No se pudo guardar el empleado.",
                life: 3000,
            });
        }
    };


    const renderFooter = useMemo(
        () => (
            <div className="dialog-footer">
                <button type="button" className="btn btn-secondary" onClick={onHide}>
                    Cancelar
                </button>
                <button type="submit" className="btn btn-primary" form="employee-form">
                    Guardar
                </button>
            </div>
        ),
        [onHide]
    );

    return (
        <>
            <Toast ref={toast} />
            <Dialog
                header={employee ? "Editar Empleado..." : "Agregar Empleado..."}
                visible={visible}
                style={{ width: "50vw" }}
                onHide={onHide}
                footer={renderFooter}
                breakpoints={{ "960px": "75vw", "640px": "100vw" }}
                closable
                className={`${employee ? "edit-mode" : "add-mode"}`}
                aria-label="Cerrar diálogo"
            >
                <form id="employee-form" onSubmit={handleSubmit}>
                    <div className="form-row">
                        <div className="form-group col-6">
                            <label htmlFor="name">Nombre:</label>
                            <input
                                type="text"
                                id="name"
                                className={`form-control ${formErrors.name ? "is-invalid" : ""}`}
                                value={formData.name}
                                onChange={handleInputChange}
                                required
                            />
                            {formErrors.name && <div className="invalid-feedback">{formErrors.name}</div>}
                        </div>
                        <div className="form-group col-6">
                            <label htmlFor="position">Puesto:</label>
                            <input
                                type="text"
                                id="position"
                                className={`form-control ${formErrors.position ? "is-invalid" : ""}`}
                                value={formData.position}
                                onChange={handleInputChange}
                                required
                            />
                            {formErrors.position && <div className="invalid-feedback">{formErrors.position}</div>}
                        </div>
                    </div>
                    <div className="form-row">
                        <div className="form-group col-6">
                            <label htmlFor="department">Departamento:</label>
                            <input
                                type="text"
                                id="department"
                                className={`form-control ${formErrors.department ? "is-invalid" : ""}`}
                                value={formData.department}
                                onChange={handleInputChange}
                                required
                            />
                            {formErrors.department && <div className="invalid-feedback">{formErrors.department}</div>}
                        </div>
                        <div className="form-group col-6">
                            <label htmlFor="salary">Salario:</label>
                            <input
                                type="number"
                                id="salary"
                                className={`form-control ${formErrors.salary ? "is-invalid" : ""}`}
                                value={formData.salary}
                                onChange={handleInputChange}
                                required
                            />
                            {formErrors.salary && <div className="invalid-feedback">{formErrors.salary}</div>}
                        </div>
                    </div>
                    <div className="form-row">
                        <div className="form-group col-6">
                            <label htmlFor="hiringDate">Fecha de Contratación:</label>
                            <input
                                type="date"
                                id="hiringDate"
                                className={`form-control ${formErrors.hiringDate ? "is-invalid" : ""}`}
                                value={formData.hiringDate}
                                onChange={handleInputChange}
                                required
                            />
                            {formErrors.hiringDate && <div className="invalid-feedback">{formErrors.hiringDate}</div>}
                        </div>
                    </div>
                </form>
            </Dialog>
            <ConfirmationDialog
                visible={isConfirmationVisible}
                message={
                    <div>
                        <h3>Confirmación</h3>
                        <p>¿Estás seguro de que deseas guardar los cambios?</p>
                    </div>
                }
                onConfirm={handleSubmit}
                onCancel={() => setIsConfirmationVisible(false)}
            />
        </>
    );
};

export default EmployeeModal;