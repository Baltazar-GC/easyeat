using System.ComponentModel.DataAnnotations;

namespace easyeat.DTOs.Categories
{
    public class NewCategory
    {
        [Required]
        public string Name { get; set; }
    }
}