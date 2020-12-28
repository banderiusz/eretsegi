using System;
using System.Collections.Generic;
using System.Text;

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
}
