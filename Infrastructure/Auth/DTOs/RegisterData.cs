using System.ComponentModel.DataAnnotations;

namespace easyeat.Infrastructure.Auth.DTOs
{
    public class RegisterData
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido"), StringLength(100)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El nombre es requerido"), StringLength(100)]
        public string FirstName { get; set; }

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
    }
}
