using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

class Program
{   
    static void Main(string[] args)
    {
        
        Bruch a = new Bruch(6 , 8);
        Bruch b = new Bruch(5 , 6);
        Bruch Ergebnis = a.Addiere(b);
        Console.WriteLine($"Bruch: {a.Zaehler}/{a.Nenner} + {b.Zaehler}/{b.Nenner}");
        Console.WriteLine($"Ergebnis: {Ergebnis.Zaehler}/{Ergebnis.Nenner}");

        Bruch /*mein Name ist */ Ekurz = Ergebnis.Kuerze();
        
        Console.WriteLine($"Gekürzt: {Ekurz.Zaehler}/{Ekurz.Nenner}");
        
        int VergleicheMit = a.VergleicheMit(b);

        Console.WriteLine($"Größerer Bruch: {VergleicheMit}");
    }
}

class Bruch
{
    public int Zaehler;
    public int Nenner;

    public Bruch(int _zaehler, int _nenner )
    {
        this.Nenner = _nenner;
        this.Zaehler = _zaehler;
    }

    public Bruch Addiere(Bruch B)
    {
        /*
        int tempZaehler = this.Zaehler * B.Nenner + B.Zaehler * this.Nenner;
        int tempNenner = this.Nenner * B.Nenner;
        */
        return new Bruch(this.Zaehler * B.Nenner + B.Zaehler * this.Nenner, this.Nenner * B.Nenner);
    }

    public Bruch Kuerze()
    {
        // GGT - Größter Gemeinsamer Teiler: auf englisch: GratestCommonDivisor - GCD
        BigInteger GGT = BigInteger.GreatestCommonDivisor(new BigInteger(this.Zaehler), new BigInteger(this.Nenner));
        // (int)GGT -> casten, also von BiGInteger in int konvertieren
        return new Bruch(this.Zaehler/(int)GGT, this.Nenner/(int)GGT);
    }
    
    public int VergleicheMit(Bruch B)
    {
        Bruch negB = new Bruch(-B.Zaehler, B.Nenner);

        Bruch ergAdd = this.Addiere(negB);
        // unter 0, wenn B>this
        // 0, wenn gleich
        // über 0, wenn B<this
        if(ergAdd.Zaehler == 0)
        {
            return 0;
        }
        else if (ergAdd.Zaehler > 0)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
}