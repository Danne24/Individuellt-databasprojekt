using Individuellt_databasprojekt.Models;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Individuellt_databasprojekt
{
    class Program
    {
        static void Main(string[] args)
        {
            using Individuellt_databasprojekt_DbContext Context = new Individuellt_databasprojekt_DbContext();

            bool huvudMeny = true;
            while (huvudMeny == true)
            {
                Console.Clear();
                Console.WriteLine("Välj ett alternativ nedan, Mata in siffran som representerar ditt val."); // Det måste finnas en meny där man kan välja att visa olika data som efterfrågas av skolan. (I Console Bara till EF funktioner).
                Console.WriteLine("1 --- Hämta ut alla elever."); // Hämta ut alla elever (ska lösas med Entity framwork) Användaren får välja om de vill se eleverna sorterade på för- eller efternamn och om det ska vara stigande eller fallande sortering. Visa information om alla elever (EF VS).
                Console.WriteLine("2 --- Hämta ut alla elever i en viss klass."); // Hämta ut alla elever i en viss klass (ska lösas med Entity framework) Användaren ska först få se en lista med alla klasser som finns, sen får användaren välja en av klasserna och då skrivs alla elever i den klassen ut.
                Console.WriteLine("3 --- Lägga till ny personal."); // Lägga till ny personal (ska lösas genom Entity framework) Användaren får möjlighet att mata in uppgifter om en ny anställd och dessa sparas ner i databasen.
                Console.WriteLine("4 --- Avsluta programmet.");
                Console.WriteLine("5 --- Hämta ut personalen.");
                Console.WriteLine("6 --- Se hur många och vilka som jobbar på valfri avdelning."); // Hur många lärare jobbar på de olika avdelningarna?(EF VS).
                Console.WriteLine("7 --- Visa en lista på alla aktiva kurser."); // Visa en lista på alla aktiva kurser (EF VS).
                Console.WriteLine("8 --- Uppdatera/korrigera en elevs information via koden."); // Extra utmaningar. 3- Uppdatera/korrigera en elevs information via koden (EF i VS).

                string huvudMenyVal = Console.ReadLine();

                Console.Clear();
                switch (huvudMenyVal)
                {
                    case "1":
                        HämtaUtAllaElever(Context);
                        break;

                    case "2":
                        HämtaUtAllaEleverIEnVissKlass(Context);
                        break;

                    case "3":
                        LäggaTillNyPersonal(Context);
                        break;

                    case "4":
                        huvudMeny = false;
                        break;

                    case "5":
                        HämtaUtPersonalen(Context);
                        break;

                    case "6":
                        SeHurMångaSomJobbarPåValfriAvdelning(Context);
                        break;

                    case "7":
                        VisaEnListaPåAllaAktivaKurser(Context);
                        break;

                    case "8":
                        UppdateraKorrigeraEnElevsInformationViaKoden(Context);
                        break;

                    default:
                        break;
                }
            }
        }

        public static void HämtaUtAllaElever(Individuellt_databasprojekt_DbContext Context)
        {
            Console.WriteLine("Ska eleverna sorteras på för eller efternamn? Mata in siffran som representerar ditt val." +
                            "\n1 --- Förnamn." +
                            "\n2 --- Efternamn.");

            string HämtaUtAllaEleverVal = "0";
            bool loopCase1 = true;
            while (loopCase1 == true)
            {
                HämtaUtAllaEleverVal = Console.ReadLine();

                if (HämtaUtAllaEleverVal == "1" || HämtaUtAllaEleverVal == "2")
                {
                    loopCase1 = false;
                }
                else
                {
                    Console.WriteLine("Ogiltigt val, försök igen.");
                }
            }

            Console.Clear();

            switch (HämtaUtAllaEleverVal)
            {
                case "1":
                    Console.WriteLine("Ska eleverna sorteras på ett stigande eller fallande vis? Mata in siffran som representerar ditt val." +
                         "\n1 --- Stigande." +
                         "\n2 --- Fallande.");

                    string SorteraElevernaFörnamn = "0";
                    loopCase1 = true;
                    while (loopCase1 == true)
                    {
                        SorteraElevernaFörnamn = Console.ReadLine();

                        if (SorteraElevernaFörnamn == "1" || SorteraElevernaFörnamn == "2")
                        {
                            loopCase1 = false;
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt val, försök igen.");
                        }
                    }

                    Console.Clear();

                    if (SorteraElevernaFörnamn == "1")
                    {
                        var AllaEleverna = from ElevTbl in Context.ElevTbl orderby ElevTbl.ElevFörnamn ascending select ElevTbl;

                        Console.WriteLine("Nedan visas alla elever, i bokstavsordning baserat på förnamn och på stigande vis.");
                        Console.WriteLine();

                        foreach (var elev in AllaEleverna)
                        {
                            Console.WriteLine($"Elevens id: {elev.ElevId}");
                            Console.WriteLine($"Elevens personnummer: {elev.ElevPersonnummer}");
                            Console.WriteLine($"Elevens förnamn: {elev.ElevFörnamn}");
                            Console.WriteLine($"Elevens efternamn: {elev.ElevEfternamn}");
                            Console.WriteLine($"Elevens kön: {elev.ElevKön}");
                            Console.WriteLine($"Elevens klass: {elev.ElevKlass}");
                            Console.WriteLine(new string('-', (40)));
                        }
                    }
                    else if (SorteraElevernaFörnamn == "2")
                    {
                        var AllaEleverna = from ElevTbl in Context.ElevTbl orderby ElevTbl.ElevFörnamn descending select ElevTbl;

                        Console.WriteLine("Nedan visas alla elever, i bokstavsordning baserat på förnamn och på fallande vis.");
                        Console.WriteLine();

                        foreach (var elev in AllaEleverna)
                        {
                            Console.WriteLine($"Elevens id: {elev.ElevId}");
                            Console.WriteLine($"Elevens personnummer: {elev.ElevPersonnummer}");
                            Console.WriteLine($"Elevens förnamn: {elev.ElevFörnamn}");
                            Console.WriteLine($"Elevens efternamn: {elev.ElevEfternamn}");
                            Console.WriteLine($"Elevens kön: {elev.ElevKön}");
                            Console.WriteLine($"Elevens klass: {elev.ElevKlass}");
                            Console.WriteLine(new string('-', (40)));
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("******************************************");
                    Console.WriteLine();
                    Console.WriteLine("Tryck på enter för att återgå till huvudmenyn.");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.WriteLine("Ska eleverna sorteras på ett stigande eller fallande vis? Mata in siffran som representerar ditt val." +
                        "\n1 --- Stigande." +
                        "\n2 --- Fallande.");

                    string SorteraElevernaEfternamn = "0";
                    loopCase1 = true;
                    while (loopCase1 == true)
                    {
                        SorteraElevernaEfternamn = Console.ReadLine();

                        if (SorteraElevernaEfternamn == "1" || SorteraElevernaEfternamn == "2")
                        {
                            loopCase1 = false;
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt val, försök igen.");
                        }
                    }

                    Console.Clear();

                    if (SorteraElevernaEfternamn == "1")
                    {
                        var AllaEleverna = from ElevTbl in Context.ElevTbl orderby ElevTbl.ElevEfternamn ascending select ElevTbl;

                        Console.WriteLine("Nedan visas alla elever, i bokstavsordning baserat på efternamn och på stigande vis.");
                        Console.WriteLine();

                        foreach (var elev in AllaEleverna)
                        {
                            Console.WriteLine($"Elevens id: {elev.ElevId}");
                            Console.WriteLine($"Elevens personnummer: {elev.ElevPersonnummer}");
                            Console.WriteLine($"Elevens förnamn: {elev.ElevFörnamn}");
                            Console.WriteLine($"Elevens efternamn: {elev.ElevEfternamn}");
                            Console.WriteLine($"Elevens kön: {elev.ElevKön}");
                            Console.WriteLine($"Elevens klass: {elev.ElevKlass}");
                            Console.WriteLine(new string('-', (40)));
                        }
                    }
                    else if (SorteraElevernaEfternamn == "2")
                    {
                        var AllaEleverna = from ElevTbl in Context.ElevTbl orderby ElevTbl.ElevEfternamn descending select ElevTbl;

                        Console.WriteLine("Nedan visas alla elever, i bokstavsordning baserat på efternamn och på fallande vis.");
                        Console.WriteLine();

                        foreach (var elev in AllaEleverna)
                        {
                            Console.WriteLine($"Elevens id: {elev.ElevId}");
                            Console.WriteLine($"Elevens personnummer: {elev.ElevPersonnummer}");
                            Console.WriteLine($"Elevens förnamn: {elev.ElevFörnamn}");
                            Console.WriteLine($"Elevens efternamn: {elev.ElevEfternamn}");
                            Console.WriteLine($"Elevens kön: {elev.ElevKön}");
                            Console.WriteLine($"Elevens klass: {elev.ElevKlass}");
                            Console.WriteLine(new string('-', (40)));
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("******************************************");
                    Console.WriteLine();
                    Console.WriteLine("Tryck på enter för att återgå till huvudmenyn.");
                    Console.ReadKey();
                    break;

                default:
                    break;
            }
        }


        public static void HämtaUtAllaEleverIEnVissKlass(Individuellt_databasprojekt_DbContext Context)
        {
            Console.WriteLine("Välj en klass nedan för att se vilka elever som går i den klassen, genom att mata in namnet på just den klassen.");
            Console.WriteLine();

            var Klasser = from ElevTbl in Context.ElevTbl orderby ElevTbl.ElevKlass select ElevTbl;
            List<string> listaAvKlasser = new List<string>();

            foreach (var klass in Klasser)
            {
                listaAvKlasser.Add(klass.ElevKlass);
            }

            var resultat = listaAvKlasser.Distinct();

            foreach (var klass in resultat)
            {
                Console.WriteLine($"Klassens namn: {klass}");
                Console.WriteLine(new string('-', (40)));
            }

            string valAvKlass = "0";
            bool loopCase2 = true;
            while (loopCase2 == true)
            {
                valAvKlass = Console.ReadLine();

                if (listaAvKlasser.Contains(valAvKlass.ToUpper()))
                {
                    loopCase2 = false;
                }
                else
                {
                    Console.WriteLine("Ogiltigt val, försök igen.");
                }
            }

            Console.Clear();

            var ValdKlass = from ElevTbl in Context.ElevTbl where valAvKlass.ToUpper() == ElevTbl.ElevKlass orderby ElevTbl.ElevEfternamn select ElevTbl;

            Console.WriteLine("Nedan visas alla elever som går i klassen " + valAvKlass.ToUpper() + ".");
            Console.WriteLine();

            foreach (var elev in ValdKlass)
            {
                Console.WriteLine($"Elevens id: {elev.ElevId}");
                Console.WriteLine($"Elevens personnummer: {elev.ElevPersonnummer}");
                Console.WriteLine($"Elevens förnamn: {elev.ElevFörnamn}");
                Console.WriteLine($"Elevens efternamn: {elev.ElevEfternamn}");
                Console.WriteLine($"Elevens kön: {elev.ElevKön}");
                Console.WriteLine($"Elevens klass: {elev.ElevKlass}");
                Console.WriteLine(new string('-', (40)));
            }
            Console.WriteLine();
            Console.WriteLine("******************************************");
            Console.WriteLine();
            Console.WriteLine("Tryck på enter för att återgå till huvudmenyn.");
            Console.ReadKey();
        }


        public static void LäggaTillNyPersonal(Individuellt_databasprojekt_DbContext Context)
        {
            Console.WriteLine("Vilket förnamn ska den nya anställda ha?");
            string förnamnPåNyanställd = Console.ReadLine();
            Console.WriteLine("Vilket efternamn ska den nya anställda ha?");
            string efternamnPåNyanställd = Console.ReadLine();

            Console.Clear();
            string valKön = "0";
            string könPåNyanställd = "0";
            bool loopCase3 = true;
            while (loopCase3 == true)
            {
                Console.WriteLine("Vilket kön ska den nya anställda ha? Välj genom att mata in rätt siffra.");
                Console.WriteLine("1 --- Man.");
                Console.WriteLine("2 --- Kvinna.");
                valKön = Console.ReadLine();

                if (valKön == "1")
                {
                    könPåNyanställd = "Man";
                    loopCase3 = false;
                }
                else if (valKön == "2")
                {
                    könPåNyanställd = "Kvinna";
                    loopCase3 = false;
                }
                else
                {
                    Console.WriteLine("Ogiltigt val, försök igen.");
                }
            }

            Console.Clear();
            int yrkePåNyanställd = 0;
            loopCase3 = true;
            while (loopCase3 == true)
            {
                Console.WriteLine("Vilket yrke ska den nya anställda ha?");
                Console.WriteLine("1 --- Lärare.");
                Console.WriteLine("2 --- Vaktmästare.");
                Console.WriteLine("3 --- Administratör.");
                Console.WriteLine("4 --- Rektor.");
                try
                {
                    yrkePåNyanställd = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {


                }
                if (yrkePåNyanställd == 1 || yrkePåNyanställd == 2 || yrkePåNyanställd == 3 || yrkePåNyanställd == 4)
                {
                    loopCase3 = false;
                }
                else
                {
                    Console.WriteLine("Ogiltigt val, försök igen.");
                }
            }

            var Id = from PersonalTbl in Context.PersonalTbl orderby PersonalTbl.PersonalId ascending select PersonalTbl;

            Context.Add(new PersonalTbl()
            {
                PersonalId = Id.Count() + 1,
                PersonalFörnamn = förnamnPåNyanställd,
                PersonalEfternamn = efternamnPåNyanställd,
                PersonalKön = könPåNyanställd,
                PersonalYrkesrollFk = yrkePåNyanställd
            });

            Context.SaveChanges();

            string yrke = "";
            if (yrkePåNyanställd == 1)
            {
                yrke = "Lärare";
            }
            else if (yrkePåNyanställd == 2)
            {
                yrke = "Vaktmästare";
            }
            else if (yrkePåNyanställd == 3)
            {
                yrke = "Administratör";
            }
            else if (yrkePåNyanställd == 4)
            {
                yrke = "Rektor";
            }
            Console.WriteLine($"Du har nu lagt till en ny personalmedlem som har förnamnet {förnamnPåNyanställd}, efternamnet {efternamnPåNyanställd}, könet {könPåNyanställd} och yrket {yrke}.");
            Console.WriteLine();
            Console.WriteLine("******************************************");
            Console.WriteLine();
            Console.WriteLine("Tryck på enter för att återgå till huvudmenyn.");
            Console.ReadKey();
        }


        public static void HämtaUtPersonalen(Individuellt_databasprojekt_DbContext Context)
        {
            Console.WriteLine("Ska personalen sorteras på för eller efternamn? Mata in siffran som representerar ditt val." +
                           "\n1 --- Förnamn." +
                           "\n2 --- Efternamn.");

            string HämtaUtAllaIPersonalenVal = "0";
            bool loopCase1 = true;
            while (loopCase1 == true)
            {
                HämtaUtAllaIPersonalenVal = Console.ReadLine();

                if (HämtaUtAllaIPersonalenVal == "1" || HämtaUtAllaIPersonalenVal == "2")
                {
                    loopCase1 = false;
                }
                else
                {
                    Console.WriteLine("Ogiltigt val, försök igen.");
                }
            }

            Console.Clear();

            switch (HämtaUtAllaIPersonalenVal)
            {
                case "1":
                    Console.WriteLine("Ska personalen sorteras på ett stigande eller fallande vis? Mata in siffran som representerar ditt val." +
                         "\n1 --- Stigande." +
                         "\n2 --- Fallande.");

                    string SorteraPersonalenFörnamn = "0";
                    loopCase1 = true;
                    while (loopCase1 == true)
                    {
                        SorteraPersonalenFörnamn = Console.ReadLine();

                        if (SorteraPersonalenFörnamn == "1" || SorteraPersonalenFörnamn == "2")
                        {
                            loopCase1 = false;
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt val, försök igen.");
                        }
                    }

                    Console.Clear();

                    if (SorteraPersonalenFörnamn == "1")
                    {
                        var AllaIPersonalen = from PersonalTbl in Context.PersonalTbl orderby PersonalTbl.PersonalFörnamn ascending select PersonalTbl;

                        Console.WriteLine("Nedan visas alla i personalen, i bokstavsordning baserat på förnamn och på stigande vis.");
                        Console.WriteLine();
                        string yrke = "";

                        foreach (var person in AllaIPersonalen)
                        {
                            Console.WriteLine($"Personal medlemmens id: {person.PersonalId}");
                            Console.WriteLine($"Personal medlemmens förnamn: {person.PersonalFörnamn}");
                            Console.WriteLine($"Personal medlemmens efternamn: {person.PersonalEfternamn}");
                            Console.WriteLine($"Personal medlemmens kön: {person.PersonalKön}");
                            if (person.PersonalYrkesrollFk == 1)
                            {
                                yrke = "Lärare";
                            }
                            else if (person.PersonalYrkesrollFk == 2)
                            {
                                yrke = "Vaktmästare";
                            }
                            else if (person.PersonalYrkesrollFk == 3)
                            {
                                yrke = "Administratör";
                            }
                            else if (person.PersonalYrkesrollFk == 4)
                            {
                                yrke = "Rektor";
                            }
                            Console.WriteLine($"Personal medlemmens yrke: {yrke}");
                            Console.WriteLine(new string('-', (40)));
                        }
                    }
                    else if (SorteraPersonalenFörnamn == "2")
                    {
                        var AllaIPersonalen = from PersonalTbl in Context.PersonalTbl orderby PersonalTbl.PersonalFörnamn descending select PersonalTbl;

                        Console.WriteLine("Nedan visas alla i personalen, i bokstavsordning baserat på förnamn och på fallande vis.");
                        Console.WriteLine();
                        string yrke = "";

                        foreach (var person in AllaIPersonalen)
                        {
                            Console.WriteLine($"Personal medlemmens id: {person.PersonalId}");
                            Console.WriteLine($"Personal medlemmens förnamn: {person.PersonalFörnamn}");
                            Console.WriteLine($"Personal medlemmens efternamn: {person.PersonalEfternamn}");
                            Console.WriteLine($"Personal medlemmens kön: {person.PersonalKön}");
                            if (person.PersonalYrkesrollFk == 1)
                            {
                                yrke = "Lärare";
                            }
                            else if (person.PersonalYrkesrollFk == 2)
                            {
                                yrke = "Vaktmästare";
                            }
                            else if (person.PersonalYrkesrollFk == 3)
                            {
                                yrke = "Administratör";
                            }
                            else if (person.PersonalYrkesrollFk == 4)
                            {
                                yrke = "Rektor";
                            }
                            Console.WriteLine($"Personal medlemmens yrke: {yrke}");
                            Console.WriteLine(new string('-', (40)));
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("******************************************");
                    Console.WriteLine();
                    Console.WriteLine("Tryck på enter för att återgå till huvudmenyn.");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.WriteLine("Ska personalen sorteras på ett stigande eller fallande vis? Mata in siffran som representerar ditt val." +
                        "\n1 --- Stigande." +
                        "\n2 --- Fallande.");

                    string SorteraPersonalenEfternamn = "0";
                    loopCase1 = true;
                    while (loopCase1 == true)
                    {
                        SorteraPersonalenEfternamn = Console.ReadLine();

                        if (SorteraPersonalenEfternamn == "1" || SorteraPersonalenEfternamn == "2")
                        {
                            loopCase1 = false;
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt val, försök igen.");
                        }
                    }

                    Console.Clear();

                    if (SorteraPersonalenEfternamn == "1")
                    {
                        var AllaIPersonalen = from PersonalTbl in Context.PersonalTbl orderby PersonalTbl.PersonalEfternamn ascending select PersonalTbl;

                        Console.WriteLine("Nedan visas alla i personalen, i bokstavsordning baserat på efternamn och på stigande vis.");
                        Console.WriteLine();
                        string yrke = "";

                        foreach (var person in AllaIPersonalen)
                        {
                            Console.WriteLine($"Personal medlemmens id: {person.PersonalId}");
                            Console.WriteLine($"Personal medlemmens förnamn: {person.PersonalFörnamn}");
                            Console.WriteLine($"Personal medlemmens efternamn: {person.PersonalEfternamn}");
                            Console.WriteLine($"Personal medlemmens kön: {person.PersonalKön}");
                            if (person.PersonalYrkesrollFk == 1)
                            {
                                yrke = "Lärare";
                            }
                            else if (person.PersonalYrkesrollFk == 2)
                            {
                                yrke = "Vaktmästare";
                            }
                            else if (person.PersonalYrkesrollFk == 3)
                            {
                                yrke = "Administratör";
                            }
                            else if (person.PersonalYrkesrollFk == 4)
                            {
                                yrke = "Rektor";
                            }
                            Console.WriteLine($"Personal medlemmens yrke: {yrke}");
                            Console.WriteLine(new string('-', (40)));
                        }
                    }
                    else if (SorteraPersonalenEfternamn == "2")
                    {
                        var AllaIPersonalen = from PersonalTbl in Context.PersonalTbl orderby PersonalTbl.PersonalEfternamn descending select PersonalTbl;

                        Console.WriteLine("Nedan visas alla i personalen, i bokstavsordning baserat på efternamn och på fallande vis.");
                        Console.WriteLine();
                        string yrke = "";

                        foreach (var person in AllaIPersonalen)
                        {
                            Console.WriteLine($"Personal medlemmens id: {person.PersonalId}");
                            Console.WriteLine($"Personal medlemmens förnamn: {person.PersonalFörnamn}");
                            Console.WriteLine($"Personal medlemmens efternamn: {person.PersonalEfternamn}");
                            Console.WriteLine($"Personal medlemmens kön: {person.PersonalKön}");
                            if (person.PersonalYrkesrollFk == 1)
                            {
                                yrke = "Lärare";
                            }
                            else if (person.PersonalYrkesrollFk == 2)
                            {
                                yrke = "Vaktmästare";
                            }
                            else if (person.PersonalYrkesrollFk == 3)
                            {
                                yrke = "Administratör";
                            }
                            else if (person.PersonalYrkesrollFk == 4)
                            {
                                yrke = "Rektor";
                            }
                            Console.WriteLine($"Personal medlemmens yrke: {yrke}");
                            Console.WriteLine(new string('-', (40)));
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("******************************************");
                    Console.WriteLine();
                    Console.WriteLine("Tryck på enter för att återgå till huvudmenyn.");
                    Console.ReadKey();
                    break;

                default:
                    break;
            }
        }


        public static void SeHurMångaSomJobbarPåValfriAvdelning(Individuellt_databasprojekt_DbContext Context)
        {
            Console.WriteLine("Välj avdelning genom att mata in namnet på den, du kommer att få se alla i personalen som jobbar där.");
            Console.WriteLine("");

            var AllaIPersonalen = from PersonalTbl in Context.PersonalTbl orderby PersonalTbl.PersonalEfternamn ascending select PersonalTbl;
            List<string> listaAvAvdelningar = new List<string>();

            foreach (var avdelning in AllaIPersonalen)
            {
                listaAvAvdelningar.Add(avdelning.PersonalTillhörAvdelning);
            }

            var resultat = listaAvAvdelningar.Distinct();

            foreach (var avdelning in resultat)
            {
                Console.WriteLine($"Avdelningens namn: {avdelning}.");
                Console.WriteLine(new string('-', (40)));
            }

            string valAvAvdelning = "0";
            bool loopCase2 = true;
            while (loopCase2 == true)
            {
                valAvAvdelning = Console.ReadLine();

                if (listaAvAvdelningar.Contains(valAvAvdelning.ToUpper()))
                {
                    loopCase2 = false;
                }
                else
                {
                    Console.WriteLine("Ogiltigt val, försök igen.");
                }
            }

            Console.Clear();

            var ValdAvdelning = from PersonalTbl in Context.PersonalTbl where valAvAvdelning.ToUpper() == PersonalTbl.PersonalTillhörAvdelning orderby PersonalTbl.PersonalEfternamn ascending select PersonalTbl;

            Console.WriteLine("Nedan visas all personal som tillhör avdelningen " + valAvAvdelning.ToUpper() + ". Antal personer som jobbar på denna avdelning är " + ValdAvdelning.Count() + ".");
            Console.WriteLine();
            string yrke = "";

            foreach (var person in ValdAvdelning)
            {
                Console.WriteLine($"Personal medlemmens id: {person.PersonalId}");
                Console.WriteLine($"Personal medlemmens förnamn: {person.PersonalFörnamn}");
                Console.WriteLine($"Personal medlemmens efternamn: {person.PersonalEfternamn}");
                Console.WriteLine($"Personal medlemmens kön: {person.PersonalKön}");
                if (person.PersonalYrkesrollFk == 1)
                {
                    yrke = "Lärare";
                }
                else if (person.PersonalYrkesrollFk == 2)
                {
                    yrke = "Vaktmästare";
                }
                else if (person.PersonalYrkesrollFk == 3)
                {
                    yrke = "Administratör";
                }
                else if (person.PersonalYrkesrollFk == 4)
                {
                    yrke = "Rektor";
                }
                Console.WriteLine($"Personal medlemmens yrke: {yrke}");
                Console.WriteLine($"Personal medlemmens anställningsdatum: {person.PersonalBörjadeJobbaDatum}");
                Console.WriteLine($"Personal medlemmens avdelning: {person.PersonalTillhörAvdelning}");
                Console.WriteLine($"Personal medlemmens månadslön: {person.PersonalMånadslön}");
                Console.WriteLine(new string('-', (40)));
            }
            Console.WriteLine();
            Console.WriteLine("******************************************");
            Console.WriteLine();
            Console.WriteLine("Tryck på enter för att återgå till huvudmenyn.");
            Console.ReadKey();
        }


        public static void VisaEnListaPåAllaAktivaKurser(Individuellt_databasprojekt_DbContext Context)
        {
            var AllaAktivaKurser = from KursTbl in Context.KursTbl where KursTbl.ÄrKursenAktiv == true orderby KursTbl.Kursnamn ascending select KursTbl;

            Console.WriteLine("Följande kurser är aktiva: ");
            Console.WriteLine("");
            foreach (var kurs in AllaAktivaKurser)
            {
                Console.WriteLine($"Kursens namn: {kurs.Kursnamn}. Status: aktiv.");
                Console.WriteLine(new string('-', (40)));
            }
            Console.WriteLine();
            Console.WriteLine("******************************************");
            Console.WriteLine();

            var InteAktivaKurser = from KursTbl in Context.KursTbl where KursTbl.ÄrKursenAktiv == false orderby KursTbl.Kursnamn ascending select KursTbl;

            Console.WriteLine("Följande kurser är inte aktiva: ");
            Console.WriteLine("");
            foreach (var kurs in InteAktivaKurser)
            {
                Console.WriteLine($"Kursens namn: {kurs.Kursnamn}. Status: inte aktiv.");
                Console.WriteLine(new string('-', (40)));
            }
            Console.WriteLine();
            Console.WriteLine("******************************************");
            Console.WriteLine();
            Console.WriteLine("Tryck på enter för att återgå till huvudmenyn.");
            Console.ReadKey();
        }


        public static void UppdateraKorrigeraEnElevsInformationViaKoden(Individuellt_databasprojekt_DbContext Context)
        {
            var AllaEleverna = from ElevTbl in Context.ElevTbl orderby ElevTbl.ElevEfternamn ascending select ElevTbl;

            Console.WriteLine("Nedan visas alla elever, i bokstavsordning baserat på efternamn och på stigande vis. Välj elev genom att mata in elevens ID nummer.");
            Console.WriteLine();

            foreach (var elev in AllaEleverna)
            {
                Console.WriteLine($"Elevens id: {elev.ElevId}");
                Console.WriteLine($"Elevens personnummer: {elev.ElevPersonnummer}");
                Console.WriteLine($"Elevens förnamn: {elev.ElevFörnamn}");
                Console.WriteLine($"Elevens efternamn: {elev.ElevEfternamn}");
                Console.WriteLine($"Elevens kön: {elev.ElevKön}");
                Console.WriteLine($"Elevens klass: {elev.ElevKlass}");
                Console.WriteLine(new string('-', (40)));
            }

            int val = 0;
            bool loop = true;
            while (loop == true)
            {
                try
                {
                    val = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {

                }

                if (val <= AllaEleverna.Count() && val > 0)
                {
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Ogiltigt val, försök igen.");
                }
            }

            var ValdElev = from ElevTbl in Context.ElevTbl where ElevTbl.ElevId == val select ElevTbl;

            string uppdateraInfo = "";
            bool menyLoop = true;
            while (menyLoop == true)
            {
                Console.Clear();
                Console.WriteLine("Information om den valda eleven:");
                Console.WriteLine();
                foreach (var elev in ValdElev)
                {
                    Console.WriteLine($"Elevens id: {elev.ElevId}");
                    Console.WriteLine($"Elevens personnummer: {elev.ElevPersonnummer}");
                    Console.WriteLine($"Elevens förnamn: {elev.ElevFörnamn}");
                    Console.WriteLine($"Elevens efternamn: {elev.ElevEfternamn}");
                    Console.WriteLine($"Elevens kön: {elev.ElevKön}");
                    Console.WriteLine($"Elevens klass: {elev.ElevKlass}");
                    Console.WriteLine(new string('-', (40)));
                }
                Console.WriteLine();
                Console.WriteLine("******************************************");
                Console.WriteLine();
                Console.WriteLine("Välj ett alternativ genom att mata in rätt siffra.");
                Console.WriteLine("1 --- Ändra elevens personnummer.");
                Console.WriteLine("2 --- Ändra elevens förnamn.");
                Console.WriteLine("3 --- Ändra elevens efternamn.");
                Console.WriteLine("4 --- Ändra elevens kön.");
                Console.WriteLine("5 --- Ändra elevens klass.");
                Console.WriteLine("6 --- Återgå till huvudmenyn.");

                uppdateraInfo = Console.ReadLine();
                Console.Clear();
                switch (uppdateraInfo)
                {
                    case "1":
                        int nyttPersonnummer = 0;
                        string personnummerLängd = "12345678";
                        string nummer = "";

                        Console.WriteLine("Ange elevens nya personnummer.");

                        loop = true;
                        while (loop == true)
                        {
                            try
                            {
                                nyttPersonnummer = Convert.ToInt32(Console.ReadLine());
                                nummer = Convert.ToString(nyttPersonnummer);
                            }
                            catch
                            {

                            }

                            if (nummer.Length == personnummerLängd.Length)
                            {
                                loop = false;
                            }
                            else
                            {
                                Console.WriteLine("Ett fel uppstod! Personnumret måste innehålla 8 stycken siffror! Försök igen.");
                            }
                        }

                        foreach (var elev in ValdElev)
                        {
                            elev.ElevPersonnummer = nyttPersonnummer;
                        }
                        break;

                    case "2":
                        Console.WriteLine("Ange elevens nya förnamn.");
                        string nyttFörnamn = Console.ReadLine();

                        foreach (var elev in ValdElev)
                        {
                            elev.ElevFörnamn = nyttFörnamn;
                        }
                        break;

                    case "3":
                        Console.WriteLine("Ange elevens nya efternamn.");
                        string nyttEfternamn = Console.ReadLine();

                        foreach (var elev in ValdElev)
                        {
                            elev.ElevEfternamn = nyttEfternamn;
                        }
                        break;

                    case "4":
                        string nyttKön = "";

                        Console.WriteLine("Vilket kön ska eleven ha? Mata in rätt siffra.");
                        Console.WriteLine("1 --- Man.");
                        Console.WriteLine("2 --- Kvinna.");
                        Console.WriteLine("3 --- Annat.");

                        loop = true;
                        while (loop == true)
                        {
                            nyttKön = Console.ReadLine();

                            if (nyttKön == "1")
                            {
                                nyttKön = "Man";
                                loop = false;
                            }
                            else if (nyttKön == "2")
                            {
                                nyttKön = "Kvinna";
                                loop = false;
                            }
                            else if (nyttKön == "3")
                            {
                                nyttKön = "Annat";
                                loop = false;
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt val, försök igen.");
                            }
                        }

                        foreach (var elev in ValdElev)
                        {
                            elev.ElevKön = nyttKön;
                        }
                        break;

                    case "5":
                        var Klasser = from ElevTbl in Context.ElevTbl orderby ElevTbl.ElevKlass select ElevTbl;
                        List<string> listaAvKlasser = new List<string>();

                        foreach (var klass in Klasser)
                        {
                            listaAvKlasser.Add(klass.ElevKlass);
                        }

                        var resultat = listaAvKlasser.Distinct();

                        Console.WriteLine("Vilken Klass ska eleven gå i? Mata in namnet på någon av de existerande klasserna som visas nedan.");
                        Console.WriteLine();

                        foreach (var klass in resultat)
                        {
                            Console.WriteLine($"Klassens namn: {klass}");
                            Console.WriteLine(new string('-', (40)));
                        }

                        string valAvKlass = "0";
                        bool loopCase2 = true;
                        while (loopCase2 == true)
                        {
                            valAvKlass = Console.ReadLine();

                            if (listaAvKlasser.Contains(valAvKlass.ToUpper()))
                            {
                                loopCase2 = false;
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt val, försök igen.");
                            }
                        }

                        foreach (var elev in ValdElev)
                        {
                            elev.ElevKlass = valAvKlass.ToUpper();
                        }
                        break;

                    case "6":
                        Context.SaveChanges();
                        menyLoop = false;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
