import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models';
import { EmployeeService } from 'src/app/services';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss'],
})
export class EmployeeComponent implements OnInit {
  employees: Employee[] = [];
  employee: Employee | null = null;
  errorMessage: string = '';
  showMode: 'list' | 'single' = 'list';
  loading = false;
  constructor(private employeeService: EmployeeService) {}

  ngOnInit(): void {
    this.fetchEmployees();
  }

  fetchEmployees(): void {
    this.loading = true;
    this.errorMessage = "";
    this.employeeService.getEmployees().subscribe(
      (employees) => {
        this.employees = employees;
        this.loading = false;
      },
      ({error}) => {
        this.errorMessage = `Error consultando el listado de empleados: ${error}`;
        this.loading = false;
      },
    );
  }

  onSearchEmployee(employeeId: number): void {
    this.showMode = employeeId ? 'single' : 'list';
    this.errorMessage = "";
    this.employee = null;
    if (employeeId) {
      this.loading = true;
      this.employeeService.getEmployeeById(employeeId).subscribe(
        (employee) => {
          if (employee) {
            this.employee = employee;
          } else {
            this.employee = null;
            this.errorMessage = 'Employee not found';
          }
          this.loading = false;
        },
        ({ error }) => {
          this.errorMessage = `Error consultando empleado con ID ${employeeId}: ${error}`;
          this.loading = false;
        },
      );
    } else {
      this.fetchEmployees();
    }
  }
}
