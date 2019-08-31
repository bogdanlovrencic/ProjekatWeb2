import { AbstractControl } from '@angular/forms';
import { Linija } from './linija';

export class RedVoznje{
    public Polazak: string;
    public Linija: Linija;
    public TipDana: string;
    public TipRedaVoznje: string;
    public Aktivan: boolean;
}