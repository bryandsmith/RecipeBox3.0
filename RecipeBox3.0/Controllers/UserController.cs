using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeBox3._0.ViewModels;
namespace RecipeBox3._0.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userData;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public UserController(IUserRepository UserData, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userData = UserData;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        private string _currentUser => _userManager.GetUserId(User);
        // GET: User
        public ActionResult UserIndex()
        {
            UserViewModel userViewModel = new UserViewModel
            {
                Recipes = _userData.GetUserRecipes(_currentUser)
            };
            return View(userViewModel);
        }

    }
}