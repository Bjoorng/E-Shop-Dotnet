import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ILoginRequest, ILoginResponse, ISessionUser } from '../models/ILogin';
import { Observable, Subject } from 'rxjs';
import { environment } from '../../environments/environment';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root',
})
export class LoginService {

  baseUrl: string = environment.baseUrl;

  updateSessionUser: Subject<ISessionUser> = new Subject<ISessionUser>();

  constructor(private http: HttpClient, private router: Router) {}

  login(user: ILoginRequest): Observable<ILoginResponse> {
    this.clearStorage();
    return this.http.post<ILoginResponse>(
      this.baseUrl + 'users/login',
      user
    );
  }

  logout(): void {
    this.clearStorage();
    window.location.reload();
  }

  setSessionUser(id: Guid, username: string, role: string): void {
    const loggedUser = { id, username, role };
    localStorage.setItem('sessionUser', JSON.stringify(loggedUser));
    this.updateSessionUser.next(loggedUser);
    localStorage.setItem('logged', 'true');
  }

  getSessionUser(): any {
    if (localStorage.getItem('sessionUser')) {
      return JSON.parse(localStorage.getItem('sessionUser')!);
    }
  }

  goToLogin(): void {
    this.router.navigateByUrl('/login');
  }

  clearStorage(): void {
    localStorage.clear();
    sessionStorage.clear();
  }
}
