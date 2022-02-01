using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Autoveod.Models
{
    public class Veod
    {
        public int Id { get; set; }
        public string Nimi { get; set; }
        public string Algus { get; set; }
        public string Ots { get; set; }
        public DateTime Aeg { get; set; }
        [DisplayFormat(NullDisplayText = "Puudub")]
        public string Autonr { get; set; }
        [DisplayFormat(NullDisplayText = "Puudub")]
        public string JuhtEesnimi { get; set; }
        [DisplayFormat(NullDisplayText = "Puudub")]
        public string JuhtPerenimi { get; set; }
        [DisplayFormat(NullDisplayText = "Tegemata")]
        public string Valmis { get; set; }
    }

    public enum Valmis
    {
        Tegemata,
        Valmis
    }
}
