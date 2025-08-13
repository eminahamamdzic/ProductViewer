using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductViewer.Models
{
    public class Proizvod
    {
        [Required]
        public int ProizvodID { get; set; }

        [Required]
        public string Naziv { get; set; }

        [Required]
        public string Dobavljac { get; set; }
        [Required]
        public int Kolicina { get; set; }
        
        public DateTime DatumProizvodnje { get; set; }
        [Required]
        public DateTime DatumIsteka { get; set; }

        [Required]

        [EnumDataType(typeof(Kategorija))]
        public Kategorija Kategorija { get; set; }

        public string? SlikaUrl { get; set; }
        [Required]
        public string KorisnikID { get; set; } 

        [ForeignKey("KorisnikID")]
        public Korisnik Korisnik { get; set; }

    }
}
