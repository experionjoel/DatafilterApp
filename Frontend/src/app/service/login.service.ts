import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { LoginUser } from '../commonClasses/login-user';
import { Router } from '@angular/router';

@Injectable()
export class LoginService {

  private currentUser: LoginUser;
  constructor( private httpService: HttpService, private router: Router ) 
  {
  }

  LoginResponse( user: LoginUser )
  {
     console.log("reached service"+user);
     var response = this.httpService.LoginAuthorize(user).subscribe(
                    (data)=> {
                     if(data.Status == true)
                     {
                        // this.router.navigate(['/main']);
                        this.router.navigate(['/datafilter']);
                        alert("User is valid !!");
                     }
                     if(data.Status == false)
                     {
                       alert("User is not registered !!");
                     }
                   });
  }

}
