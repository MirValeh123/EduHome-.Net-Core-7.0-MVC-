using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EduHome.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public HomeController(AppDbContext db)
        {
            _appDbContext = db;
        }

        public IActionResult Index()
        {
            HomeVM vm = new HomeVM
            {
                Sliders=_appDbContext.Sliders.ToList(),
                Teachers=_appDbContext.Teachers.ToList(),
            };
            
            return View(vm);
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