using System.Text;
using System.Xml;
using Newtonsoft.Json;


namespace Feleves
{
    public class Program
    {
        static void EsemenyKezelo(string note) { Console.WriteLine(note); }

        public static List<XMLKezelo> Sensor_xml = new List<XMLKezelo>();

        public static int KoordinataX, KoordinataY, KoordinataZ, SzenzorokSzama;
        public static bool[,,] matrix;

        public static void XmlFeltolto()
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
        } //Létrehozza és feltölti az XML file-t
        public static void Mennyiség()
        {
            if (KoordinataX == 0 && KoordinataY == 0 && KoordinataZ == 0)
            {
                //Console.WriteLine("Nem létező koordináta rendszert attál meg!");
                throw new NemLetezoKoordiantaRendszerException();
            }

            matrix = new bool[KoordinataX, KoordinataY, KoordinataZ];

            if (SzenzorokSzama == 0)
            {
                //Console.WriteLine("Nem generáltattál le szenzorokat!");
                throw new NemGenerelSzenzorokException();
            }

            if ((SzenzorokSzama > KoordinataX * KoordinataY * KoordinataZ || SzenzorokSzama < 0))
            {
                throw new TulSokSzenzorException();
            }

            for (int i = 0; i < SzenzorokSzama; i++)
            {
                Sensor sensor = new Sensor();
            }
        } //Bekéri az a adatokat és megcsinálja a szenzorokat       FORMAT EXCEPTION!!! OVERFLOW EXCEPTION!!!
        public static void JsonFeltoltes()
        {
            string jsonString = JsonConvert.SerializeObject(Sensor_xml, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText("Json_Text.txt", jsonString);

        } //Létrehozza és feltölti a Json file-t
        public static void MostmarmegcsinaltamSzovalBenneHagyom()
        {

            Console.WriteLine("Melyik X pozicióhoz szeretné a legközelebbi szenzort lekérdezni?");
            int X_keres = int.Parse(Console.ReadLine());

            Console.WriteLine("Melyik Y pozicióhoz szeretné a legközelebbi szenzort lekérdezni?");
            int Y_keres = int.Parse(Console.ReadLine());

            Console.WriteLine("Melyik Z pozicióhoz szeretné a legközelebbi szenzort lekérdezni?");
            int Z_keres = int.Parse(Console.ReadLine());

            List<double> tavolsagok = new List<double>();

            foreach (var item in Sensor_xml)
            {
                tavolsagok.Add(Math.Sqrt(Math.Pow(Convert.ToDouble(X_keres) - Convert.ToDouble(item.Xkord), 2) + Math.Pow(Convert.ToDouble(Y_keres) - Convert.ToDouble(item.Ykord), 2) + Math.Pow(Convert.ToDouble(Z_keres) - Convert.ToDouble(item.Zkord), 2)));
            }

            Console.WriteLine("\nA legközelebbi szenzor az a " + Sensor_xml[tavolsagok.IndexOf(tavolsagok.Min())].Id + " id szenor.");
        } //Lekérdezi a legközelebbi senzort a megadott koordinátákhoz
        public static XMLKezelo IndexVisszaado(int index)
        {
            IEnumerable<XMLKezelo> lekerdezes1 = from elem in Sensor_xml
                              where elem.Id == index
                              select elem;

            return lekerdezes1.First();
        }

        public static XMLKezelo LegnagyobbHomerseklet()
        {
            IEnumerable<XMLKezelo> lekerdezes2 = from elem in Sensor_xml
                              orderby elem.Homerseklet descending
                              select elem;
            return lekerdezes2.First();
        }

        public static XMLKezelo LegKissebbHomerseklet()
        {
            IEnumerable<XMLKezelo> lekerdezes3 = from elem in Sensor_xml
                              orderby elem.Homerseklet ascending
                              select elem;

            return lekerdezes3.First();
        }

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Mekkora legyen a koordináta rendszer X tengelyen?");
                KoordinataX = int.Parse(Console.ReadLine());

            } while (KoordinataX < 1);
            do
            {
                Console.WriteLine("Mekkora legyen a koordináta rendszer Y tengelyen?");
                KoordinataY = int.Parse(Console.ReadLine());

            } while (KoordinataY < 1);
            do
            {
                Console.WriteLine("Mekkora legyen a koordináta rendszer Z tengelyen?");
                KoordinataZ = int.Parse(Console.ReadLine());

            } while (KoordinataZ < 1);
            do
            {
                Console.WriteLine("Hány darab random generált szenzort szeretne?");
                SzenzorokSzama = int.Parse(Console.ReadLine());
            } while (SzenzorokSzama > KoordinataX * KoordinataY * KoordinataZ || SzenzorokSzama < 1);

            Sensor.ErtekValtozasEsemeny += EsemenyKezelo;

            Mennyiség();

            XmlFeltolto();

            Console.WriteLine("Xml file, létrehozva!");

            JsonFeltoltes();

            Console.WriteLine("Json file, létrelett hozva!");

            MostmarmegcsinaltamSzovalBenneHagyom();

            #region LINQ

            Console.WriteLine("\nHanyadik indexű szenzornak szeretnéd lekérdezni az adatait?");
            int index_of = int.Parse(Console.ReadLine());

            Console.WriteLine(IndexVisszaado(index_of));

            Console.WriteLine("\n\nLegnagyobb hőmérsékletű szenzor: ");

            Console.WriteLine(LegnagyobbHomerseklet());

            Console.WriteLine("\n\nLegkissebb hőmérsékletű szenzor: ");

            Console.WriteLine(LegKissebbHomerseklet());

            #region Szenzor állapotok lekérdezése

            Console.WriteLine("\n\nMűködő szenzorok: ");

            IEnumerable<int> mukodoSzenzorok = Sensor_xml.Where(g => g.Allapot == AllapotEnum.Működik).Select(g => g.Id);

            foreach (var elem in mukodoSzenzorok) { Console.Write(elem + ", "); }

            Console.WriteLine("\n\nKikapcsolt szenzorok: ");

            IEnumerable<int> kikapcsoltSzenzorok = Sensor_xml.Where(g => g.Allapot == AllapotEnum.Kikapcsolt).Select(g => g.Id);

            foreach (var elem in kikapcsoltSzenzorok) { Console.Write(elem + ", "); }

            Console.WriteLine("\n\nHibás szenzorok: ");

            IEnumerable<int> HibasSzenzorok = Sensor_xml.Where(g => g.Allapot == AllapotEnum.Hibás).Select(g => g.Id);

            foreach (var elem in HibasSzenzorok) { Console.Write(elem + ", "); }

            Console.WriteLine("\n\nNem elérhető szenzorok: ");

            IEnumerable<int> NemElerhetoSzenzorok = Sensor_xml.Where(g => g.Allapot == AllapotEnum.NemElerhető).Select(g => g.Id);

            foreach (var elem in NemElerhetoSzenzorok) { Console.Write(elem + ", "); }

            #endregion

            #endregion

            Console.ReadKey();
        }
    }
}
