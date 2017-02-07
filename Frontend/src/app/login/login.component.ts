import { Component, OnInit } from '@angular/core';
import { Router} from '@angular/router';
import { NgModule } from '@angular/core';
import { LoginUser }  from '../commonClasses/login-user';
import { LoginService } from '../service/login.service';
import { HttpService } from '../service/http.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {

  constructor(private router: Router, private loginService: LoginService) { }
  private loggedInUser: LoginUser;
  private Users: LoginUser[] = [];

  ngOnInit() {
  }
  get_Userdata;
  json_Userdata;
  user_Array = [];
  model: any = {};
  flag = 0;

  // Add the username and password to localstorage
  login( currentUser: LoginUser )
  {
      this.loginService.LoginResponse(currentUser);

      this.get_Userdata = { "username: ": this.model.username,"password: ": this.model.password };
      this.user_Array.push(this.get_Userdata);
      this.json_Userdata = JSON.stringify(this.user_Array);
      this.flag = 1;
      localStorage.setItem("user :", this.json_Userdata);
      // this.router.navigate(['/datafilter']);
  }

   
        user = [
            { "name": "abc","password": "123"}   
        ]
     
// onGo()
// {
//   if(this.flag == 1)
//   this.router.navigate(['/datafilter']);  
//   else
//   this.router.navigate(['/login']);  
// }
}
