import { Injectable } from '@angular/core';
import { User } from 'src/app/model/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

constructor() { }


addUser(user: User){
  let users = [];
  if(localStorage.getItem('Users')){
    users = JSON.parse(localStorage.getItem('Users'));
    users.push(user);
  }else{
    users = [user];
  }
  localStorage.setItem('Users', JSON.stringify(users));
} 

}
