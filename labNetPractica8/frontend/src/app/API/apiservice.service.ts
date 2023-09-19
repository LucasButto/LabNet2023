import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { NotificationsService } from '../Services/notifications-service.service';

@Injectable({
  providedIn: 'root',
})
export class APIService {
  private apiUrl = 'https://localhost:44329/api/Suppliers';

  constructor(private http: HttpClient) {}

  getSuppliers() {
    return this.http.get(this.apiUrl).pipe(
      catchError((error: HttpErrorResponse) => {
        console.log('get error: ', error);
        return throwError(error);
      })
    );
  }

  postSupplier(newSupplier: any) {
    return this.http.post(this.apiUrl, newSupplier).pipe(
      catchError((error: HttpErrorResponse) => {
        console.log('post error: ', error);
        return throwError(error);
      })
    );
  }

  putSupplier(id: number, updatedSupplier: any) {
    return this.http.put(`${this.apiUrl}/${id}`, updatedSupplier).pipe(
      catchError((error: HttpErrorResponse) => {
        console.log('put error: ', error);
        return throwError(error);
      })
    );
  }

  deleteSupplier(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`).pipe(
      catchError((error: HttpErrorResponse) => {
        console.log('delete error: ', error);
        return throwError(error);
      })
    );
  }
}
