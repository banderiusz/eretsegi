using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace erettsegi
{
    public static class Extensions
    {
        public static void ToConsole<T>(this IEnumerable<T> data)
        {
            foreach (var item in data)
            {
                Console.Write($"{ item }, ");
            }
        }
    }
    class Program
    {
        public static List<Adat> adatok = new List<Adat>();
        static void Main(string[] args)
        {
            beolvas();
            //masodik();
            //TimeSpan otora = new TimeSpan(5, 0, 0);   
            //TimeSpan ketoraa = new TimeSpan(2, 0, 0);
            //Console.WriteLine(otora.Hours);
            // harmadik();
            // negyedik();
            //otodik();
            hatos();
        }

        public static void beolvas()
        {
            StreamReader sr = new StreamReader("tavirathu13.txt");
            while (!sr.EndOfStream)
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

        public static void harmadik()
        {
            Console.WriteLine("\n 3.) feladat");
            Adat max = adatok[0];

            foreach (Adat item in adatok)
            {
                if (item.homerseklet > max.homerseklet)
                {
                    max = item;
                }
            }

            Adat min = adatok[0];

            foreach (Adat item in adatok)
            {
                if (item.homerseklet < min.homerseklet)
                {
                    min = item;
                }
            }

            Console.WriteLine($"min: {min}");
            Console.WriteLine($"max: {max}");
        }

        public static void negyedik()
        {
            Console.WriteLine("4. feladat");

            for (int i = 0; i < adatok.Count; i++)
            {
                if ((int.Parse(adatok[i].szelerosseg) == 00) && ((int.Parse(adatok[i].szelirany) == 000))) {
                    Console.WriteLine($"{adatok[i].telepules} {adatok[i].ido}");
                }
            }
        }

        public static void otodik()
        {
            List<string> telepulesek = new List<string>();
            foreach (Adat adat in adatok)
            {
                bool tartalmazzaE = telepulesek.Contains(adat.telepules);

                if (!tartalmazzaE)
                {
                    telepulesek.Add(adat.telepules);
                }
            }

            foreach (string telepules in telepulesek)
            {
                List<int> homersekletek = new List<int>();
                List<int> hours = new List<int>();
                int minHo = 1000;
                int maxHo = 0;
                foreach (Adat adat in adatok)
                {

                }

                var eredmeny = (hours.Count == 4) ? Math.Round(homersekletek.Average()).ToString() : "Na";
                Console.WriteLine($"{ telepules } Középhőmérséklet: { eredmeny } Hőmérséklet-ingadozás: {maxHo - minHo}");
            }
        }

        public static void hatos()
        {
            List<string> telepulesek = new List<string>();

            foreach (Adat adat in adatok)
            {
                bool tartalmazzaE = telepulesek.Contains(adat.telepules);

                if (!tartalmazzaE)
                {
                    telepulesek.Add(adat.telepules);
                }
            }

            foreach (string telepules in telepulesek)
            {
                StreamWriter sw = new StreamWriter(telepules + ".txt");
                sw.WriteLine(telepules);
                foreach (Adat adat in adatok)
                {
                    if (adat.telepules == telepules)
                    {
                        int erosseg = int.Parse(adat.szelerosseg);

                        sw.WriteLine($"{adat.ido} {kettoskeresztStringGenerator(erosseg)}");
                    }

                }
                sw.Close();
            }
        }

        public static string kettoskeresztStringGenerator (int szam) {
            string kettoskeresztString = "";
            for (int i = 0; i < szam; i++)
            {
                kettoskeresztString = kettoskeresztString + "#";
                //kettoskeresztString.Append('#');
            }
            return kettoskeresztString;
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
