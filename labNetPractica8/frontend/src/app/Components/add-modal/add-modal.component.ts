import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { APIService } from '../../API/apiservice.service';

@Component({
  selector: 'app-add-modal',
  templateUrl: './add-modal.component.html',
  styleUrls: ['./add-modal.component.css'],
})
export class AddModalComponent implements OnInit {
  editMode: boolean = false;
  darkMode: boolean;
  supplierForm: FormGroup = this.fb.group({
    ContactName: ['', [Validators.required, Validators.maxLength(30)]],
    CompanyName: ['', [Validators.required, Validators.maxLength(40)]],
    Phone: [
      '',
      [
        Validators.required,
        Validators.minLength(10),
        Validators.maxLength(24),
        Validators.pattern(/^[\d+\(\)\*,\-\s]*$/),
      ],
    ],
    PostalCode: ['', [Validators.required, Validators.maxLength(10)]],
  });

  formSubmitted = false;

  constructor(
    public dialogRef: MatDialogRef<AddModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    private apiService: APIService
  ) {
    this.darkMode = this.data.darkMode;
  }

  ngOnInit(): void {
    this.editMode = this.data.editMode;
    if (this.editMode) {
      const supplier = this.data.supplier;
      this.supplierForm.patchValue({
        ContactName: supplier.ContactName,
        CompanyName: supplier.CompanyName,
        Phone: supplier.Phone,
        PostalCode: supplier.PostalCode,
      });
    }
  }

  onAdd(): void {
    this.formSubmitted = true;

    if (this.supplierForm.valid) {
      if (this.editMode) {
        const supplierId = this.data.supplier.SupplierID;
        this.apiService
          .putSupplier(supplierId, this.supplierForm.value)
          .subscribe(
            (response) => {
              this.dialogRef.close();
            },
            (error) => {
              console.error('Error al editar proveedor:', error);
            }
          );
      } else {
        this.apiService.postSupplier(this.supplierForm.value).subscribe(
          (response) => {
            this.dialogRef.close();
            this.data.loadSuppliers();
          },
          (error) => {
            console.error('Error al agregar proveedor:', error);
          }
        );
      }
    }
  }

  onBlur(fieldName: string) {
    this.supplierForm.get(fieldName)?.markAsTouched();
  }

  isFieldTouched(fieldName: string): boolean {
    return this.supplierForm.get(fieldName)?.touched || false;
  }

  onCancel(): void {
    this.dialogRef.close();
  }
}
