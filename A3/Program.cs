using System;
using System.Diagnostics;

class Program
{   
    static void Main(string[] args)
    {
       /*Artikel A = new Artikel();
        int[] A = {1,2,3,4,5};
        A[0] = 69;*/
       //Artikel[] A = {new Artikel(),new Artikel(),new Artikel(),new Artikel(),new Artikel(),new Artikel(),new Artikel(),new Artikel(),new Artikel(),new Artikel()};
       Artikel[] A = new Artikel [10];
       int Anzahl = 3;
       A[0] = new Artikel ("Smarties", 9696, 0.50/*, Lebensmittelgruppe.Suesswaren*/);
       A[1] = new Artikel ("Chicken", 2030, 9.99, Lebensmittelgruppe.Fleisch);
       A[2] = new Artikel ("Tomato", 1870, 1.99, Lebensmittelgruppe.Gemuese);
       
       bool running = true; 
       while (running)
        {

            Console.WriteLine("Was wünschen Sie zu tun?");
            Console.WriteLine("0 = Anlegen ");
            Console.WriteLine("1 = Ändern ");
            Console.WriteLine("2 = Ausgabe ");
            Console.WriteLine("3 = Teuerster Artikel ");
            Console.WriteLine("4 = Ende");
            Console.Write("Ihre Auswahl: ");
            int? Eingabe = int.Parse(Console.ReadLine());

            if (Eingabe == 0)
            {
                A[Anzahl] = new Artikel ();
                Anzahl = Anzahl +1;
            }

            if (Eingabe == 1)
            {
                Console.Write("Bezeichnung des Artikels eingeben? ");
                string artikel = Console.ReadLine();
                foreach (Artikel B in A)
                {
                    if(B == null) continue;
                    if (B.GetBezeichnung() == artikel)
                    {
                        Console.Write("Neue Bezeichnung: ");
                        string NewBez = Console.ReadLine();
                        Console.Write("Neuer Preis: ");
                        double NewPreis = double.Parse(Console.ReadLine());
                        B.SetBezeichnung (NewBez);
                        B.SetPreis (NewPreis);
                        break;
                    }
                    
                }
                
            }
            

            if (Eingabe == 2)
            {
                foreach (Artikel B in A)
                {
                    if(B == null) continue;    
        
                    B.Ausgabe();
                }
            }

            if (Eingabe == 3)
            {   
                Artikel Teuerster = A[0];
                foreach (Artikel B in A)
                {
                    if(B == null) continue;
                    if (B.GetPreis() > Teuerster.GetPreis())
                    {
                        Teuerster = B;
                    }

                }

                Console.WriteLine($"{Teuerster.GetBezeichnung()}");

            }
            
            if (Eingabe == 4)
            {
                running = false ;
            }
        }
    }
}

enum Lebensmittelgruppe
{
    Obst,
    Gemuese,
    Fleisch,
    Suesswaren
}

class Artikel
{
    private string Artikelbezeichnung;
    private int Artikelnummer;
    private double Verkaufspreis;
    private Lebensmittelgruppe Gruppe;


    public Artikel()
    {
        Console.Write("Geben sie die Artikelbezeichnung ein: ");
        this.Artikelbezeichnung = Console.ReadLine();

        Console.Write("Geben sie die Artkielnummer ein: ");
        this.Artikelnummer = int.Parse(Console.ReadLine());

        Console.Write("Geben sie den Verkaufspreis ein: ");
        this.Verkaufspreis = double.Parse(Console.ReadLine());

        Console.WriteLine("Obst         = 1 ");
        Console.WriteLine("Gemuse       = 2 ");
        Console.WriteLine("Fleisch      = 3 ");
        Console.WriteLine("Suesswaren   = 4 ");
        Console.Write("Geben sie die Lebensmittel Gruppe ein: ");

       int LMGruppe = int.Parse(Console.ReadLine());

        if ( LMGruppe == 1)
        {
            this.Gruppe = Lebensmittelgruppe.Obst;
        }
        if (LMGruppe == 2)
        {
            this.Gruppe = Lebensmittelgruppe.Gemuese;
        }
        if (LMGruppe == 3)
        {
            this.Gruppe = Lebensmittelgruppe.Fleisch;
        }
        if (LMGruppe == 4)
        {
            this.Gruppe = Lebensmittelgruppe.Suesswaren;
        }
    }

    public Artikel(string Artikelbezeichnung, int Artikelnummer, double Verkaufspreis, Lebensmittelgruppe Gruppe = (Lebensmittelgruppe.Suesswaren))
    {
        this.Artikelbezeichnung = Artikelbezeichnung;
        this.Artikelnummer = Artikelnummer;
        this.Verkaufspreis = Verkaufspreis;
        this.Gruppe = Gruppe;
    }
 
    
    public void Ausgabe ()
    {
        Console.WriteLine($"{Artikelbezeichnung}: {Artikelnummer}, {Verkaufspreis} {Gruppe}");
       //Console.WriteLine(""+Artikelbezeichnung+": "+Artikelnummer+", "+Verkaufspreis+" ("+Gruppe+")");
        
    }
    public double GetPreis()
    {
        return this.Verkaufspreis;
    } 
    public void SetPreis(double NewPreis)
    {
        this.Verkaufspreis = NewPreis;
    } 
    public string GetBezeichnung()
    {
        return this.Artikelbezeichnung;
    } 
    public void SetBezeichnung(string NewBezeichnung)
    {
        this.Artikelbezeichnung = NewBezeichnung;
    } 

}
