import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {
  searchForm: FormGroup;

  constructor(
    private fb: FormBuilder
  ){
    this.searchForm = fb.group({
      search: ['']
    });
  }
}
