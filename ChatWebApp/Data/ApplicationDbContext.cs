using ChatWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ChatWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Message> Messages { get; set; } 
    }
}