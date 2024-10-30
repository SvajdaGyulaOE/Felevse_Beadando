using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Feleves
{ 
    public class Sensor
    {
        private Random Rnd = new Random();
        private static int IdCounter = 0;

        int Homerseklet, Paratartalom, TulfolyoTartalyVizszint, FolyovizSzintje,Id;
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
            RandomSensorMegadás();
        }

        public delegate void Sensor_Delegate(string note);
        public event Sensor_Delegate ErtekValtozasEsemeny;

        private void ErtekValtozas()
        {
            if (ErtekValtozasEsemeny != null) ErtekValtozasEsemeny($"Érték megadás történt!");
        }

        private void RandomSensorMegadás()
        {
            if (ErtekValtozasEsemeny != null) ErtekValtozasEsemeny($"Random Generált Szenzor lett kihelyezve");
        }


        /*
         
        XElement xdoc = XElement.Load("terem.xml");
            foreach (var item in xdoc.Descendants("oneRoom"))
            {
                id = item.Attribute("id").Value;
                width = Convert.ToInt32(item.Element("width").Value);
                height = Convert.ToInt32(item.Element("height").Value);
                Room seged = new Room(id, width, height);
                rooms.Add(seged);
            }
         
         */
    }
}
