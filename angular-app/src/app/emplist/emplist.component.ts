import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/services/employee.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-emplist',
  templateUrl: './emplist.component.html',
  styleUrls: ['./emplist.component.css']
})
export class EmplistComponent implements OnInit {
  emplst: any = {};
  constructor(private employeeService: EmployeeService,public router: Router) { }

  ngOnInit() {
    this.onloadEmp();
  }
  deleteEmp(id)
  {
    this.employeeService.delEmployees(id)
    .subscribe(
        data => {
          this.onloadEmp();
        },
        error => {
            alert(error.error.message);
        });
  }

  onloadEmp(){
    this.employeeService.getEmployees()
    .subscribe(
        data => {
          this.emplst = data;
        },
        error => {
            alert(error.error.message);
        });
  }
  addemp()
  {
    this.router.navigate(['add']);
  }

  empEdit(id)
  {
    this.router.navigate(['add'],{ queryParams: { id: id } });
  }
 
}
