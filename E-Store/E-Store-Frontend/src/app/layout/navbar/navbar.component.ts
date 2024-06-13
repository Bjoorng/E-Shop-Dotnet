import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ILoginResponse } from '../../models/ILogin';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent implements OnInit {
  sessionUser: any;
  searchForm: FormGroup;

  constructor(
    private fb: FormBuilder
  ){
    this.searchForm = fb.group({
      search: ['']
    });
  }
  ngOnInit(): void {
    this.sessionUser = JSON.parse(localStorage.getItem('sessionUser')!);
  }
}
