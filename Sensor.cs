using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves
{ 
    public class Sensor
    {
        private Random Rnd = new Random();

        int Homerseklet, Paratartalom, TulfolyoTartalyVizszint, FolyovizSzintje;
        AllapotEnum Allapot;

        public Sensor(int homerseklet, int paratartalom, int tulfolyoTartalyVizszint, int folyovizSzintje, AllapotEnum allapot)
        {
            Homerseklet = homerseklet;
            ErtekValtozas();
            Paratartalom = paratartalom;
            ErtekValtozas();
            TulfolyoTartalyVizszint = tulfolyoTartalyVizszint;
            ErtekValtozas();
            FolyovizSzintje = folyovizSzintje;
            ErtekValtozas();
            Allapot = allapot;
            ErtekValtozas();
        }
        public Sensor()
        {
            Homerseklet = Rnd.Next(0,101);
            Paratartalom = Rnd.Next(0,101);
            TulfolyoTartalyVizszint = Rnd.Next(0, 101);
            FolyovizSzintje = Rnd.Next(0, 101);
            Allapot = AllapotEnum.Mukodik;
        }

        public delegate void Sensor_Delegate(string note);
        public event Sensor_Delegate ErtekValtozasEsemeny;

        private void ErtekValtozas()
        {
            if (ErtekValtozasEsemeny != null) ErtekValtozasEsemeny($"Érték megadás történt!");
        }
    }
}
