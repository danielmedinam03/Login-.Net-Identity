using AplicationWebMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Storage;

namespace AplicationWebMVC.Controllers
{
    public class CuentasController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public CuentasController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Registro()
        {
            RegistroViewModel registroVM = new RegistroViewModel();
            return View(registroVM);
        }

        [HttpPost]
        public async Task<IActionResult> Registro(RegistroViewModel registroVM)
        {
            if (ModelState.IsValid)
            {
                var usuario = new AppUsuario()
                {
                    UserName = registroVM.Email,
                    Email = registroVM.Email,
                    Nombre = registroVM.Nombre,
                    Url = registroVM.Url,
                    CodigoPais = registroVM.CodigoPais,
                    Telefono = registroVM.Telefono,
                    Pais = registroVM.Pais,
                    Ciudad = registroVM.Ciudad,
                    Direccion = registroVM.Direccion,
                    FechaNacimiento = registroVM.FechaNacimiento,
                    Estado = registroVM.Estado

                };

                var resultado = await _userManager.CreateAsync(usuario,registroVM.Password);
                                
                if (resultado.Succeeded)
                {
                    await _signInManager.SignInAsync(usuario, false);

                    return RedirectToAction("Index", "Home");
                }
                ValidarErrores(resultado);
            }
            return View(registroVM);
        }

        [HttpGet]
        public async Task<IActionResult> Acceso()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Acceso(AccesoViewModel accesoVM)
        {
            if (ModelState.IsValid)
            {
                var resultado = await _signInManager.PasswordSignInAsync(accesoVM.Email,accesoVM.Password,accesoVM.RememberMe,false);
                if (resultado.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Acceso inválido");
                    return View(accesoVM);
                }

            }
            return View(accesoVM);
        }



        private void ValidarErrores(IdentityResult resultado)
        {
            foreach (var error in resultado.Errors)
            {
                ModelState.AddModelError(String.Empty, error.Description);
            }
        }
    }
}
