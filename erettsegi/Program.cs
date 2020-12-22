using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace erettsegi
{
    public class Adat
    {
        public string telepules { get; set; }
        public TimeSpan ido { get; set; }
        public string szelirany { get; set; }
        public string szelerosseg { get; set; }
        public int homerseklet { get; set; }

        public override string ToString()
        {
            return $"település:{telepules}, idő:{ido.ToString()}, szélirány:{szelirany}, szélerősség:{szelerosseg}, hőmérséklet:{homerseklet}";
        }
    }

    class Program
    {
        public static List<Adat> adatok = new List<Adat>();
        static void Main(string[] args)
        {
            beolvas();
            foreach (var item in adatok)
            {
                Console.WriteLine(item);
            }
        }

        public static void beolvas()
        {
            StreamReader sr = new StreamReader("tavirathu13.txt");
            while(!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(' ');
                Adat adat = new Adat()
                {
                    telepules = sor[0],
                    ido = convertStringToTimestamp(sor[1]),
                    szelirany = sor[2].Substring(0, 3),
                    szelerosseg = sor[2].Substring(3, 2),
                    homerseklet = int.Parse(sor[3])
                };
                adatok.Add(adat);
            }
            sr.Close();
        }

        public static TimeSpan convertStringToTimestamp(string szoveg) // 0000
        {
            int ora = int.Parse(szoveg.Substring(0,2));
            int perc = int.Parse(szoveg.Substring(2,2));
            return new TimeSpan(ora, perc, 00);
        }
    }
}
