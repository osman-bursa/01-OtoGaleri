using OtoGaleri.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleri.ENTITIES.Entities
{
    public class Magaza : BaseEntity
    {
        public string MagazaAdi { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime KurulusTarihi { get; set; }
        public string Adresi { get; set; }
        public Sehir Sehir { get; set; }
        public string Telefonu { get; set; }
        public string LogoURL { get; set; }
        public string Email { get; set; }
        public string WebSitesi { get; set; }

        //// nav prop.
        //[ForeignKey("MagazaYetkilisi")]
        //public int MagazaYetkiliID { get; set; }
        //public Kullanici MagazaYetkilisi { get; set; }

        public List<Arac> MagazaninAraclari { get; set; }

        public List<Kullanici> MagazaninPersonelleri { get; set; }

    }
}
