export class Stanica{
    Id: number;
    Naziv: string;
    Adresa: string;
    Lat: number;
    Lon: number;
    Version:number;
    

    constructor(lat:number, lon:number)
    {
        this.Lat = lat;
        this.Lon = lon;
      
    }
}