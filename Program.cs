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
        } //Bekéri az a adatokat és megcsinálja a szenzorokat       FORMAT EXCEPTION!!!
        private static void JsonFeltoltes()
        {
            string jsonString = JsonConvert.SerializeObject(Sensor_xml, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText("Json_Text.txt", jsonString);

            Console.WriteLine("Json file, létrelett hozva!");
        } //Létrehozza és feltölti a Json file-t
        private static void MostmarmegcsinaltamSzovalBenneHagyom()
        {

            Console.WriteLine("Melyik X pozicióhoz a legközelebbi kaka?");
            int X_keres = int.Parse(Console.ReadLine());

            Console.WriteLine("Melyik Y pozicióhoz a legközelebbi kaka?");
            int Y_keres = int.Parse(Console.ReadLine());

            Console.WriteLine("Melyik Z pozicióhoz a legközelebbi kaka?");
            int Z_keres = int.Parse(Console.ReadLine());

            List<double> tavolsagok = new List<double>();

            foreach (var item in Sensor_xml)
            {
                tavolsagok.Add(Math.Sqrt(Math.Pow(Convert.ToDouble(X_keres) - Convert.ToDouble(item.Xkord), 2) + Math.Pow(Convert.ToDouble(Y_keres) - Convert.ToDouble(item.Ykord), 2) + Math.Pow(Convert.ToDouble(Z_keres) - Convert.ToDouble(item.Zkord), 2)));
            }

            Console.WriteLine("\nA legközelebbi szenzor az a " + Sensor_xml[tavolsagok.IndexOf(tavolsagok.Min())].Id + " id szenor.");
        } //Lekérdezi a legközelebbi senzort a megadott koordinátákhoz

        static void Main(string[] args)
        {
            Mennyiség();

            XmlFeltolto();

            JsonFeltoltes();

            MostmarmegcsinaltamSzovalBenneHagyom();

            #region LINQ

            Console.WriteLine("\nHanyadik indexű szenzornak szeretnéd lekérdezni a hőmérsékletét?");
            int index_of = int.Parse(Console.ReadLine());

            var lekerdezes1 = from elem in Sensor_xml
                              where elem.Id == index_of
                              select elem;

            foreach (var elem in lekerdezes1) Console.WriteLine(elem);


            #endregion

            Console.ReadKey();
        }
    }
}
