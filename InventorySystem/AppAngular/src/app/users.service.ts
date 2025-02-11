import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from './User';

const httpOptions = 
{
  headers: new HttpHeaders
  ({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  url = 'https://localhost:5216/api/users';
  constructor(private http: HttpClient) { }


  GetAll(): Observable<User[]>
  {
      return this.http.get<User[]>(this.url);
  }

  GetById(id : string): Observable<User>
  {
    const apiUrl = `${this.url}/${id}`;
    return this.http.get<User>(apiUrl);
  } 


  AddUser(user: User): Observable<User>
  {
    return this.http.post<User>(this.url, user, httpOptions);
  }

  UpdateUser(user: User) : Observable<any>
  {
    return this.http.put<User>(this.url, user, httpOptions);
  }


  DeleteUser(id : string) : Observable<any>
  {
    const apiUrl = `${this.url}/${id}`;
    return this.http.delete<string>(apiUrl, httpOptions);
  }

}
