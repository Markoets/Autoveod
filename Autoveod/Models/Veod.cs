using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoveod.Models
{
    public class Veod
    {
        public int Id { get; set; }
        public string Algus { get; set; }
        public string Ots { get; set; }
        public DateTime Aeg { get; set; }
        public string Autonr { get; set; }
        public string JuhtEesnimi  { get; set; }
        public string JuhtPerenimi { get; set; }
        public int Valmis { get; set; }

    }
}
