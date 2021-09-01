using BackendCase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendCase.DataAccess
{
	public class BackendCaseDbContext:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("Data Source=DESKTOP-NV1L423;Database=BackendCase;Integrated Security=True;Connect Timeout=30;");
		}

		public DbSet< Package> Packages { get; set; }
		public DbSet<Shipment> Shipmenties { get; set; }
	}
}
