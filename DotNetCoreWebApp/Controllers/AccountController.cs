using DotNetCoreWebApp.Data;
using DotNetCoreWebApp.Data.Dto;
using DotNetCoreWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        const string SessionLoginUserId = "_LoginUserId";

        public AccountController(AppDbContext context)
        { 
            _context = context;
        }
        public IActionResult Index()
        {
            
            var LoginUserId2 = HttpContext.Session.GetInt32(SessionLoginUserId);
            if (LoginUserId2 != null)
            {
                ViewData["Message"] = "Asp.Net Core !!!.";
                return View();
            }
            return RedirectToAction("Login");            
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Signup(AccountDto account)
        {
            var user = await _context.Users.Where(us => us.Email == account.Email).FirstOrDefaultAsync();
            if (user == null)
            {
                var data = new User
                {
                    Name = account.Name,
                    Email = account.Email,
                    Password = account.Password
                };
                await _context.Users.AddAsync(data);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login");

            }
            TempData["AlertMessage"] = "User Already Exist With This Email!";
            return RedirectToAction("Signup");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto account)
        {
            var user = await _context.Users.Where(us => us.Email == account.Email && us.Password == account.Password).FirstOrDefaultAsync();
            if (user != null)
            {

                HttpContext.Session.SetInt32(SessionLoginUserId, user.Id);
                return RedirectToAction("Index");

            }
            TempData["AlertMessage"] = "Invalid Credentials";
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Logout()
        {          
            HttpContext.Session.Remove(SessionLoginUserId);
            return RedirectToAction("Login");
        }


    }
}
