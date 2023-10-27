using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index()
        {
            HomeVM vm = new HomeVM
            {
                Sliders= await _appDbContext.Sliders.ToListAsync(),
                Teachers= await _appDbContext.Teachers.ToListAsync(),
                Abouts= await _appDbContext.Abouts.FirstOrDefaultAsync(),
            };
            
            return View(vm);
        }

    }
}