import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { ISignupRequest, ISignupResponse } from '../models/ISignup';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SignupService {

  baseUrl: string = environment.baseUrl;

  constructor(private http: HttpClient, private router: Router) { }

  signup(user: ISignupRequest): Observable<ISignupRequest> {
    return this.http.post<ISignupRequest>(`${this.baseUrl}signup`, user);
  }
}
