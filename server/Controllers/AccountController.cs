using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Extensions.Hosting;
using FlexibleJobs.Models;


namespace FlexibleJobs.Controllers
{
    public class AccountController : Controller
    {
        /*
         * readonly IDiagnosticContext _diagnosticContext;
        AccountController(IDiagnosticContext diagnosticContext)
        {
            _diagnosticContext = diagnosticContext ?? throw new ArgumentNullException(nameof(diagnosticContext));
        }
        */

        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }

        
        public IActionResult Login()
        {
            
            //return RedirectToAction("Index", "Dashboard");
            return View();
        }

        [HttpPost]
        public IActionResult LoginUser()
        {
            return RedirectToAction("Index", "Dashboard");
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult  RegisterUser(User userModel)
        {
            Console.WriteLine("[ROUTE][Account/RegisterUser/]");
            if (userModel.Email == null)
            {
       
                return RedirectToAction("Register");
            }
            Console.WriteLine("[USER-MODEL] " + userModel.Email + " " + userModel.Password);
            // create user
            userModel.CreatedAt = DateTime.Now;
            userModel.Status = "active";
            userModel.LastUpdatedAt = userModel.CreatedAt;
            userModel.Email = userModel.Email.ToLower();
            //Password
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            userModel.Password = passwordHasher.HashPassword(userModel, userModel.Password);
            //set role
            string userRole = "";
            if (userModel.Role == UserRoles.employee.ToString()) {
                userRole = UserRoles.employee.ToString();
            }
            else if (userModel.Role == UserRoles.employer.ToString())
            {
                userRole = UserRoles.employee.ToString();
            }
            else
            {
                // redirect to register if role isn't found
                return RedirectToAction("Account", "Register"); //TODO: add errors to inform user of bad role selection
            }
            userModel.Role = userRole;




            return RedirectToAction("Index", "Dashboard");
        }

    }
}
