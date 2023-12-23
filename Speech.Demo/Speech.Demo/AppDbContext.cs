using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speech.Demo
{
    internal class AppDbContext : DbContext
    {
        public DbSet<IntentResponse> IntentResponses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=localhost,1433;Database=Jarvis_DB;User ID=sa;Password=Senai@134;Trusted_Connection=False; TrustServerCertificate=True;");
    }
}