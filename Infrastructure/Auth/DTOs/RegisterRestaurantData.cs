using easyeat.DTOs.Addresses;
using System.ComponentModel.DataAnnotations;

namespace easyeat.Infrastructure.Auth.DTOs
{
    public class RegisterRestaurantData
    {
        [Required(ErrorMessage = "El email es requerido"), EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida"), DataType(DataType.Password)]
        [StringLength(255, ErrorMessage = "Debe tener al menos 5 caracteres", MinimumLength = 5)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Debe confirmar su contraseña")]
        [StringLength(255, ErrorMessage = "Debe tener al menos 5 caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public NewAddress Address { get; set; }

        public string CuisineType { get; set; }

        public string OperatingHours { get; set; }

        public string PhoneNumber { get; set; }
    }
}
