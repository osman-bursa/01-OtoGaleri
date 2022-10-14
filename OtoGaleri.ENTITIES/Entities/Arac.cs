using Microsoft.EntityFrameworkCore;
using OtoGaleri.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleri.ENTITIES.Entities
{
    [Index("SasiNo",IsUnique = true, Name = "SasiIX")]
    public class Arac : BaseEntity
    {
        public int SasiNo { get; set; }
        public string Markasi { get; set; }
        public string Modeli { get; set; }
        public double MotorHacmi { get; set; }
        public string Fiyati { get; set; }
        public VitesTipi VitesTipi { get; set; }
        public YakitTuru YakitTuru { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime UretimTarihi { get; set; }
        public AracTipi AracTipi { get; set; }
        public Sehir Sehir { get; set; }

        //// nav prop.

        [ForeignKey("AracinSahibi")]
        public int KullaniciID { get; set; }
        public Kullanici AracinSahibi { get; set; }

        [ForeignKey("AracinMagazasi")]
        public int MagazaID { get; set; }
        public Magaza AracinMagazasi { get; set; }
    }
}
