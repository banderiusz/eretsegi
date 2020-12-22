using System;
using System.IO;

namespace erettsegi
{
    public class Adat
    {
        public string telepules { get; set; }
        public TimeSpan ido { get; set; }
        public string szelirany { get; set; }
        public string szelerosseg { get; set; }
        public int homerseklet { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            convertStringToTimestamp("1122");
        }

        public static void beolvas()
        {
            StreamReader sr = new StreamReader("tavirathu13");
            while(!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(' ');

            }
        }

        public static TimeSpan convertStringToTimestamp(string szoveg) // 0000
        {
            int ora = int.Parse(szoveg.Substring(0,2));
            int perc = int.Parse(szoveg.Substring(2,2));
            return new TimeSpan(ora, perc, 00);
        }
    }
}
