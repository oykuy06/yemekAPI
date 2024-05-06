using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace yemekAPI.Models
{
    public class Sepet
    {
        [Key]
        public int SepetId { get; set; }

        //[Column(TypeName = "int")]
        [ForeignKey("Kullanıcı")]
        public int UserId { get; set; }

        //[Column(TypeName = "int")]
        [DisplayName("Ürün Adeti")]
        [Required]
        public int UrunAdet { get; set; }

        //[Column(TypeName = "int")]
        [DisplayName("Tutar")]
        [Required]
        public int Tutar { get; set; }

        public SepetUrun? SepetUrun { get; set; }

        public Kullanıcı? Kullanıcı { get; set; }
    }
}
