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
            //beolvas();
            //masodik();
            
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

        public static void masodik()
        {
            /*
             - ki kellett gyűjteni azokat a városokat, amiknek a kódja meg van adva
             - azok közül ki kell venni a legkésőbbit és ki kell írni
             */
            Console.WriteLine("\n2.)feladat\n");
            Console.WriteLine("Adja meg az egyik város kódját:");
            string kapottKod = Console.ReadLine();

            List<Adat> adatokVarosSzerint = new List<Adat>();

            foreach (Adat item in adatok)
            {
                if (item.telepules == kapottKod)
                {
                    adatokVarosSzerint.Add(item);
                }
            }

            Adat max = adatokVarosSzerint[0];

            foreach (Adat item in adatokVarosSzerint)
            {
                if (item.ido > max.ido)
                {
                    max = item;
                }
            }

            Console.WriteLine($"Az utolsó mérési adat a megadott településről {max.ido.Hours}:{max.ido.Minutes} - kor érkezett.");
        }

        public static TimeSpan convertStringToTimestamp(string szoveg) // 0000
        {
            int ora = int.Parse(szoveg.Substring(0,2));
            int perc = int.Parse(szoveg.Substring(2,2));
            return new TimeSpan(ora, perc, 00);
        }

        public static void maxKivalasztas()
        {
            int[] tomb = { 1, 1234, 3, 4, 2, 6, 67 };
            int max = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] > max)
                {
                    max = tomb[i];
                }
            }
            Console.WriteLine(max);
        }
    }
}
