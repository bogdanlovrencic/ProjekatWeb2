export class Stanica{
    Id: number;
    Naziv: string;
    Adresa: string;
    KordinataX: Number;
    KordinataY: Number;

    constructor(x:number, y:number)
    {
        this.KordinataX = x;
        this.KordinataY = y;
    }
}