import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
@Injectable()
export class AuthService {
  constructor(
    //   public jwtHelper: JwtHelperService
    ) {}
  public isAuthenticated(): boolean {
    const currentUser = localStorage.getItem('currentUser');
    // Check whether the token is expired and return
    // true or false
    // return !this.jwtHelper.isTokenExpired(token);
    // console.log(JSON.parse(currentUser).token);
    if(currentUser)
    return true;
    else
    return false;
  }
}