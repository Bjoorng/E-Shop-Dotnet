import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ILoginResponse, ISessionUser } from '../../models/ILogin';
import { LoginService } from '../../services/login.service';
import { Router } from '@angular/router';
import { LoginComponent } from '../../modules/login/login.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
})
export class NavbarComponent implements OnInit {
  sessionUser!: ISessionUser;
  searchForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private dialog: MatDialog,
    private loginSVC: LoginService
  ) {
    this.searchForm = fb.group({
      search: [''],
    });
  }

  ngOnInit(): void {
    this.sessionUser = this.loginSVC.getSessionUser();
    console.log(this.sessionUser);
  }

  logout(): void {
    this.loginSVC.logout();
  }

  goToLogin() {
    this.dialog.open(LoginComponent, {
      disableClose: true,
    });
  }
}
