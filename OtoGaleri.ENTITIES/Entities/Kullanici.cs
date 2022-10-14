using OtoGaleri.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleri.ENTITIES.Entities
{
    public class Kullanici : BaseEntity
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Meslegi { get; set; }
        public string Uyrugu { get; set; }
        public bool Cinsiyet { get; set; }
        public string ProfilFotoURL { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string Parola { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DogumTarihi { get; set; }
        public Rol Rolu { get; set; }

        // nav. prop
        public List<Arac> Araclari { get; set; }

        [ForeignKey("PersonelinMagazasi")]
        public int MagazaID { get; set; }
        public Magaza PersonelinMagazasi { get; set; }
    }
}
