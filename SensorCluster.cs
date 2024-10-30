using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves
{
    public class SensorCluster
    {
        public static bool LetezikSensorCluster = false;
        static int XMaximum, YMaximum, ZMaximum;

        Sensor? Sensorok;
        int X, Y, Z;

        public SensorCluster(Sensor sensorok, int x, int y, int z, int xMaximum, int yMaximum, int zMaximum)
        {
            Sensorok = sensorok;

            if(xMaximum < 2147483647 && xMaximum > 0) XMaximum = xMaximum;
            else throw new NemJolMegadottAdatException();

            if(yMaximum < 2147483647 && yMaximum > 0) YMaximum = yMaximum;
            else throw new NemJolMegadottAdatException();

            if(zMaximum < 2147483647 && zMaximum > 0) ZMaximum = zMaximum;
            else throw new NemJolMegadottAdatException();

            LetezikSensorCluster = true;

            if (x < XMaximum && x > 0) X = x;
            else throw new NemJolMegadottAdatException();

            if (y < YMaximum && y > 0) Y = y;
            else throw new NemJolMegadottAdatException();

            if (z < ZMaximum && z > 0) Z = z;
            else throw new NemJolMegadottAdatException();
        }

        public SensorCluster(Sensor sensorok, int x, int y, int z)
        {
            if (LetezikSensorCluster)
            {
                Sensorok = sensorok;

                if (x < XMaximum && x > 0) X = x;
                else throw new NemJolMegadottAdatException();

                if (y < YMaximum && y > 0) Y = y;
                else throw new NemJolMegadottAdatException();

                if (z < ZMaximum && z > 0) Z = z;
                else throw new NemJolMegadottAdatException();
            }
            else throw new NincsSensorClusterException();
        }
        public SensorCluster(int xMaximum, int yMaximum, int zMaximum)
        {
            if (xMaximum < 2147483647 && xMaximum > 0) XMaximum = xMaximum;
            else throw new NemJolMegadottAdatException();

            if (yMaximum < 2147483647 && yMaximum > 0) YMaximum = yMaximum;
            else throw new NemJolMegadottAdatException();

            if (zMaximum < 2147483647 && zMaximum > 0) ZMaximum = zMaximum;
            else throw new NemJolMegadottAdatException();

            LetezikSensorCluster = true;
        }
















    }
}