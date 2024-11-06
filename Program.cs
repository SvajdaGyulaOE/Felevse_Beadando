using System.Text;
using System.Xml;


namespace Feleves
{
    public class Program
    {
        static void EsemenyKezelo(string note) { Console.WriteLine(note); }

        public static List<XMLKezelo> Sensor_xml = new List<XMLKezelo>();

        private static void XmlFeltolto()
        {
            XmlTextWriter writer = new XmlTextWriter("Sensor_Xml.xml", Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument(true);
            writer.WriteStartElement("Szenzor");

            foreach (var item in Sensor_xml)
            {
                writer.WriteStartElement("Sensor");
                writer.WriteStartAttribute("Id", item.Id.ToString());
                writer.WriteElementString("Homerseklet", item.Homerseklet.ToString());
                writer.WriteElementString("Paratartalom", item.Paratartalom.ToString());
                writer.WriteElementString("TulfolyoTartalyVizszint", item.TulfolyoTartalyVizszint.ToString());
                writer.WriteElementString("FolyovizSzintje", item.FolyovizSzintje.ToString());
                writer.WriteElementString("Allapot", item.Allapot.ToString());
                writer.WriteEndElement();
            }

            writer.Flush();
            writer.Close();
        } //Látrehozza és feltölti az XML file-t

        static void Main(string[] args)
        {
            Sensor sensor1 = new Sensor(13,23,5,11,AllapotEnum.Hibás);
            sensor1.ErtekValtozasEsemeny += EsemenyKezelo;
            Sensor sensor2 = new Sensor();
            sensor2.ErtekValtozasEsemeny += EsemenyKezelo;
            Sensor sensor3 = new Sensor();
            sensor3.ErtekValtozasEsemeny += EsemenyKezelo;
            Sensor sensor4 = new Sensor();
            sensor4.ErtekValtozasEsemeny += EsemenyKezelo;
            Sensor sensor5 = new Sensor();
            sensor5.ErtekValtozasEsemeny += EsemenyKezelo;
            Sensor sensor6 = new Sensor();
            sensor6.ErtekValtozasEsemeny += EsemenyKezelo;
            Sensor sensor7 = new Sensor();
            sensor7.ErtekValtozasEsemeny += EsemenyKezelo;
            Sensor sensor8 = new Sensor();
            sensor8.ErtekValtozasEsemeny += EsemenyKezelo;
            Sensor sensor9 = new Sensor();
            sensor9.ErtekValtozasEsemeny += EsemenyKezelo;
            Sensor sensor10 = new Sensor();
            sensor10.ErtekValtozasEsemeny += EsemenyKezelo;

            /*
            int Homerseklet, Paratartalom, TulfolyoTartalyVizszint, FolyovizSzintje, Id;
            AllapotEnum Allapot;

            XElement XmlDoc = XElement.Load("Sensor_Xml.xml");

            foreach (var item in XmlDoc.Descendants("Szenzor"))
            {
                Id = Convert.ToInt32(item.Attribute("id"));
                Homerseklet = Convert.ToInt32(item.Element("Homerseklet"));
                Paratartalom = Convert.ToInt32(item.Element("Paratartalom"));
                TulfolyoTartalyVizszint = Convert.ToInt32(item.Element("TulfolyoTartalyVizszint"));
                FolyovizSzintje = Convert.ToInt32(item.Element("FolyovizSzintje"));

                if (item.Element("Allapot").Value == nameof(AllapotEnum.Kikapcsolt))
                {

                }

            }
            */

            Console.WriteLine("Hány darab random generált szenzort szeretne?");




            XmlFeltolto();

            Console.ReadKey();
        }
    }
}
