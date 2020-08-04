using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SBSC_LEARN.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, UserRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { set; get; }
        public DbSet<Exam> Exams { set; get; }
        public DbSet<Video> Videos { set; get; }
    }
}
