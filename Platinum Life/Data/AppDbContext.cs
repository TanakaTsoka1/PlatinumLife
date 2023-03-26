using System;
using Microsoft.EntityFrameworkCore;
using PlatinumLife.Models;

namespace Platinum_Life.Data
{
	public class AppDbContext: DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Invoice> Invoices { get; set; }
    } 
}

