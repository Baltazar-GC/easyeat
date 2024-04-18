using System.ComponentModel.DataAnnotations;

namespace easyeat.Infrastructure.Auth.DTOs
{
    public class LoginData
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string Username { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Password { get; set; }

    }
}
