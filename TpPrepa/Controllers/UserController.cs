using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TpPrepa.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TpPrepa.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateUser(UserModel model)
        {
            if (ModelState.IsValid)
            {
                model.AjouterUser();
                return RedirectToAction("Login");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel user = model.LoginUser();
                if(user == null)
                {
                    ViewBag.Error = "Username or password incorrect";
                    return View();
                }
                else
                {
                    if (user.Password.Equals(model.Password))
                    {
                        if(user.Valide == 1)
                        {
                            if(user.Tentative >= 3)
                            {
                                ViewBag.Error = "Compte bloqué ! , Veuillez contacter le support";
                                return View();
                            }

                            return RedirectToAction("Acceuil");
                        }
                    }
                    else
                    {
                        user.Tentative++;
                        model.incrementerFunction(user);
                        ViewBag.Error = "Username or password incorrect";
                        return View();
                    }
                }
            }
            return View(model);
        }
    }
}

