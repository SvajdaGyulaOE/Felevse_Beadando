using System.Text;
using System.Xml;


namespace Feleves
{
    public class Program
    {
        static void EsemenyKezelo(string note) { Console.WriteLine(note); }

        public static List<XMLKezelo> Sensor_xml = new List<XMLKezelo>();

        public static int KoordinataX, KoordinataY, KoordinataZ;
        public static bool[,,] matrix;

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
        } //Létrehozza és feltölti az XML file-t
        private static void Mennyiség()
        {
            do
            {
                Console.WriteLine("Mekkora legyen a koordináta rendszer X tengelyen?");
                KoordinataX = int.Parse(Console.ReadLine());

            } while (KoordinataX < 0);
            do
            {
                Console.WriteLine("Mekkora legyen a koordináta rendszer Y tengelyen?");
                KoordinataY = int.Parse(Console.ReadLine());

            } while (KoordinataY < 0);
            do
            {
                Console.WriteLine("Mekkora legyen a koordináta rendszer Z tengelyen?");
                KoordinataZ = int.Parse(Console.ReadLine());

            } while (KoordinataZ < 0);

            matrix = new bool[KoordinataX, KoordinataY, KoordinataZ];

            int placebo1;

            do
            {
                Console.WriteLine("Hány darab random generált szenzort szeretne?");
                placebo1 = int.Parse(Console.ReadLine());
            } while (placebo1 > KoordinataX * KoordinataY * KoordinataZ);

            Sensor.ErtekValtozasEsemeny += EsemenyKezelo;

            for (int i = 0; i < placebo1; i++)
            {
                Sensor sensor = new Sensor();
            }      
        }

        static void Main(string[] args)
        {
            

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

            



            Mennyiség();

            XmlFeltolto();

            Console.ReadKey();
        }
    }
}
