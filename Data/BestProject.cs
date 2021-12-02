using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadastroBestProject.Models;

namespace CadstroBestProject.Data
{
    public class BestProject : DbContext
    {
        public BestProject (DbContextOptions<BestProject> options)
            : base(options)
        {
        }

        public DbSet<CadastroBestProject.Models.cadastro> cadastro { get; set; }
    }
}
