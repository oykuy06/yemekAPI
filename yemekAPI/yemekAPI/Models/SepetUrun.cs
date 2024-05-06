using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace yemekAPI.Models
{
    public class SepetUrun
    {
        [Key, ForeignKey(nameof(Sepet))]
        public int SepetId { get; set; }

        //[Column(TypeName = "int)")]
        [ForeignKey(nameof(Ürünler))]
        public int UrunId { get; set; }
        public Ürünler? Ürünler { get; set; }

        public Sepet? Sepet { get; set; }
    }
}
