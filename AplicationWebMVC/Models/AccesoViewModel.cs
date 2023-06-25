using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AplicationWebMVC.Models
{
    public class AccesoViewModel
    {
        [Required(ErrorMessage = "El Email es obligatorio")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        [Display(Name = "Recordar datos?")]
        public bool RememberMe { get; set; }
    }
}
