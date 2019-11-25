export class Polazak
{
    public Vreme:string;
    public TipDana:string;
    public LinijaId:number;
}

export class PolazakRequest
{
    public TipDana:string;
    public LinijaId:number;
}

export class PolazakModel{
    public Id:number;
    public Vreme:string;
    public TipDana:string;
    public LinijaId:number;
    public Active:boolean;
}