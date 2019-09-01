import { Stavka } from './Stavka';

export class Cenovnik{
    public VaziOd: Date;
    public VaziDo: Date;
    public Aktivan: boolean;
    public Stavke: number[];
}

export class CenovnikPrikaz{
    public Id:number;
    public VaziOd: Date;
    public VaziDo: Date;
    public Aktivan: boolean;
    public Stavke: Stavka[];
}