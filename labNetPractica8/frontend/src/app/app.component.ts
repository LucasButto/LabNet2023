import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddModalComponent } from './Components/add-modal/add-modal.component';
import { DeleteModalComponent } from './Components/delete-modal/delete-modal.component';
import { APIService } from './API/apiservice.service';
import { NotificationsService } from './Services/notifications-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'Suppliers';
  SuppliersList: any[] = [];
  selectedSupplier: any = {};

  constructor(
    public dialog: MatDialog,
    private apiService: APIService,
    private notificationsService: NotificationsService
  ) {}

  ngOnInit() {
    this.loadSuppliers();
  }

  loadSuppliers() {
    this.apiService.getSuppliers().subscribe(
      (data: any) => {
        this.SuppliersList = data;
      },
      (error) => {
        this.notificationsService.showError(
          'Hubo un error al cargar los proveedores.'
        );
      }
    );
  }

  openModal(): void {
    const dialogRef = this.dialog.open(AddModalComponent, {
      width: '500px',
      data: {
        editMode: false,
        supplier: null,
        darkMode: this.darkMode,
        loadSuppliers: this.loadSuppliers.bind(this),
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.loadSuppliers();
      }
    });
  }

  onEdit(supplier: any) {
    if (supplier) {
      this.selectedSupplier = supplier;
      this.openDialog(true);
    }
  }

  openDialog(editMode: boolean = false): void {
    if (editMode && !this.selectedSupplier) {
      console.error('No se ha seleccionado un proveedor para editar.');
      return;
    }

    const dialogRef = this.dialog.open(AddModalComponent, {
      width: '500px',
      data: {
        editMode,
        supplier: this.selectedSupplier,
        darkMode: this.darkMode,
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.loadSuppliers();
    });
  }

  onDelete(supplier: any) {
    const dialogRef = this.dialog.open(DeleteModalComponent, {
      width: '500px',
      data: {
        supplier: supplier,
        darkMode: this.darkMode,
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.apiService.deleteSupplier(supplier.SupplierID).subscribe(
          (response) => {
            this.loadSuppliers();
          },
          (error) => {
            console.error('Error al eliminar proveedor:', error);
          }
        );
      }
    });
  }

  darkMode: boolean = false;

  toggleDarkMode() {
    this.darkMode = !this.darkMode;
  }
}
