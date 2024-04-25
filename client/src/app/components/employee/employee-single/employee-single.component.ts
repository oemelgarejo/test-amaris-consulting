import { Component, Input } from '@angular/core';
import { Employee } from 'src/app/models';

@Component({
  selector: 'app-employee-single',
  templateUrl: './employee-single.component.html',
  styleUrls: ['./employee-single.component.scss'],
})
export class EmployeeSingleComponent {
  @Input() employee: Employee | null = null;
}
