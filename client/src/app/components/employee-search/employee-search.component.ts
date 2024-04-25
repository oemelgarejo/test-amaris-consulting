import { Component } from '@angular/core';
import { Employee } from 'src/app/models';
import { EmployeeService } from 'src/app/services';

@Component({
  selector: 'app-employee-search',
  templateUrl: './employee-search.component.html',
  styleUrls: ['./employee-search.component.scss']
})
export class EmployeeSearchComponent {
  employees: Employee[] = [];
  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.getEmployees();
  }

  getEmployees(): void {
    this.employeeService.getEmployees()
      .subscribe(employees => this.employees = employees);
  }

  searchEmployeeById(id: number): void {
    if (id) {
      this.employeeService.getEmployeeById(id)
        .subscribe(employee => {
          this.employees = employee ? [employee] : [];
        });
    } else {
      this.getEmployees();
    }
  }
}
