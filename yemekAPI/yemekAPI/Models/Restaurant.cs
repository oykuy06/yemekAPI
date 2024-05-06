using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace yemekAPI.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }

        //[Column(TypeName = "int")]
        [ForeignKey(nameof(Kategoriler))]
        public int KategoriId { get; set; }
        public Kategoriler Kategoriler { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Ad")]
        [Required]
        public string Ad { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Adres")]
        [Required]
        public string Adres { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Telefon")]
        [Required]
        public string Tel { get; set; }

        public RestMenüsü? RestMenüsü { get; set; }
        public Siparisler? Siparisler { get; set; }
    }
}
