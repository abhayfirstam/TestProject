import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { LoginComponent } from './login/login.component';
import { AuthGuardService as AuthGuard, AuthGuardService } from 'src/services/auth-guard.service';
import { AuthenticationService } from 'src/services/authentication.service';
import { AuthService } from 'src/helpers/auth.guard';
import { JwtHelperService } from '@auth0/angular-jwt';
import { EmplistComponent } from './emplist/emplist.component';
import { EmployeeService } from 'src/services/employee.service';
import { AddempComponent } from './addemp/addemp.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LoginComponent,
    EmplistComponent,
    AddempComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      // { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: '', component: LoginComponent, pathMatch: 'full' },
      { path: 'emplst', component: EmplistComponent,canActivate: [AuthGuard]  },
      { path: 'add', component: AddempComponent,canActivate: [AuthGuard]   },
    ])
  ],
  providers: [JwtHelperService,AuthGuardService,AuthService,AuthenticationService,EmployeeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
