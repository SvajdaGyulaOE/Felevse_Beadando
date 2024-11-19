using System.Text;
using System.Xml;
using Newtonsoft.Json;


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
            writer.Formatting = System.Xml.Formatting.Indented;
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

            Console.WriteLine("Xml file, létrehozva!");
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
        } //Bekéri az a adatokat és megcsinálja a szenzorokat
        private static void JsonFeltoltes()
        {
            string jsonString = JsonConvert.SerializeObject(Sensor_xml, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText("Json_Text.txt", jsonString);

            Console.WriteLine("Json file, létrelett hozva!");
        } //Létrehozza és feltölti a Json file-t

        static void Main(string[] args)
        {
            Mennyiség();

            XmlFeltolto();

            JsonFeltoltes();

            Console.ReadKey();
        }
    }
}
