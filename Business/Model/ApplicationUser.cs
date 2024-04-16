using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace easyeat.Business.Model
{
    public class ApplicationUser
    {
        [Key]
        public int Id { get; set; }

        public Suscription Suscription { get; set; }
        
        public Restaurant Restaurant { get; set; } 
    }
}