import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ILoginResponse } from '../../models/ILogin';
import { LoginService } from '../../services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent implements OnInit {
  sessionUser: any;
  searchForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private loginSVC: LoginService
  ){
    this.searchForm = fb.group({
      search: ['']
    });
  }

  ngOnInit(): void {
    this.sessionUser = JSON.parse(localStorage.getItem('sessionUser')!);
  }

  logout(): void{
    this.loginSVC.logout();
  }

  goToLogin(){
    this.router.navigateByUrl('/login');
  }
}
