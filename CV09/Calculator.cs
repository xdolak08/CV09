using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV09
{
    class Calculator
    {
        private Stav _stav = Stav.PrvniCislo;
        public String Display { get; set; }
        public String Pamet { get; set; }

        private string prvni = "";
        private Operace operace;
        private string druhy = "";
        private string vysledek = "";

        public void Tlacitko(String tlacitko)
        {

            var cislo = "";

            switch (tlacitko)
            {
                case "0":
                    cislo += "0";
                    break;
                case "1":
                    cislo += "1";
                    break;
                case "2":
                    cislo += "2";
                    break;
                case "3":
                    cislo += "3";
                    break;
                case "4":
                    cislo += "4";
                    break;
                case "5":
                    cislo += "5";
                    break;
                case "6":
                    cislo += "6";
                    break;
                case "7":
                    cislo += "7";
                    break;
                case "8":
                    cislo += "8";
                    break;
                case "9":
                    cislo += "9";
                    break;

                case "+":
                    _stav = Stav.Operace;
                    operace = Operace.Plus;
                    break;
                case "-":
                    _stav = Stav.Operace;
                    operace = Operace.Minus;
                    break;
                case "*":
                    _stav = Stav.Operace;
                    operace = Operace.Krat;
                    break;
                case "/":
                    _stav = Stav.Operace;
                    operace = Operace.Deleni;
                    break;
                case "=":
                    _stav = Stav.Vysledek;
                    vysledek = FindAnswer();
                    Display = vysledek;
                    prvni = "";
                    druhy = "";
                    vysledek = "";

                    break;
                case "+-":
                    if (Display != "")
                    {
                        if (_stav == Stav.PrvniCislo)
                        {
                            var tmp = Convert.ToDouble(prvni) * -1;
                            prvni = "" + tmp;
                        }
                        if (_stav == Stav.DruheCislo)
                        {
                            var tmp = Convert.ToDouble(druhy) * -1;
                            druhy = "" + tmp;
                        }
                    }
                    break;

                case "CE":
                    if (_stav == Stav.PrvniCislo)
                    {
                        prvni = "";
                        Display = prvni;
                    }
                    if (_stav == Stav.DruheCislo)
                    {
                        druhy = "";
                        Display = druhy;
                    }

                    break;
                case "C":
                    _stav = Stav.PrvniCislo;
                    Display = vysledek;
                    prvni = "";
                    druhy = "";
                    vysledek = "";
                    break;
                case "<=":
                    if (_stav == Stav.PrvniCislo)
                    {
                        prvni = prvni.Substring(0, prvni.Length - 1);
                        Display = prvni;
                    }
                    if (_stav == Stav.DruheCislo)
                    {
                        druhy = prvni.Substring(0, druhy.Length - 1);
                        Display = druhy;
                    }

                    break;

                case "MS":
                    Pamet = Display;
                    break;

                case "MR":
                    if (_stav == Stav.PrvniCislo)
                    {
                        prvni = Pamet;
                    }
                    if (_stav == Stav.DruheCislo)
                    {
                        druhy = Pamet;
                    }

                    Display = Pamet;
                    break;

                case "MC":
                    Pamet = "";
                    break;

                case "M+":
                    Pamet += vysledek;
                    break;

                case "M-":
                     
                    break;

                default:
                    break;

            }

            switch (_stav)
            {
                case Stav.PrvniCislo:
                    prvni += cislo;
                    Display = prvni;
                    break;
                case Stav.DruheCislo:
                    druhy += cislo;
                    Display = druhy;
                    break;
                case Stav.Operace:
                    _stav = Stav.DruheCislo;
                    break;
                case Stav.Vysledek:
                    _stav = Stav.PrvniCislo;
                    break;
            }



        }

        private enum Operace
        {
            Plus,
            Minus,
            Krat,
            Deleni
        };

        private enum Stav
        {
            PrvniCislo,
            Operace,
            DruheCislo,
            Vysledek
        };

        private string FindAnswer()
        {
            var o = Convert.ToDouble(prvni);
            var t = Convert.ToDouble(druhy);
            double ans = 0;

            switch (operace)
            {
                case Operace.Plus:
                    ans = o + t;
                    break;
                case Operace.Minus:
                    ans = o - t;
                    break;
                case Operace.Krat:
                    ans = o * t;
                    break;
                case Operace.Deleni:
                    ans = o / t;
                    break;
            }

            return "" + ans;
        }

    }
}
