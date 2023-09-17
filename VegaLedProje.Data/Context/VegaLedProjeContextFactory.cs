using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegaLedProje.Data.Context
{
    public class VegaLedProjeContextFactory : IDesignTimeDbContextFactory<VegaLedProjeContext>
    {
        public VegaLedProjeContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VegaLedProjeContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-KAODKRB;Database=VegaLedProje;User Id=sa;Password=123;TrustServerCertificate=True;");

            return new VegaLedProjeContext(optionsBuilder.Options); 

        }
    }
}
