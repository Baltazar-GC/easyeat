using System.ComponentModel.DataAnnotations;

namespace easyeat.Business.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}