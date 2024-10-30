using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Feleves
{
    public class XMLKezelo //Homerseklet, Paratartalom, TulfolyoTartalyVizszint, FolyovizSzintje, Allapot
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

        public XMLKezelo() { }

        public XMLKezelo(int id, int homerseklet, int paratartalom, int tulfolyoTartalyVizszint, int folyovizSzintje, AllapotEnum allapot)
        {
            Id = id;
            Homerseklet = homerseklet;
            Paratartalom = paratartalom;
            TulfolyoTartalyVizszint = tulfolyoTartalyVizszint;
            FolyovizSzintje = folyovizSzintje;
            Allapot = allapot;
        }
    }
}
