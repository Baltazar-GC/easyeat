using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace easyeat.Business.Model
{
    public class Suscription
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public MealPlan MealPlan { get; set; }
    }
}