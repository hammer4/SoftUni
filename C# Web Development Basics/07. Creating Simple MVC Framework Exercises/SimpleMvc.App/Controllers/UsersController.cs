using Microsoft.EntityFrameworkCore;
using SimpleMvc.App.BindingModels;
using SimpleMvc.App.ViewModels;
using SimpleMvc.Data;
using SimpleMvc.Domain;
using SimpleMvc.Framework.Attributes.Methods;
using SimpleMvc.Framework.Controllers;
using SimpleMvc.Framework.Interfaces;
using SimpleMvc.Framework.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleMvc.App.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel registerUserBinding)
        {
            var user = new User()
            {
                Username = registerUserBinding.Username,
                Password = registerUserBinding.Password
            };

            using(var context = new SimpleMvcDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

            return View();
        }

        [HttpGet]
        public IActionResult<UsersViewModel> All()
        {
            Dictionary<int, string> usersById = new Dictionary<int, string>();

            using (var context = new SimpleMvcDbContext())
            {
                usersById = context.Users.ToDictionary(u => u.Id, u => u.Username);
            }

            var viewModel = new UsersViewModel()
            {
                Users = usersById
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult<UserProfileViewModel> Profile(int id)
        {
            User user = null;

            using(var context = new SimpleMvcDbContext())
            {
                user = context.Users
                    .Include(u => u.Notes)
                    .SingleOrDefault(u => u.Id == id);
            }

            UserProfileViewModel model = new UserProfileViewModel()
            {
                UserId = user.Id,
                Username = user.Username,
                Notes = user.Notes
                    .Select(n => new NoteViewModel
                    {
                        Title = n.Title,
                        Content = n.Content
                    })
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult<UserProfileViewModel> Profile(AddNoteBindingModel model)
        {
            using(var context = new SimpleMvcDbContext())
            {
                var user = context.Users.Find(model.UserId);
                var note = new Note()
                {
                    Title = model.Title,
                    Content = model.Content
                };

                user.Notes.Add(note);
                context.SaveChanges();
            }

            return Profile(model.UserId);
        }
    }
}
