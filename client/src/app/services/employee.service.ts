import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, catchError, tap, throwError } from 'rxjs';
import { Employee } from '../models';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient) { }
  apiUrl = environment.apiurl;
  getEmployees(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/Employees`)
      .pipe(
        tap(response => console.log('Respuesta de la API:', response)),
        catchError(this.handleError)
      );
  }

  getEmployeeById(id: number): Observable<Employee> {
    const url = `${this.apiUrl}/Employees/${id}`;
    return this.http.get<Employee>(url);
  }


  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('Error del lado del cliente:', error.error.message);
    } else {
      console.error(`Código de estado ${error.status}, ` + `mensaje de error: ${error.error}`);
    }
    return throwError(error);
  }
}
