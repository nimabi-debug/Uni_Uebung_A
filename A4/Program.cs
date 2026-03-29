using System;
using System.Diagnostics;

class Program
{   
    static void Main(string[] args)
    {
        Bank B = new Bank("GeizhalsBank");
        
        Kunde k0 = new Kunde("Alex", "17.10.2006", 12345, 10000);
        k0.Add(new Konto(k0, 11001100));
        k0.Add(new Konto(k0, 22002200));
        B.Add(k0);

        Kunde k1 = new Kunde("Nick", "22.09.2006", 22345, 10000);
        k1.Add(new Konto(k1,11101111));
        k1.Add(new Konto(k1,13101331));
        B.Add(k1);
    
        Kunde k2 = new Kunde("Lara", "08.09.2003", 32345, 10000);
        k2.Add(new Konto(k2,11342233));
        k2.Add(new Konto(k2,13134534));
        B.Add(k2);
        

        B.Ausgabe();
        //B.Ausgabe_Kunden();

        Konto Test = B.KontoFinden(11101111);
        int auszahlung = Test.Auszahlen(100000000);   
        
    }
}

class Bank
{
    private string Name;
    private List<Kunde> Kunden;
    
    public Bank(string Name)
    {
        this.Name = Name;
        this.Kunden = new List<Kunde>();
    }

    public void Add (Kunde k)
    {
        this.Kunden.Add(k);
    }

    public void Ausgabe()
    {
        foreach (Kunde k in this.Kunden)
        {
            k.Ausgabe();
        }
    }
    public void Ausgabe_Kunden()
    {
        foreach (Kunde k in this.Kunden)
        {
            k.Ausgabe_Kunden();
        }
    }
    public int SummeGuthaben()
    {   
        int gesamt = 0;
        foreach (Kunde k in this.Kunden)
        {
            gesamt += k.SummeGuthaben();
        }
        return gesamt;
    }
    public Konto KontoFinden(int Kontonummer)
    {
        foreach (Kunde k in this.Kunden)
        {
            foreach (Konto b in k.GetKontos())
            {   
                if (b.Kontonummer == Kontonummer)
                {
                    return b;
                }
            }
        }
        
        return null;
    }
}

class Kunde
{
    private string Name;
    private string Geburtstag;
    private int Kundennummer;
    private List<Konto> Konten;
    private int Limit;
    private int Kredit;

    public Kunde(string Name, string Geburtstag, int Kundennummer, int Limit)
    {   
        this.Konten = new List<Konto>();
        this.Name = Name;
        this.Geburtstag = Geburtstag;
        this.Kundennummer = Kundennummer;
        this.Limit = Limit;
        this.Kredit = 0;
    }

    public List<Konto> GetKontos()
    {
        return this.Konten;
    }
    public int GetKredit()
    {   
        return this.Kredit;
    }
    public void SetKredit(int k)
    {   
        this.Kredit = k;
    }
    public int GetLimit()
    {   
        return this.Limit;
    }

    public int KrediteAbbzahlen(int k)
    {   
        int kredit_uebrig = this.Kredit - k;
        if (kredit_uebrig < 0)
        {
            this.Kredit = 0;
            return kredit_uebrig;
        }
        return 0;
    }

    public void Add(Konto k)
    {
        this.Konten.Add(k);
    }
    public void Ausgabe()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"Name: {this.Name}\nGeburtstag: {this.Geburtstag}\nKundenNr: {this.Kundennummer}\nLimit: {this.Limit}");
        
        foreach (Konto k in this.Konten)
        {
            Console.WriteLine($"  KontoNr: {k.Kontonummer}\tGuthaben: {k.Guthaben}");
        }
        Console.WriteLine("----------------------------------------");
    }
    public void Ausgabe_Kunden()
    {
        Console.WriteLine($"\nName: {this.Name}\nGeburtstag: {this.Geburtstag}\nKundenNr: {this.Kundennummer}\nLimit: {this.Limit}\n");
    }
    public int SummeGuthaben()
    {   
        int gesamt = 0;
        foreach (Konto k in this.Konten)
        {
            gesamt += k.Guthaben;
        }
        return gesamt;
    }
}
class Konto
{
    public Kunde Owner;
    public int Kontonummer;
    public int Guthaben;

    public Konto(Kunde Owner, int Kontonummer, int Guthaben = 0)
    {
        this.Owner = Owner;
        this.Kontonummer = Kontonummer;
        this.Guthaben = Guthaben;
    }
    public void Einzahlen(int Guthaben)
    {
        this.Guthaben += Guthaben;
    }
    public int Auszahlen(int Guthaben)
    {
        int ueberzug = Guthaben - this.Guthaben;
        int ges_ueberzug = ueberzug + this.Owner.GetKredit();

        if (ges_ueberzug - this.Owner.GetLimit() < 0)
        {
            if (ueberzug > 0)
            {
                this.Owner.SetKredit(this.Owner.GetKredit() + ueberzug);
                this.Guthaben -= Guthaben;
                return Guthaben;
            }
        }
        Console.WriteLine($"Guthaben und Limit nicht ausreichend\nÜberschritten um: {ges_ueberzug - this.Owner.GetLimit()}");
        return 0;
    }
}