import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { IStoreByIdResponse, IStoreGetAllResponse, IStoreUpdateRequest } from '../models/IStore';
import { Observable, tap, Subject, catchError } from 'rxjs';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root'
})
export class StoreService {

  baseUrl: string = environment.baseUrl;

  constructor(
    private http: HttpClient,
    private router: Router
  ) { }

  getAllStores(): Observable<IStoreGetAllResponse[]>{
    return this.http.get<IStoreGetAllResponse[]>(`${this.baseUrl}stores`);
  }

  getStoreById(id: Guid): Observable<IStoreByIdResponse>{
    return this.http.get<IStoreByIdResponse>(`${this.baseUrl}stores/${id}`);
  }

  updateStore(store: IStoreByIdResponse): Observable<IStoreByIdResponse>{
    return this.http.put<IStoreByIdResponse>(`${this.baseUrl}stores/${store.id}`, store)
  }

  deleteStore(id: Guid): void {
    this.http.delete<any>(`${this.baseUrl}stores/${id}`).pipe(
      tap((response: any) => {
        console.log('Store deleted successfully:', response);
        this.getAllStores()
      }),
      catchError((error) => {
        console.error('Failed to delete the store', error);
        throw error;
      })
    ).subscribe();
  }
}
