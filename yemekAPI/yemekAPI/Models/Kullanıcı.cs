using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace yemekAPI.Models
{
    public class Kullanıcı
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Ad")]
        [Required]
        public string Ad { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Soyad")]
        [Required]
        public string Soyad { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Email")]
        [Required]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Telefon")]
        [Required]
        public string Tel { get; set; }

        [ForeignKey(nameof(Adress))]
        public int AdresId { get; set; }

        public Adress? Adress { get; set; }
    }
}
