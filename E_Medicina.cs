using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMedicina
{
    public class E_Medicina
    {
        [Key]
        public int ID_MEDICINA { get; set; }
        public string MEDICINA { get; set; }
        public string EXISTENCIA { get; set; }
        public DateTime? FECHA_INGRESO { get; set; }
        public DateTime? FECHA_VENCIMIENTO { get; set; }
        public string IMAGEN { get; set; }
    }
}
