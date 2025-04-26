import { Dialog } from "primereact/dialog";
import { Toast } from "primereact/toast";
import { useEffect, useRef, useState, useMemo } from "react";
import ConfirmationDialog from "../../Shared/ConfirmationDialog/ConfirmationDialog";
import "./EmployeeModal.css";

const defaultFormData: Employee = {
    name: "",
    position: "",
    department: "",
    salary: "",
    hiringDate: "",
};

const EmployeeModal: React.FC<EmployeeModalProps> = ({ visible, onHide, onSaveEmployee, employee }) => {
    const [formData, setFormData] = useState<Employee>(defaultFormData);
    const [isConfirmationVisible, setIsConfirmationVisible] = useState(false);
    const toast = useRef<Toast>(null);

    useEffect(() => {
        setFormData(employee || defaultFormData);
    }, [employee]);

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { id, value } = e.target;
        setFormData((prev) => ({ ...prev, [id]: value }));
    };

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        if (employee) {
            setIsConfirmationVisible(true);
        } else {
            onSaveEmployee(formData);
            toast.current?.show({
                severity: "success",
                summary: "Exito",
                detail: "Empleado agregado correctamente...",
                life: 3000,
            });
            setFormData(defaultFormData);
            onHide();
        }
    };

    const handleConfirmSave = () => {
        onSaveEmployee(formData);
        toast.current?.show({
            severity: "success",
            summary: "Exito",
            detail: "Empleado actualizado correctamente...",
            life: 3000,
        });
        setIsConfirmationVisible(false);
        onHide();
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
                                className="form-control"
                                value={formData.name}
                                onChange={handleInputChange}
                                required
                            />
                        </div>
                        <div className="form-group col-6">
                            <label htmlFor="position">Puesto:</label>
                            <input
                                type="text"
                                id="position"
                                className="form-control"
                                value={formData.position}
                                onChange={handleInputChange}
                                required
                            />
                        </div>
                    </div>
                    <div className="form-row">
                        <div className="form-group col-6">
                            <label htmlFor="department">Departamento:</label>
                            <input
                                type="text"
                                id="department"
                                className="form-control"
                                value={formData.department}
                                onChange={handleInputChange}
                                required
                            />
                        </div>
                        <div className="form-group col-6">
                            <label htmlFor="salary">Salario:</label>
                            <input
                                type="number"
                                id="salary"
                                className="form-control"
                                value={formData.salary}
                                onChange={handleInputChange}
                                required
                            />
                        </div>
                    </div>
                    <div className="form-row">
                        <div className="form-group col-6">
                            <label htmlFor="hiringDate">Fecha de Contratación:</label>
                            <input
                                type="date"
                                id="hiringDate"
                                className="form-control"
                                value={formData.hiringDate}
                                onChange={handleInputChange}
                                required
                            />
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
                onConfirm={handleConfirmSave}
                onCancel={() => setIsConfirmationVisible(false)}
            />
        </>
    );
};

export default EmployeeModal;