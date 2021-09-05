

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Data
{
    public class UnitContext : DbContext
    {

        public UnitContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<Unit> Units { get; set; }


    }
}
