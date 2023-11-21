using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tooded
{
    public class toode
    {
        public int Id { get; set; }
        public string toodeNimetus { get; set; }

        public int Kogus { get; set; }

        public float Hind { get; set; }

        public string Pilt { get; set; }
        public IEnumerable<Kategooria> Kategooriad { get;set; }
    }
    public class Kategooria
    {
        public int Id { get; set; }
        public string KategooriaNimetus { get; set; }
        public string Kirjeldus { get; set; }
    }
}
