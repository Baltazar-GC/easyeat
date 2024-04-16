
using easyeat.DTOs.Categories;

namespace easyeat.DTOs.Dishes
{
    public class Dish
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }
    }
}