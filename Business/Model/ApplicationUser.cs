using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace easyeat.Business.Model
{
    public class ApplicationUser
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("SuscriptionId")]
        public Suscription Suscription { get; set; }
        
        [ForeignKey("RestaurantId")]
        public Restaurant Restaurant { get; set; } 
    }
}