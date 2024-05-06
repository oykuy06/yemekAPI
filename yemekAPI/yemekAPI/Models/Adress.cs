using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace yemekAPI.Models
{
    public class Adress
    {
        [Key]
        public int AdresId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Ev Adresi")]
        [Required]
        public string EvAdresi { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("İş Adresi")]
        [Required]
        public string IsAdresi { get; set; }

        public Kullanıcı? Kullanıcı { get; set; }
    }
}
