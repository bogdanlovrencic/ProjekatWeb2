import { AbstractControl } from '@angular/forms';
import { TipPutnika } from './TipPutnika';

export class Korisnik{
    Ime: string;
    Prezime: string;
    Email: string;
    Lozinka: string;
    DatumRodjenja: string;
    Adresa: string;
    TipPutnika: TipPutnika;
    Status:string;
    ImgUrl:string;
    ConfirmPassword:string;

   
}