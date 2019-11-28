import { Stavka } from './Stavka';

export class Cenovnik{
   // public Id:number;
    public VaziOd: Date;
    public VaziDo: Date;
    public Stavke: Stavka[];
    public Aktivan: boolean;
}

export class CenovnikPrikaz{
    public Id:number;
    public VaziOd: Date;
    public VaziDo: Date;
    public Stavke: Stavka[];
    public Aktivan: boolean;
  
}
