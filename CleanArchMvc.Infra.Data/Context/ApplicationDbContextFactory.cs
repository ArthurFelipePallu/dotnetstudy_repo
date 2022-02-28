using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CleanArchMvc.Infra.Data.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsbuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsbuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ArchMvc;Trusted_Connection=True;");
            return new ApplicationDbContext(optionsbuilder.Options);
            
        }
    }
}