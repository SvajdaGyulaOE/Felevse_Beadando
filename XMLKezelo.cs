using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Feleves
{
    public class XMLKezelo //Homerseklet, Paratartalom, TulfolyoTartalyVizszint, FolyovizSzintje, Allapot, Id, XKord, YKord, ZKord
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }

        [XmlElement("Homerseklet")]
        public int Homerseklet { get; set; }

        [XmlElement("Paratartalom")]
        public int Paratartalom { get; set; }

        [XmlElement("TulfolyoTartalyVizszint")]
        public int TulfolyoTartalyVizszint { get; set; }

        [XmlElement("FolyovizSzintje")]
        public int FolyovizSzintje { get; set; }

        [XmlElement("Allapot")]
        public AllapotEnum Allapot { get; set; }

        [XmlElement("X kordináta")]
        public int Xkord { get; set; }

        [XmlElement("Y kordináta")]
        public int Ykord { get; set; }
        
        [XmlElement("Z kordináta")]
        public int Zkord { get; set; }

        public XMLKezelo() { }

        public XMLKezelo(int id, int homerseklet, int paratartalom, int tulfolyoTartalyVizszint, int folyovizSzintje, AllapotEnum allapot, int xkord, int ykord, int zkord)
        {
            Id = id;
            Homerseklet = homerseklet;
            Paratartalom = paratartalom;
            TulfolyoTartalyVizszint = tulfolyoTartalyVizszint;
            FolyovizSzintje = folyovizSzintje;
            Allapot = allapot;
            Xkord = xkord;
            Ykord = ykord;
            Zkord = zkord;
        }

        public override string ToString()
        {
            return $"\nSzenzor id-je:\t{Id}\nHömérséklete:\t{Homerseklet}\nPáratartalma:\t{Paratartalom}\nTulfolyoTartalyVizszintje:\t{TulfolyoTartalyVizszint}\nFolyóvíz szintje:\t{FolyovizSzintje}\nÁllapota:\t{Allapot}\nKordinátája:\t{Xkord},{Ykord},{Zkord}";
        }
    }
}
