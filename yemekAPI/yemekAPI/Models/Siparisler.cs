using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace yemekAPI.Models
{
    public class Siparisler
    {
        [Key]
        public int SiparisId { get; set; }

        //[Column(TypeName = "int")]
        [ForeignKey("Kullanıcı")]
        public int UserId { get; set; }
        public Kullanıcı Kullanıcı { get; set; }
        public DateTime SiparisTarih { get; set; }

        //[Column(TypeName = "int")]
        [DisplayName("Sipariş Adeti")]
        [Required]
        public int SiparisAdet { get; set; }

        //[Column(TypeName = "int")]
        [DisplayName("Sipariş Tutarı")]
        [Required]
        public int SiparisTutar { get; set; }

        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }
    }
}
