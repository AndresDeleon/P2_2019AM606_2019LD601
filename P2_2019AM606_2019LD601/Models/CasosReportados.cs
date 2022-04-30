using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace P2_2019AM606_2019LD601.Models
{
    public class CasosReportados
    {
        [Key]
        public int ID_CASOS_REPORTADOS { get; set; }

        public int CONFIRMADOS { get; set; }
        public int RECUPERADOS { get; set; }
        public int FALLECIDOS { get; set; }

        [NotMapped]
        public string NOMBRE { get; set; }
        public int ID_GENEROS { get; set; }

        [NotMapped]
        public string NOMBRE_DEP { get; set; }
        public int ID_DEPARTAMENTOS { get; set; }
    }
}
