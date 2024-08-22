using KioscoWebApp.Data;
using KioscoWebApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace KioscoWebApp.Controllers
{
    public class LoginController : Controller
    {
        private bool isLogged;
        private DataContext _context;

        public LoginController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password, Customer customer)
        {
            // Replace with your authentication logic
            if (IsValidUser(username, password, customer.FirstName, customer.Password, customer))
            {
                // Authentication successful, redirect to a specific page
                return RedirectToAction("Index", "Home"); // Redirect to Home/Index after login
                isLogged = true;
            }

            // If authentication fails, stay on the login page and show an error
            ViewBag.ErrorMessage = "Invalid username or password";
            return View();
            isLogged = false;
        }
        private bool IsValidUser(string username, string password, string firstName, string realPassword, Customer customer)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrWhiteSpace(username) && customer.FirstName == username && customer.Password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
