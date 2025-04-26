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