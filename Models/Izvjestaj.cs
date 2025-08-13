using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductViewer.Models
{
    public class Izvjestaj
    {
        public int Id { get; set; }

        [ForeignKey("Proizvod")]
        public int ProizvodID { get; set; }

        public Proizvod Proizvod { get; set; }

        [Display(Name = "Datum generisanja")]
        public DateTime DatumIzvjestaja { get; set; } = DateTime.Now;

        [Display(Name = "Količina manja od 5")]
        public bool NiskaKolicina { get; set; }

        [Display(Name = "Istek za 15 dana")]
        public bool RokIsteka15Dana { get; set; }

        [Display(Name = "Istek za 30 dana")]
        public bool RokIsteka30Dana { get; set; }

        [Display(Name = "Napomena")]
        public string? Napomena { get; set; }
    }
}
