using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SBSC_LEARN.Data;
using SBSC_LEARN.Models;

namespace SBSC_LEARN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<User> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }


        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Videos.ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _context.Videos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }
        public async Task<IActionResult> Exam(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);

            Random random = new Random();
            int score = random.Next(0, 100);
            var newId = Guid.NewGuid();


            var video = await _context.Videos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (video == null)
            {
                return NotFound();
            }
            Exam exam = new Exam();
            exam.ID = newId;
            exam.User = user;
            exam.Video = video;
            exam.Score = score;

            _context.Add(exam);
            await _context.SaveChangesAsync();

            return View(exam);

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
