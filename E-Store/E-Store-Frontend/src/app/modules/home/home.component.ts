import { Component, OnInit } from '@angular/core';
import { IProductGetAllResponse } from '../../models/IProduct';
import { ProductService } from '../../services/product.service';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent implements OnInit {
  baseUrl: string = environment.baseUrl;
  allProducts!: IProductGetAllResponse[];

  constructor(
    private productSVC: ProductService,
    private router: Router,
  ) {}

  ngOnInit(): void {
    this.productSVC.getAll().subscribe((res) => {
      this.allProducts = res;
    });
  }

  showDetails(id: number) {
    this.router.navigate([`${this.baseUrl}${id}`]);
  }
}
