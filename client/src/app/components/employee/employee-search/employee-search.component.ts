import { Component, EventEmitter, Output } from '@angular/core';
import { Employee } from 'src/app/models';
import { EmployeeService } from '../../../services';

@Component({
  selector: 'app-employee-search',
  templateUrl: './employee-search.component.html',
  styleUrls: ['./employee-search.component.scss']
})
export class EmployeeSearchComponent {
  employeeId: number | undefined;
  @Output() searchEmployee = new EventEmitter<number>();
  constructor(private employeeService: EmployeeService) { }


  onSearch(): void {
    this.searchEmployee.emit(this.employeeId);
  }
}
