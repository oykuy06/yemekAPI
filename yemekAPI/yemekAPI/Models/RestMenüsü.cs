using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace yemekAPI.Models
{
    public class RestMenüsü
    {
        [Key, ForeignKey(nameof(Restaurant))]
        public int RestaurantId { get; set; }

        //[Column(TypeName = "int")]
        [ForeignKey(nameof(Menüler))]
        //[DisplayName("Menü Id")]
        public int MenuId { get; set; }
        public Menüler? Menüler { get; set; }
        public Restaurant? Restaurant { get; set; }
    }
}
