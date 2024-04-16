using System.ComponentModel.DataAnnotations;
using easyeat.DTOs.Categories;

namespace easyeat.DTOs.Dishes
{
    public class NewDish
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }
    }
}