using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductViewer.Models
{
    public class Aktivnost
    {
        public int Id { get; set; }


        [ForeignKey("Proizvod")]
        public int ProizvodID { get; set; }

        public Proizvod Proizvod { get; set; }

        [Required]
        [Display(Name = "Vrijeme aktivnosti")]
        public DateTime Vrijeme { get; set; }

        [Display(Name = "Opis aktivnosti")]
        public string? Opis { get; set; }
    }
}
