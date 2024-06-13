import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ILoginRequest, ILoginResponse, ISessionUser } from '../models/ILogin';
import { Observable, Subject } from 'rxjs';
import { environment } from '../../environments/environment';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

baseUrl: string = "http://localhost:5287/api/";
updateSessionUser: Subject<ISessionUser> = new Subject<ISessionUser>();

  constructor(
    private http: HttpClient
  ) { }

  login(payload: ILoginRequest): Observable<ILoginResponse> {
    this.clearStorage();
    return this.http.post<ILoginResponse>(this.baseUrl+'users/login', payload);
  }

  setSessionUser(Username: string, Role: string): void {
    const loggedUser = { Username, Role };
    localStorage.setItem(
      'sessionUser',
      JSON.stringify(loggedUser)
    );
    this.updateSessionUser.next(loggedUser);
    localStorage.setItem('logged', 'true');
  }

  clearStorage(): void{
    localStorage.clear();
    sessionStorage.clear();
  }
}
