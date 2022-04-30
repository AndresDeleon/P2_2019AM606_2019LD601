using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P2_2019AM606_2019LD601.Models;
using Microsoft.EntityFrameworkCore;

namespace P2_2019AM606_2019LD601
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {

        }

        public DbSet<CasosReportados> CasosReportados { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Generos> Generos { get; set; }
    }
}
