import { Component, OnInit, AfterViewInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddModalComponent } from './Components/add-modal/add-modal.component';
import { DeleteModalComponent } from './Components/delete-modal/delete-modal.component';
import { APIService } from './API/apiservice.service';
import { NotificationsService } from './Services/notifications-service.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit, AfterViewInit {
  title = 'Suppliers';
  SuppliersList: any[] = [];
  selectedSupplier: any = {};
  darkMode: boolean = false;
  displayedColumns: string[] = [
    'ContactName',
    'CompanyName',
    'Phone',
    'PostalCode',
    'Actions',
  ];
  dataSource = new MatTableDataSource<any>(this.SuppliersList);
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    public dialog: MatDialog,
    private apiService: APIService,
    private notificationsService: NotificationsService
  ) {}

  ngOnInit() {
    this.loadSuppliers();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  loadSuppliers() {
    this.apiService.getSuppliers().subscribe({
      next: (data: any) => {
        this.SuppliersList = data;
        this.dataSource.data = data;
      },
      error: (error) => {
        this.notificationsService.showError(
          'Hubo un error al cargar los proveedores.'
        );
      },
    });
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
      this.notificationsService.showError(
        'No se ha seleccionado un proveedor.'
      );
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

    dialogRef.afterClosed().subscribe({
      next: (result) => {
        if (result) {
          this.apiService.deleteSupplier(supplier.SupplierID).subscribe({
            next: (response) => {
              this.notificationsService.showSuccess(
                'Proveedor eliminado correctamente.'
              );
              this.loadSuppliers();
            },
            error: (error) => {
              this.notificationsService.showError(
                'Hubo un error al eliminar el proveedor.'
              );
            },
          });
        }
      },
    });
  }

  toggleDarkMode() {
    this.darkMode = !this.darkMode;
  }

  applySorting(event: any) {
    const column = event.active;
    const direction = event.direction;

    if (!this.dataSource.sort) {
      return;
    }

    if (direction === '') {
      this.dataSource.sort.active = '';
      this.dataSource.sort.direction = '';
    } else {
      this.dataSource.sortingDataAccessor = (item, property) => {
        switch (property) {
          case 'ContactName':
            return item.ContactName;
          case 'CompanyName':
            return item.CompanyName;
          case 'Phone':
            return item.Phone;
          case 'PostalCode':
            return item.PostalCode;
          default:
            return '';
        }
      };
    }
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value.toLowerCase();
    this.dataSource.filter = filterValue;

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}
