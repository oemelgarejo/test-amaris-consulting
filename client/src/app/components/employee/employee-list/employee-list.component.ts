import { Component, Input, OnInit } from '@angular/core';
import { Employee } from 'src/app/models';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss'],
})
export class EmployeeListComponent {
  @Input() employees: Employee[] = [];
    }
