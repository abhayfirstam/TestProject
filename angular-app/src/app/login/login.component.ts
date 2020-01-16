import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/services/authentication.service';
import { EmployeeService } from 'src/services/employee.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};
  constructor(private employeeService: EmployeeService,private router: Router, private authenticationService: AuthenticationService) { }

  ngOnInit() {
    this.authenticationService.logout();
    // this.employeeService.getEmployees()
    // .subscribe(
    //     data => {
    //       console.log(data);
    //     },
    //     error => {
    //         alert(error.error.message);
    //     });
  }
  public open() {
    if(this.model.user && this.model.pass)
    {
    this.authenticationService.login(this.model.user, this.model.pass)
            .subscribe(
                data => {
                  this.router.navigate(['emplst']);
                },
                error => {
                    alert(error.error.message);
                });
              }
    else
    alert('Please enter username and password');
  }
}
