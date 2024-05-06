using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace yemekAPI.Models
{
    public class Ürünler
    {
        [Key]
        public int UrunId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Ad")]
        [Required]
        public string Ad { get; set; }

        // [Column(TypeName = "int")]
        [DisplayName("Fiyat")]
        [Required]
        public int Fiyat { get; set; }

        public Menüler? Menüler { get; set; }

        public SepetUrun? SepetUrun { get; set; }
    }
}