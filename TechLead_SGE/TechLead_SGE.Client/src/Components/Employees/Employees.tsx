/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */

// DEPENDENCIAS...
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
import { useEffect, useMemo, useRef, useState } from "react";
import LayoutDefault from "../../Layouts/LayoutDefault";
import { ApiService } from "../../Services/ApiServices/ApiServiceTechLeadSGE";
import EmployeeModal from "../Forms/Employees/EmployeeModal";
import ConfirmationDialog from "../Shared/ConfirmationDialog/ConfirmationDialog";
import "./Employees.css";
import { ProgressSpinner } from "primereact/progressspinner";

// COMPONENTE PRINCIPAL
// Este componente es el encargado de mostrar la lista de empleados y permitir la edición y eliminación de los mismos.
// Utiliza el componente DataTable de PrimeReact para mostrar la lista de empleados y el componente EmployeeModal para agregar o editar empleados.
// También utiliza el componente ConfirmationDialog para confirmar la eliminación de un empleado.
const Employees = () => {
    // ESTADOS
    const [employees, setEmployees] = useState<any[]>([]);
    const [globalFilter, setGlobalFilter] = useState<string | null>(null);
    const [isModalVisible, setIsModalVisible] = useState(false);
    const [selectedEmployee, setSelectedEmployee] = useState<any | null>(null);
    const [confirmationVisible, setConfirmationVisible] = useState(false);
    const [confirmationMessage, setConfirmationMessage] = useState("");
    const [confirmationAction, setConfirmationAction] = useState<() => Promise<void>>(async () => {});
    const [loading, setLoading] = useState(false);

    // REF
    const toast = useRef<Toast>(null);

    // FUNCIONES
    // Esta función se encarga de cargar la lista de empleados desde el servicio ApiService.    
    const fetchEmployees = async () => {
        setLoading(true);
        try {
            const data = await ApiService.getEmployee();
            setEmployees([...data]);
        } catch (error) {
            toast.current?.show({
                severity: "error",
                summary: "Error",
                detail: "No se pudo cargar la lista de empleados.",
                life: 3000,
            });
        } finally {
            setLoading(false);
        }
    };

    // Esta función se encarga de agregar un nuevo empleado a la lista de empleados.
    useEffect(() => {
        fetchEmployees();
    }, []);

    // Esta función se encarga de editar un empleado existente en la lista de empleados.
    const handleAddEmployee = (newEmployee: any) => {
        setEmployees((prev) => [...prev, { ...newEmployee, id: Date.now().toString() }]);
    };

    // Esta función se encarga de editar un empleado existente en la lista de empleados.
    const handleEditEmployee = async (updatedEmployee: any) => {
        await fetchEmployees();
    };

    // Esta función se encarga de abrir el modal para agregar un nuevo empleado.
    const openAddEmployeeModal = () => {
        setSelectedEmployee(null);
        setIsModalVisible(true);
    };

    // Esta función se encarga de abrir el modal para editar un empleado existente.
    const openEditEmployeeModal = (employee: any) => {
        setSelectedEmployee(employee);
        setIsModalVisible(true);
    };

    // Esta función se encarga de mostrar el modal de confirmación para desactivar o activar un empleado.
    // Recibe un mensaje y una acción como parámetros.  
    const showConfirmationDialog = (message: string, action: () => Promise<void>) => {
        setConfirmationMessage(message);
        setConfirmationVisible(true);
        setConfirmationAction(() => action);
    };

    // Esta función se encarga de desactivar un empleado existente en la lista de empleados.
    // Recibe el id del empleado como parámetro.
    const deactiveEmployee = async (id: string) => {
        showConfirmationDialog("¿Está seguro de desactivar este empleado?", async () => {
            try {
                await ApiService.deactivateEmployee(id);
                setEmployees((prev) => prev.map(emp => emp.id === id ? { ...emp, isActive: false } : emp));
                toast.current?.show({
                    severity: "warn",
                    summary: "Empleado Desactivado",
                    detail: "El empleado ha sido desactivado correctamente.",
                    life: 3000,
                });
            } catch (error) {
                toast.current?.show({
                    severity: "error",
                    summary: "Error",
                    detail: "No se pudo desactivar el empleado.",
                    life: 3000,
                });
            }
        });
    };

    // Esta función se encarga de activar un empleado existente en la lista de empleados.
    // Recibe el id del empleado como parámetro.
    const activeEmployee = async (id: string) => {
        showConfirmationDialog("¿Está seguro de activar este empleado?", async () => {
            try {
                const employee = employees.find((emp) => emp.id === id);
                if (!employee) return;
                await ApiService.activateEmployee(employee);
                setEmployees((prev) => prev.map(emp => emp.id === id ? { ...emp, isActive: true } : emp));
                toast.current?.show({
                    severity: "success",
                    summary: "Empleado Activado",
                    detail: "El empleado ha sido activado correctamente.",
                    life: 3000,
                });
            } catch (error) {
                toast.current?.show({
                    severity: "error",
                    summary: "Error",
                    detail: "No se pudo activar el empleado.",
                    life: 3000,
                });
            }
        });
    };

    // Esta función se encarga de renderizar el encabezado de la tabla de empleados.
    // Utiliza el hook useMemo para memorizar el encabezado y evitar que se vuelva a renderizar innecesariamente.
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

    // Esta función se encarga de renderizar las acciones de cada fila de la tabla de empleados.    
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

    // RENDERIZADO
    // El componente LayoutDefault es el contenedor principal del componente Employees.
    // Dentro de este contenedor se encuentran el Toast, el ConfirmationDialog y el EmployeeModal.
    return (
        <LayoutDefault>
            <Toast ref={toast} />
            <ConfirmationDialog
                visible={confirmationVisible}
                message={confirmationMessage}
                onConfirm={async () => {
                    await confirmationAction();
                    setConfirmationVisible(false);
                    setConfirmationAction(() => async () => {});
                }}
                onCancel={() => {
                    setConfirmationVisible(false);
                    setConfirmationAction(() => async () => {});
                }}
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
                                Información de los Empleados
                            </div>
                            <div className="DescriptionButtons">
                                <button
                                    className="refresh-button"
                                    onClick={fetchEmployees}
                                    title="Refrescar"
                                >
                                    <FontAwesomeIcon icon={faSyncAlt} />
                                </button>
                                <button
                                    className="add-employee-button"
                                    onClick={openAddEmployeeModal}
                                    title="Agregar Empleado"
                                >
                                    Agregar Empleado
                                </button>
                            </div>
                        </div>
                        <div className="content">
                            {loading ? (
                                <div style={{ display: "flex", justifyContent: "center", alignItems: "center", height: "300px" }}>
                                    <ProgressSpinner />
                                </div>
                            ) : (
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
                                        emptyMessage="No se encontraron empleados..."
                                    >
                                        <Column
                                            body={actionBodyTemplate}
                                            header="Acciones"
                                            style={{ width: "15%" }}
                                        ></Column>
                                        <Column
                                            field="name"
                                            header="Nombre"
                                            sortable
                                            style={{ width: "20%" }}
                                        ></Column>
                                        <Column
                                            field="position"
                                            header="Puesto"
                                            sortable
                                            style={{ width: "20%" }}
                                        ></Column>
                                        <Column
                                            field="department"
                                            header="Departamento"
                                            sortable
                                            style={{ width: "20%" }}
                                        ></Column>
                                        <Column
                                            field="salary"
                                            header="Salario"
                                            sortable
                                            body={(rowData) =>
                                                new Intl.NumberFormat("es-CO", {
                                                    style: "currency",
                                                    currency: "COP",
                                                }).format(rowData.salary)
                                            }
                                            style={{ width: "15%" }}
                                        ></Column>
                                        <Column
                                            field="hiringDate"
                                            header="Fecha de Contratación"
                                            sortable
                                            body={(rowData) =>
                                                new Date(rowData.hiringDate).toLocaleDateString()
                                            }
                                            style={{ width: "15%" }}
                                        ></Column>
                                        <Column
                                            field="isActive"
                                            header="Estado"
                                            sortable
                                            body={(rowData) => (
                                                <span
                                                    className={`status-span ${rowData.isActive ? "active" : "inactive"}`}
                                                >
                                                    {rowData.isActive ? "Activo" : "Inactivo"}
                                                </span>
                                            )}
                                            style={{ width: "20%" }}
                                        ></Column>
                                    </DataTable>
                                </div>
                            )}
                        </div>
                    </div>
                </div>
            </div>
        </LayoutDefault>
    );
};

export default Employees;