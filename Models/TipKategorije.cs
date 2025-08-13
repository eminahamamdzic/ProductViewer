using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductViewer.Models
{
    public class TipKategorije
    {
        [Key]
        public int tipID { get; set; }

        [ForeignKey("Kategorija")]
        public Kategorija Tip { get; set; }
    }
}
