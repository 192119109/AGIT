using AGIT_TEST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AGIT_TEST.DAL
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Plan> Plan { get; set; }
        public DbSet<Output> Output { get; set; }
        public DbSet<DataHeader> DataHeader { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plan>().ToTable("Plan");
            modelBuilder.Entity<Output>().ToTable("Output");
            modelBuilder.Entity<DataHeader>().ToTable("DataHeader");
        }
    }
}