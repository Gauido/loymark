import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IActivity } from 'src/app/models/IActivityModel';
import { IUser } from 'src/app/models/IUserModel';
import { UserService } from 'src/app/services/user.service';
import { ICountry } from 'src/app/models/ICountryModel';
import countries from 'src/app/models/Countries';
import { MatSnackBar } from '@angular/material/snack-bar';
@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
})
export class UserComponent implements OnInit {
  userList: IUser[] = [];
  taskList: IActivity[] = [];
  form!: FormGroup;
  countries: ICountry[] = [];
  idSelected: number = null;
  selectedUser: any = null;
  selectedCountry;
  birthDate;

  constructor(
    private uService: UserService,
    private fBuilder: FormBuilder,
    private _snackBar: MatSnackBar
  ) {}

  async ngOnInit() {
    this.countries = countries;
    this.createForm();
    this.completeTable();
  }

  public async delete(id: number) {
    this.uService.delete(id).subscribe(
      () => {
        this.completeTable();
        this.showAlert('Usuario borrado exitosamente!');
      },
      () => {
        this.showAlert('Error al borrar el usuario');
      }
    );
  }

  public async onSubmit() {
    let data = {
      name: this.form.value.name,
      lastname: this.form.value.last,
      email: this.form.value.email,
      phone: this.form.value.phone == "" ? 0 : this.form.value.phone,
      birthDate: this.form.value.birthDate,
      receiveInformation: this.form.value.receiveInformation,
      country: this.form.value.country,
    };

    let action = "";
    try {
      if (this.idSelected != null) {
        action = "actualizar";
        await this.uService.update(data, this.idSelected).toPromise();
      } else {
        action = "crear";
        await this.uService.create(data).toPromise();
      }
      this.showAlert(`La opreación fue un éxito!`);
    } catch (error) {
      this.showAlert(`Ocurrío un error al ${action}`);
    }
    this.completeTable();
    this.resetForm();
  }

  public resetForm() {
    this.form.reset();
    this.idSelected = null;
  }
  async completeTable() {
    this.userList = await (await this.uService.getAll()).toPromise();
  }



  public update(user: any) {
    this.selectedUser = user;
    this.idSelected = user.id;
    this.form.patchValue({
      name: user.name,
      last: user.lastName,
      email: user.email,
      phone: user.phone,
      birthDate: user.birthDate,
      receiveInformation: user.receiveInformation,
      country: user.country,
    });
  }

  public getCountryLabel(code:string){
    return countries.find(x=> x.code == code)?.label;
  }

  private showAlert(message: string) {
    this._snackBar.open(message, null, {
      duration: 6000,
    });
  }

  private createForm() {
    this.form = this.fBuilder.group({
      name: [
        '',
        [
          Validators.required,
          Validators.pattern('^[a-zA-Z ]+$'),
          Validators.maxLength(25),
        ],
      ],
      last: [
        '',
        [
          Validators.required,
          Validators.pattern('^[a-zA-Z ]+$'),
          Validators.maxLength(25),
        ],
      ],
      email: ['', [Validators.required, Validators.email, Validators.maxLength(30)]],
      phone: ['', [Validators.pattern('^[0-9]+$')]],
      birthDate: ['', Validators.required],
      receiveInformation: [true],
      country: ['', Validators.required],
    });
  }
}
