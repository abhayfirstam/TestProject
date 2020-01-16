import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from "rxjs/operators";
@Injectable()
export class EmployeeService {
    constructor(private http: HttpClient) { }

    getJwtToken() {
            return JSON.parse(localStorage.getItem('currentUser')).token;
        }
    getEmployees() {
        return this.http.get<any>('http://localhost:53389/Employees',{headers:
            new HttpHeaders().set('Authorization', 'Bearer ' + this.getJwtToken())});
    }
    delEmployees(id) {
        return this.http.delete<any>('http://localhost:53389/Employees/'+id,{headers:
            new HttpHeaders().set('Authorization', 'Bearer ' + this.getJwtToken())});
    }
    addEmployees(emp:any) {
        return this.http.post<any>('http://localhost:53389/Employees',emp,{headers:
            new HttpHeaders().set('Authorization', 'Bearer ' + this.getJwtToken())});
    }
    getEmployeeById(id)
    {
        return this.http.get<any>('http://localhost:53389/Employees/'+id,{headers:
            new HttpHeaders().set('Authorization', 'Bearer ' + this.getJwtToken())});

    }
    updateEmployee(emp:any) {
        return this.http.put<any>('http://localhost:53389/Employees/'+emp.id,emp,{headers:
            new HttpHeaders().set('Authorization', 'Bearer ' + this.getJwtToken())});
    }
    
}