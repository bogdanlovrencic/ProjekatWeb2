import { Stanica } from './stanica';

export class Linija 
{
    Id: number;   
    Naziv: string;
    Stanice: Stanica[];
    TipLinije: LineType;
    Aktivna: boolean;

    constructor(naziv:string, stanice:Stanica[]){
        this.Naziv = naziv;
        this.Stanice = stanice;
    }

    addLocation(stan:Stanica){
        this.Stanice.push(stan);
    }
}

export enum LineType{
    Gradski=0,
    Prigradski=1,
}