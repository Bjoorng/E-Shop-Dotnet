import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ILoginResponse, ISessionUser } from '../../models/ILogin';
import { LoginService } from '../../services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent implements OnInit {
  sessionUser!: ISessionUser;
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
    this.sessionUser = this.loginSVC.getSessionUser();
    console.log(this.sessionUser);
  }

  logout(): void{
    this.loginSVC.logout();
  }

  goToLogin(){
    this.router.navigateByUrl('/login');
  }
}
