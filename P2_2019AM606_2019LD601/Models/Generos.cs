using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P2_2019AM606_2019LD601.Models
{
    public class Generos
    {
        [Key]
        public int ID { get; set; }
        public string NOMBRE { get; set; }
    }
}
