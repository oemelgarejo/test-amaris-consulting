import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

//Material
import {MatToolbarModule} from '@angular/material/toolbar';
import {MAT_FORM_FIELD_DEFAULT_OPTIONS, MatFormFieldModule} from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import {MatTableModule} from '@angular/material/table';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeeSearchComponent } from './components/employee/employee-search/employee-search.component';
import { EmployeeListComponent } from './components/employee/employee-list/employee-list.component';
import { EmployeeComponent } from './components/employee/employee/employee.component';
import { EmployeeSingleComponent } from './components/employee/employee-single/employee-single.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    EmployeeSearchComponent,
    EmployeeListComponent,
    EmployeeComponent,
    EmployeeSingleComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatFormFieldModule,
    MatIconModule,
    MatTableModule,
    MatCardModule,
    MatButtonModule
  ],
  providers: [
    {provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: {floatLabel: "auto"}}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
