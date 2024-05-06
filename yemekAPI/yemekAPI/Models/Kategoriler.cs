using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace yemekAPI.Models
{
    public class Kategoriler
    {
        [Key]
        public int KategoriId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Kategori Türü")]
        [Required]

        public string KategoriTuru { get; set; }

        public Restaurant? Restaurant { get; set; }
    }
}
