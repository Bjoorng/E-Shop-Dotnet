import { IProductIdRequest, IProductIdResponse, IProductUpdateRequest } from './../models/IProduct';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Route } from '@angular/router';
import { environment } from '../../environments/environment';
import { IProductGetAllResponse } from '../models/IProduct';
import { Observable } from 'rxjs';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  baseUrl: string = environment.baseUrl;

  constructor(private http: HttpClient) { }

  getAll(): Observable<IProductGetAllResponse[]>{
    return this.http.get<IProductGetAllResponse[]>(`${this.baseUrl}/products`);
  }

  getProductById(id: Guid): Observable<IProductIdResponse>{
    return this.http.get<IProductIdResponse>(`${this.baseUrl}products/${id}`);
  }

  getAllByCategory(category: string): Observable<IProductGetAllResponse[]>{
    return this.http.get<IProductGetAllResponse[]>(`${this.baseUrl}/products/${category}`);
  }

  getByPriceHigher(priceHigh: number): Observable<IProductGetAllResponse[]>{
    return this.http.get<IProductGetAllResponse[]>(`${this.baseUrl}/products/${priceHigh}`);
  }

  getByPriceLower(priceLower: number): Observable<IProductGetAllResponse[]>{
    return this.http.get<IProductGetAllResponse[]>(`${this.baseUrl}/products/${priceLower}`);
  }

  update(product: IProductUpdateRequest): Observable<IProductUpdateRequest>{
    return this.http.put<IProductUpdateRequest>(`${this.baseUrl}/products/${product.id}`, product);
  }

  delete(id: Guid): void{
    this.http.delete<any>(`${this.baseUrl}products/${id}`).subscribe();
  }
}
