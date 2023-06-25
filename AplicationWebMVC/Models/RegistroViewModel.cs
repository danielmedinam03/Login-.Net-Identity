using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace AplicationWebMVC.Models
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "El Email es obligatorio")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "La confirmarcion de contraseña es obligatoria")]
        [Compare("Password",ErrorMessage ="La contraseña y la confirmacion de contraseña no coinciden")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        public string Url { get; set; }
        public Int32 CodigoPais { get; set; }
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El país es obligatorio")]
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El fecha de nacimiento es obligatoria")]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "El estado es obligatorio")]
        public bool Estado { get; set; }

    }
}
