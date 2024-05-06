using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace yemekAPI.Models
{
    public class Menüler
    {
        [Key]
        public int? MenuId { get; set; }

        //[Column(TypeName = "int")]
        [ForeignKey(nameof(Ürünler))]
        [DisplayName("Ürün Id")]
        public int UrunId { get; set; }
        public Ürünler? Ürünler { get; set; }

        public RestMenüsü? RestMenüsü { get; set; }
    }
}
