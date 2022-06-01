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
            flagaU�amka = false,
            flagaPrzecinka = false,
            flagaWyniku = false,
            flagaUjemnegoZnaku = false
            ;
        double wynik = 0;
        double?
            pierwsza = null,
            druga = null
            ;
        string dzia�anie = null;
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
                if (flagaU�amka)
                    ;
                else
                    flagaPrzecinka = true;
            else if (flagaPrzecinka)
            {
                Wynik += "," + znak;
                flagaPrzecinka = false;
                flagaU�amka = true;
            }
            else
                Wynik += znak;
        }
        public void Zmie�Znak()
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
            dzia�anie = null;
        }
        public void Dzia�anie(string dzia�anie)
        {
            if (pierwsza == null)
            {
                pierwsza = wynik;
                this.dzia�anie = dzia�anie;
                Zeruj();
            }
            else
            {
                druga = wynik;
                Wykonaj();
                this.dzia�anie = dzia�anie;
            }
        }
        public void Wykonaj()
        {
            if (dzia�anie == null)
                return;
            else if (druga == null)
                druga = wynik;

            if (dzia�anie == "+")
                Wynik = Convert.ToString(pierwsza + druga);
            else if (dzia�anie == "-")
                Wynik = Convert.ToString(pierwsza - druga);
            else if (dzia�anie == "*")
                Wynik = Convert.ToString(pierwsza * druga);
            else if (dzia�anie == "/")
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
