using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Feleves
{ 
    public class Sensor
    {
        private Random Rnd = new Random();
        private static int IdCounter = 1;

        int Homerseklet, Paratartalom, TulfolyoTartalyVizszint, FolyovizSzintje, Id, XKord, YKord, ZKord;
        AllapotEnum Allapot;

        public Sensor(int homerseklet, int paratartalom, int tulfolyoTartalyVizszint, int folyovizSzintje, AllapotEnum allapot,int xKord,int yKord,int zKord)
        {
            Homerseklet = homerseklet;
            Paratartalom = paratartalom;
            TulfolyoTartalyVizszint = tulfolyoTartalyVizszint;
            FolyovizSzintje = folyovizSzintje;
            Allapot = allapot;
            XKord = xKord;
            YKord = yKord;
            ZKord = zKord;
            ErtekValtozas();
            Id = IdCounter++;
            XMLKezelo placebo = new XMLKezelo(Id,Homerseklet,Paratartalom,TulfolyoTartalyVizszint,FolyovizSzintje,Allapot);
            Program.Sensor_xml.Add(placebo);
        }
        public Sensor()
        {
            Homerseklet = Rnd.Next(0,101);
            Paratartalom = Rnd.Next(0,101);
            TulfolyoTartalyVizszint = Rnd.Next(0, 101);
            FolyovizSzintje = Rnd.Next(0, 101);
            Allapot = AllapotEnum.Mukodik;
            Id = IdCounter++;

            int x = Program.KoordinataX;
            int y = Program.KoordinataY;
            int z = Program.KoordinataZ;

            do
            {
                XKord = Rnd.Next(1, x + 1);
                YKord = Rnd.Next(1, y + 1);
                ZKord = Rnd.Next(1, z + 1);
            } while (Program.matrix[XKord - 1, YKord - 1, ZKord - 1] == true);

            Program.matrix[XKord - 1, YKord - 1, ZKord - 1] = true;
            
            RandomSensorMegadás();
            XMLKezelo placebo = new XMLKezelo(Id, Homerseklet, Paratartalom, TulfolyoTartalyVizszint, FolyovizSzintje, Allapot);
            Program.Sensor_xml.Add(placebo);
        }

        public delegate void Sensor_Delegate(string note);
        public static event Sensor_Delegate ErtekValtozasEsemeny;

        private void ErtekValtozas()
        {
            if (ErtekValtozasEsemeny != null) ErtekValtozasEsemeny($"Érték megadás történt!");
        }

         void RandomSensorMegadás()
        {
            if (ErtekValtozasEsemeny != null) ErtekValtozasEsemeny($"Random Generált Szenzor lett kihelyezve!");
        }

        //Delegált bekérése a ctor ban!
     
    }
}
