using System.ComponentModel.DataAnnotations;

namespace easyeat.Business.Model
{
    public class Dish
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }
    }
}