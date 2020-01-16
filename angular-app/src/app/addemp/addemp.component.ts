import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/services/employee.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-addemp',
  templateUrl: './addemp.component.html',
  styleUrls: ['./addemp.component.css']
})
export class AddempComponent implements OnInit {
  emp: any = {};
  constructor(private route: ActivatedRoute, private employeeService: EmployeeService, public router: Router) { }
  add: boolean = false;
  update: boolean = false;
  addEdit:string;
  ngOnInit() {
    if (this.route.snapshot.queryParamMap['params']['id']) {
      this.employeeService.getEmployeeById(this.route.snapshot.queryParamMap['params']['id'])
        .subscribe(
          data => {
            this.update= true;
            this.addEdit='Edit Employee';
            this.emp = data;
          },
          error => {
            alert(error.error.title);
            console.log(error);
          });
    }
    else
    {
      this.add=true;
      this.addEdit='Add New Employee';
    }

  }
  addEmp() {
    this.employeeService.addEmployees(this.emp)
      .subscribe(
        data => {
          this.router.navigate(['emplst']);
        },
        error => {
          alert(error.error.title);
          console.log(error);
        });
  }

  updateEmp()
  {
    this.employeeService.updateEmployee(this.emp)
      .subscribe(
        data => {
          this.router.navigate(['emplst']);
        },
        error => {
          alert(error.error.title);
          console.log(error);
        });
  }
}
