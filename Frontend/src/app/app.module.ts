import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Router,RouterModule} from '@angular/router';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { DatafilterComponent } from './datafilter/datafilter.component';
import { Routes } from '@angular/router';
import { GetdateService } from './service/getdate.service';
import { LoginService } from './service/login.service';
import { HttpService } from './service/http.service';
import { DatafilterService } from './service/datafilter.service';

//import { LoginGuard } from './login/login.guard';



//export const MENU_ROUTES: Routes = [
 // { path: '', component: DatafilterComponent },
//];
const appRoutes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent},
  { path: 'datafilter', component: DatafilterComponent}

];
export const route = RouterModule.forRoot(appRoutes);


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DatafilterComponent,
    LoginComponent
  ],
  imports: [
    RouterModule.forRoot(appRoutes),
    BrowserModule,
    FormsModule,
    HttpModule
  ],
  providers: [GetdateService, LoginService, HttpService, DatafilterService],
  bootstrap: [AppComponent]
})
export class AppModule {}
