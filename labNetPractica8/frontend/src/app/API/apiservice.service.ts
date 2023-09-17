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

  constructor(
    private http: HttpClient,
    private notificationService: NotificationsService
  ) {}

  getSuppliers() {
    return this.http.get(this.apiUrl).pipe(
      catchError((error: HttpErrorResponse) => {
        this.notificationService.showError(
          'Error al cargar proveedores: ' + error.message
        );
        return throwError(error);
      })
    );
  }

  postSupplier(newSupplier: any) {
    return this.http.post(this.apiUrl, newSupplier).pipe(
      catchError((error: HttpErrorResponse) => {
        this.notificationService.showError(
          'Error al agregar proveedor: ' + error.message
        );
        return throwError(error);
      })
    );
  }

  putSupplier(id: number, updatedSupplier: any) {
    return this.http.put(`${this.apiUrl}/${id}`, updatedSupplier).pipe(
      catchError((error: HttpErrorResponse) => {
        this.notificationService.showError(
          'Error al actualizar proveedor: ' + error.message
        );
        return throwError(error);
      })
    );
  }

  deleteSupplier(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`).pipe(
      catchError((error: HttpErrorResponse) => {
        this.notificationService.showError(
          'Error al eliminar proveedor: ' + error.message
        );
        return throwError(error);
      })
    );
  }

  showAddSuccessMessage() {
    this.notificationService.showSuccess('Proveedor agregado correctamente.');
  }

  showUpdateSuccessMessage() {
    this.notificationService.showSuccess(
      'Proveedor actualizado correctamente.'
    );
  }

  showDeleteSuccessMessage() {
    this.notificationService.showSuccess('Proveedor eliminado correctamente.');
  }
}
