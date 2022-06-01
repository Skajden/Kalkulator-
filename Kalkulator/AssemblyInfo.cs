using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NET_INIS4_PR2._2_z2
{
    public class Dane : INotifyPropertyChanged
    {
        bool
            flagaU³amka = false,
            flagaPrzecinka = false,
            flagaWyniku = false,
            flagaUjemnegoZnaku = false
            ;
        double wynik = 0;
        double?
            pierwsza = null,
            druga = null
            ;
        string dzia³anie = null;
        public string Wynik
        {
            get
            {
                if (flagaUjemnegoZnaku && wynik == 0)
                    return "-" + Convert.ToString(wynik);
                else
                    return Convert.ToString(wynik);
            }
            set
            {
                wynik = Convert.ToDouble(value);
                OnPropertyChanged();
            }
        }


        

        public void Dopisz(string znak)
        {
            if (flagaWyniku)
                Zeruj();
            if (znak == ",")
                if (flagaU³amka)
                    ;
                else
                    flagaPrzecinka = true;
            else if (flagaPrzecinka)
            {
                Wynik += "," + znak;
                flagaPrzecinka = false;
                flagaU³amka = true;
            }
            else
                Wynik += znak;
        }
        public void ZmieñZnak()
        {
            if (flagaWyniku)
                Zeruj();
            flagaUjemnegoZnaku = !flagaUjemnegoZnaku;
            Wynik = Convert.ToString(-wynik);
        }
        public void Zeruj()
        {
            flagaPrzecinka = flagaPrzecinka = flagaWyniku = flagaUjemnegoZnaku = false;
            druga = null;
            Wynik = "0";
        }
        public void Resetuj()
        {
            Zeruj();
            pierwsza = null;
            dzia³anie = null;
        }
        public void Dzia³anie(string dzia³anie)
        {
            if (pierwsza == null)
            {
                pierwsza = wynik;
                this.dzia³anie = dzia³anie;
                Zeruj();
            }
            else
            {
                druga = wynik;
                Wykonaj();
                this.dzia³anie = dzia³anie;
            }
        }
        public void Wykonaj()
        {
            if (dzia³anie == null)
                return;
            else if (druga == null)
                druga = wynik;

            if (dzia³anie == "+")
                Wynik = Convert.ToString(pierwsza + druga);
            else if (dzia³anie == "-")
                Wynik = Convert.ToString(pierwsza - druga);
            else if (dzia³anie == "*")
                Wynik = Convert.ToString(pierwsza * druga);
            else if (dzia³anie == "/")
                Wynik = Convert.ToString(pierwsza / druga);

            flagaWyniku = true;
            pierwsza = wynik;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
