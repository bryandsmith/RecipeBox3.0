using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using RecipeBox3._0.ViewModels;

namespace RecipeBox3._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userData;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public HomeController(IUserRepository UserData, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userData = UserData;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        private string _currentUser => _userManager.GetUserId(User);
        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {

                return RedirectToAction("UserIndex", "User");
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
