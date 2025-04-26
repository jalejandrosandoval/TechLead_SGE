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
