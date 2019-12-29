import { AbstractControl } from '@angular/forms';
import { TipPutnika } from './TipPutnika';

export class Korisnik{
    Name: string;
    Surname: string;
    Email: string;
    Password: string;
    DateOfBirth: string;
    Address: string;
    UserType: TipPutnika;
    Status:string;
    Image:string;
    ConfirmPassword:string;


   
}