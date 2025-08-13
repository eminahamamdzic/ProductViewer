using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductViewer.Models
{
    public class Korisnik : IdentityUser
    {
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage =
             "Ime smije imati između 3 i 20 karaktera")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Dozvoljeno je korištenje velikih i malih slova i razmaka")]
        [DisplayName("Ime korisnika")]
        public string? Ime { get; set; }

        [ForeignKey("Aktivnost")]
        public int aktivnost { get; set; }

        [ForeignKey("Izvjestaj")]
        public int izvjestaj { get; set; }

        public virtual ICollection<Proizvod> Proizvodi { get; set; }





    }
}
