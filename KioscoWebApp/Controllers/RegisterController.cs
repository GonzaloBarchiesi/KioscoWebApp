using KioscoWebApp.Data;
using KioscoWebApp.Models;
using Microsoft.AspNetCore.Mvc;


namespace KioscoWebApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly DataContext _context;
        private bool isRegistered;
        public RegisterController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(string firstName, string LastName, string Email, string password, Customer customer)
        {
            // Replace with your authentication logic
            if (IsValidUser(firstName, LastName, Email, password))
            {
                // Authentication successful, redirect to a specific page
                return RedirectToAction("Login", "LoginController"); // Redirect to Home/Index after login
                isRegistered = true;

            }

            // If authentication fails, stay on the login page and show an error
            ViewBag.ErrorMessage = "Error: The fields must be completed*";
            return View();
            isRegistered = false;
        }

        private bool IsValidUser(string firstName, string LastName, string Email, string Password)
        {
            if (!string.IsNullOrEmpty(firstName)
                && !string.IsNullOrWhiteSpace(firstName)
                && !string.IsNullOrEmpty(LastName)
                && !string.IsNullOrWhiteSpace(LastName)
                && !string.IsNullOrEmpty(Email)
                && !string.IsNullOrWhiteSpace(Email)
                && !string.IsNullOrEmpty(Password)
                && !string.IsNullOrWhiteSpace(Password))
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        [HttpPost]
        public async Task<IActionResult> Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
    }
}
