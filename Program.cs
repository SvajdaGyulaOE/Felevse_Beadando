using System.Xml.Linq;

namespace Feleves
{
    public class Program
    {
        static void EsemenyKezelo(string note) { Console.WriteLine(note); }

        public static List<XMLKezelo> Sensor_xml = new List<XMLKezelo>();

        static void Main(string[] args)
        {
            int Homerseklet, Paratartalom, TulfolyoTartalyVizszint, FolyovizSzintje, Id;
            AllapotEnum Allapot;

            XElement XmlDoc = XElement.Load("Sensor_Xml.xml");

            foreach (var item in XmlDoc.Descendants("Szenzor"))
            {
                Id = item.Attribute().Value;
            }

            /*
            List < Room > rooms = new List<Room>();
            XElement xdoc = XElement.Load("terem.xml");
            foreach (var item in xdoc.Descendants("oneRoom"))
            {
                id = item.Attribute("id").Value;
                width = Convert.ToInt32(item.Element("width").Value);
                height = Convert.ToInt32(item.Element("height").Value);
                Room seged = new Room(id, width, height);
                rooms.Add(seged);
            }
            Console.WriteLine("A termek azonosítói:");

            */


        }
    }
}
