using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleri.ENTITIES.Entities
{
    public class BaseEntity
    {
        [Column(Order = 1)]
        public int ID { get; set; }
        public bool AktifMi { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public DateTime DegistirilmeTarihi { get; set; }
    }
}
