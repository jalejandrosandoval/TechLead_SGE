/* eslint-disable @typescript-eslint/no-explicit-any */
import { faInfoCircle } from "@fortawesome/free-solid-svg-icons";
import { faCheckCircle } from "@fortawesome/free-solid-svg-icons/faCheckCircle";
import { faEdit } from "@fortawesome/free-solid-svg-icons/faEdit";
import { faMinusCircle } from "@fortawesome/free-solid-svg-icons/faMinusCircle";
import { faSyncAlt } from "@fortawesome/free-solid-svg-icons/faSyncAlt";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import "primeicons/primeicons.css";
import { Column } from "primereact/column";
import { DataTable } from "primereact/datatable";
import "primereact/resources/primereact.min.css";
import "primereact/resources/themes/saga-blue/theme.css";
import { Toast } from "primereact/toast";
import { useMemo, useRef, useState } from "react";
import LayoutDefault from "../../Layouts/LayoutDefault";
import EmployeeModal from "../Forms/Employees/EmployeeModal";
import ConfirmationDialog from "../Shared/ConfirmationDialog/ConfirmationDialog";
import "./Employees.css";
import { employeesData } from "./EmployeesDataExample";

const Employees = () => {

    const [employees, setEmployees] = useState(employeesData);

    const [globalFilter, setGlobalFilter] = useState<string | null>(null);
    const [isModalVisible, setIsModalVisible] = useState(false);
    const [selectedEmployee, setSelectedEmployee] = useState<any | null>(null);
    const [confirmationVisible, setConfirmationVisible] = useState(false);
    const [confirmationMessage, setConfirmationMessage] = useState("");
    const [confirmationAction, setConfirmationAction] = useState<() => void>(() => { });

    const toast = useRef<Toast>(null);

    const updateEmployeeState = (id: string, updates: Partial<any>) => {
        setEmployees((prev) =>
            prev.map((employee) => (employee.id === id ? { ...employee, ...updates } : employee))
        );
    };

    const handleAddEmployee = (newEmployee: any) => {
        setEmployees((prev) => [...prev, { ...newEmployee, id: Date.now().toString() }]);
    };

    const handleEditEmployee = (updatedEmployee: any) => {
        updateEmployeeState(updatedEmployee.id, updatedEmployee);
    };

    const openAddEmployeeModal = () => {
        setSelectedEmployee(null);
        setIsModalVisible(true);
    };

    const openEditEmployeeModal = (employee: any) => {
        setSelectedEmployee(employee);
        setIsModalVisible(true);
    };

    const showConfirmationDialog = (message: string, action: () => void) => {
        setConfirmationMessage(message);
        setConfirmationVisible(true);
        setConfirmationAction(() => action);
    };

    const deactiveEmployee = (id: string) => {
        showConfirmationDialog("¿Está seguro de desactivar este empleado?", () => {
            updateEmployeeState(id, { isActive: false });
            toast.current?.show({
                severity: "warn",
                summary: "Empleado Desactivado",
                detail: "El empleado ha sido desactivado correctamente.",
                life: 3000,
            });
        });
    };

    const activeEmployee = (id: string) => {
        showConfirmationDialog("¿Está seguro de activar este empleado?", () => {
            updateEmployeeState(id, { isActive: true });
            toast.current?.show({
                severity: "success",
                summary: "Empleado Activado",
                detail: "El empleado ha sido activado correctamente.",
                life: 3000,
            });
        });
    };

    const renderHeader = useMemo(() => {
        return (
            <div className="table-header search-container">
                <span className="p-input-icon-left">
                    <i className="pi pi-search search-icon" />
                    <input
                        type="text"
                        placeholder="Buscar empleados..."
                        className="p-inputtext p-component search-input"
                        onChange={(e) => setGlobalFilter(e.target.value)}
                    />
                </span>
            </div>
        );
    }, []);

    const actionBodyTemplate = useMemo(
        () => (rowData: any) => (
            <>
                <FontAwesomeIcon
                    icon={faEdit}
                    className="icon edit-icon"
                    title="Editar"
                    onClick={() => openEditEmployeeModal(rowData)}
                />
                {rowData.isActive ? (
                    <FontAwesomeIcon
                        icon={faMinusCircle}
                        className="icon deactive-icon"
                        title="Desactivar"
                        onClick={() => deactiveEmployee(rowData.id)}
                    />
                ) : (
                    <FontAwesomeIcon
                        icon={faCheckCircle}
                        className="icon active-icon"
                        title="Activar"
                        onClick={() => activeEmployee(rowData.id)}
                    />
                )}
            </>
        ),
        [employees]
    );

    return (
        <LayoutDefault>
            <Toast ref={toast}/>
            <ConfirmationDialog
                visible={confirmationVisible}
                message={confirmationMessage}
                onConfirm={() => {
                    confirmationAction();
                    setConfirmationVisible(false);
                }}
                onCancel={() => setConfirmationVisible(false)}
            />
            <EmployeeModal
                visible={isModalVisible}
                onHide={() => setIsModalVisible(false)}
                onSaveEmployee={(employee) => {
                    if (selectedEmployee) {
                        handleEditEmployee(employee);
                    } else {
                        handleAddEmployee(employee);
                    }
                }}
                employee={selectedEmployee}
            />
            <div className="ContainerEmp">
                <div className="TitleCenterEmp">
                    <h2>Empleados</h2>
                </div>
                <div className="content-container-emp">
                    <div className="content-emp">
                        <div className="content-header-emp">
                            <div className="DescriptionTitleEmp">
                                <FontAwesomeIcon
                                    icon={faInfoCircle}
                                    className="icon IconDescriptionTitleEmp"
                                />
                                Información de los Empleados...
                            </div>
                            <div className="DescriptionButtons">
                                <button
                                    className="refresh-button"
                                    onClick={() => setEmployees([...employeesData])}
                                    title="Refrescar"
                                    >
                                    <FontAwesomeIcon icon={faSyncAlt} />
                                </button>
                                <button
                                    className="add-employee-button"
                                    onClick={openAddEmployeeModal}
                                >
                                    Agregar Empleado
                                </button>
                            </div>
                        </div>
                        <div className="content">
                            <div className="clsContainerTable">
                                <DataTable
                                    value={employees}
                                    paginator={employees.length > 10}
                                    rows={10}
                                    header={renderHeader}
                                    globalFilter={globalFilter}
                                    scrollable
                                    scrollHeight="400px"
                                    tableStyle={{ minWidth: "60rem" }}
                                    emptyMessage="No se encontraron empleados."
                                >
                                    <Column
                                        body={actionBodyTemplate}
                                        header=""
                                        style={{ width: "15%" }}
                                    ></Column>
                                    <Column
                                        field="name"
                                        header="Nombre"
                                        style={{ width: "20%" }}
                                    ></Column>
                                    <Column
                                        field="position"
                                        header="Puesto"
                                        style={{ width: "20%" }}
                                    ></Column>
                                    <Column
                                        field="department"
                                        header="Departamento"
                                        style={{ width: "20%" }}
                                    ></Column>
                                    <Column
                                        field="salary"
                                        header="Salario"
                                        body={(rowData) =>
                                            `$${rowData.salary.toLocaleString()}`
                                        }
                                        style={{ width: "15%" }}
                                    ></Column>
                                    <Column
                                        field="hiringDate"
                                        header="Fecha de Contratación"
                                        body={(rowData) =>
                                            new Date(rowData.hiringDate).toLocaleDateString()
                                        }
                                        style={{ width: "15%" }}
                                    ></Column>
                                    <Column
                                        field="isActive"
                                        header="Estado"
                                        body={(rowData) => (
                                            <span
                                                className={`status-span ${rowData.isActive ? "active" : "inactive"
                                                    }`}
                                            >
                                                {rowData.isActive ? "Activo" : "Inactivo"}
                                            </span>
                                        )}
                                        style={{ width: "20%" }}
                                    ></Column>
                                </DataTable>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </LayoutDefault>
    );
};

export default Employees;