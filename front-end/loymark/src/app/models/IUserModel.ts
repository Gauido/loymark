export interface IUser {
  id?:number;
  name: string;
  lastName: string;
  email: string;
  birthDate: Date;
  phone?: number;
  country: string;
  receiveInformation: boolean;
}
