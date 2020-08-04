using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBSC_LEARN.Data;
using SBSC_LEARN.Models;

namespace SBSC_LEARN.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? pageNumber)
        {
            
            var exam = from s in _context.Exams
                           select s;

            exam = exam.OrderByDescending(s => s.Score);

            int pageSize = 3;
            return View(await PaginatedList<Exam>.CreateAsync(exam.AsNoTracking(), pageNumber ?? 1, pageSize));

        }
    }
}
