/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
// dependecias
import axios , { AxiosRequestConfig } from "axios";
import { Employee } from "../../Models/Employee";

// URL base de la API
const BASE_URL = "http://localhost:5043";
// Configuración de axios
axios.defaults.headers.common["Content-Type"] = "application/json";

// Servicio de API
// Este servicio se encarga de realizar las peticiones HTTP a la API. Contiene métodos para realizar operaciones CRUD (Crear, Leer, Actualizar y Eliminar) sobre los empleados.
export const ApiService = {
    get: async (endpoint: string, config?: AxiosRequestConfig) => {
        const response = await axios.get(`${BASE_URL}${endpoint}`, config);
        return response.data;
    },
    post: async (endpoint: string, data: any, config?: AxiosRequestConfig) => {
        const response = await axios.post(`${BASE_URL}${endpoint}`, data, config);
        return response.data;
    },
    put: async (endpoint: string, data: any, config?: AxiosRequestConfig) => {
        const response = await axios.put(`${BASE_URL}${endpoint}`, data, config);
        return response.data;
    },
    delete: async (endpoint: string, config?: AxiosRequestConfig) => {
        const response = await axios.delete(`${BASE_URL}${endpoint}`, config);
        return response.data;
    },
    getEmployee: async () => {
        return await ApiService.get("/employees");
    },
    createEmployee: async (employee: Employee): Promise<Employee> => {
        const { id, ...employeeData } = employee;
        return await ApiService.post(`/employees`, employeeData);
    },
    updateEmployee: async (employee: Employee): Promise<Employee> => {
        const { id, ...employeeData } = employee;
        if (!employee.id) {
            throw new Error("El empleado debe tener un ID para ser actualizado.");
        }
        return await ApiService.put(`/employees/${employee.id}`, employeeData);
    },
    activateEmployee: async (employee: Employee) => {
        if (employee.id) {
            employee.isActive = true;
            return await ApiService.put(`/employees/${employee.id}`, employee);
        }
    },
    deactivateEmployee: async (id: string) => {
        return await ApiService.delete(`/deleteemployees/${id}`);
    }
};