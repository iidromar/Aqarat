import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UserForLogin } from '../model/user';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
baseUrl: string = environment.baseUrl;

constructor(private http:HttpClient) { }

authUser(user: UserForLogin){
  return this.http.post(this.baseUrl + '/account/login', user);
  // let UserArray = [];
  // if(localStorage.getItem('Users')){
  //   UserArray = JSON.parse(localStorage.getItem('Users'));
  // }
  // return UserArray.find((p: any) => p.userName === user.userName && p.password === user.password);
}
}
