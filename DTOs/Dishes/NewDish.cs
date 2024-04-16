using System.ComponentModel.DataAnnotations;
using easyeat.Business.Model;

namespace easyeat.DTOs.Dishes
{
    public class NewDish
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }
    }
}