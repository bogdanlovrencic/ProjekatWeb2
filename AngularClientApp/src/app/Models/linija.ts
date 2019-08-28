import { Stanica } from './stanica';

export class Linija 
{
    Id: number;   
    RedniBroj: string;
    stanice: Stanica[];

    constructor(broj:string, stanice:Stanica[]){
        this.RedniBroj = broj;
        this.stanice = stanice;
    }

    addLocation(stan:Stanica){
        this.stanice.push(stan);
    }
}