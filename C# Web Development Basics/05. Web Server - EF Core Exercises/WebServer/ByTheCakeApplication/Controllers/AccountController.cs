namespace WebServer.ByTheCakeApplication.Controllers
{
    using Infrastructure;
    using Server.Http;
    using Server.Http.Contracts;
    using Server.Http.Response;
    using Services;
    using Services.Contracts;
    using System;
    using ViewModels;
    using ViewModels.Account;

    public class AccountController : Controller
    {
        private const string RegisterView = @"account\register";
        private const string LoginView = @"account\login";
        private const string ProfileView = @"account\profile";

        private IUserService userService;

        public AccountController()
        {
            this.userService = new UserService();
        }

        public IHttpResponse Register()
        {
            this.SetDefaultView();

            return this.FileViewResponse(RegisterView);
        }

        public IHttpResponse Register(IHttpRequest req, RegisterViewModel model)
        {
            this.SetDefaultView();

            // Validate Model 
            if (string.IsNullOrWhiteSpace(model.Username) ||
                string.IsNullOrWhiteSpace(model.Password) ||
                string.IsNullOrWhiteSpace(model.ConfirmPassword) ||
                model.Username.Length < 3 || 
                model.Username.Length > 20 ||
                model.Password.Length < 3 || 
                model.Password.Length > 100 ||
                model.ConfirmPassword.Length < 3 || 
                model.ConfirmPassword.Length > 100 ||
                model.ConfirmPassword != model.Password)
            {
                this.AddError("Invalid user details");

                return this.FileViewResponse(RegisterView);
            }

            // Create User in database
            var success = this.userService.Create(model.Username, model.Password);

            if (!success)
            {
                this.AddError("Username is already taken");

                return this.FileViewResponse(RegisterView);
            }

            // Add logged in user to session
            this.LoginUser(req, model.Username);

            // Redirect to Home
            return new RedirectResponse("/");
        }

        public IHttpResponse Login()
        {
            this.SetDefaultView();

            return this.FileViewResponse(LoginView);
        }

        public IHttpResponse Login(IHttpRequest req, LoginViewModel model)
        {
            this.SetDefaultView();

            // Validate Model
            if (string.IsNullOrWhiteSpace(model.Username) ||
                string.IsNullOrWhiteSpace(model.Password))
            {
                this.AddError("You have empty fields");

                return this.FileViewResponse(LoginView);
            }

            // Validate User credentials
            var success = this.userService.Find(model.Username, model.Password);

            if (!success)
            {
                this.AddError("Invalid user credentials");

                return this.FileViewResponse(LoginView);
            }

            // Add logged in user to session
            this.LoginUser(req, model.Username);

            // Redirect to Home
            return new RedirectResponse("/");
        }

        public IHttpResponse Logout(IHttpRequest req)
        {
            req.Session.Clear();

            return new RedirectResponse("/login");
        }

        public IHttpResponse Profile(IHttpRequest req)
        {
            // Check if there is a logged in user
            if (!req.Session.Contains(SessionStore.CurrentUserKey))
            {
                throw new InvalidOperationException("There is no logged in user");
            }

            // Get current user & profile data
            var username = req.Session.Get<string>(SessionStore.CurrentUserKey);
            var profile = this.userService.Profile(username);

            if (profile == null)
            {
                throw new InvalidOperationException("The user could not be found in the database");
            }

            // Return Profle View
            this.ViewData["userName"] = profile.Username;
            this.ViewData["registrationDate"] = profile.RegistrationDate.ToShortDateString();
            this.ViewData["totalOrders"] = profile.TotalOrders.ToString();

            return this.FileViewResponse(ProfileView);
        }

        private void LoginUser(IHttpRequest req, string username)
        {
            req.Session.Add(SessionStore.CurrentUserKey, username);
            req.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());
        }

        private void SetDefaultView()
            => this.ViewData["authDisplay"] = "none"; // hide logout button
    }
}
