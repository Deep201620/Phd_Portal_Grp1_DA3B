using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Phd_Portal_Grp1_DA3B.Models;

namespace Phd_Portal_Grp1_DA3B.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserInfo> Userinfo { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SubmissionDetails> Submissions { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }
    }
}
