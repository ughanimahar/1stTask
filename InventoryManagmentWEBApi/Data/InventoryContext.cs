using InventoryManagment.Models;
using InventoryManagmentWEBApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagmentWEBApi.Data
{
    public class InventoryContext:DbContext
    {

        public InventoryContext(DbContextOptions options):base(options)
        {

        }
        public virtual DbSet<UnitWebApi> Units { get; set; }


    }
}
