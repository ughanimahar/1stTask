using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Model;

namespace WebApi.Repositories
{
    public class UnitRepository : IUnit
    {
        private readonly UnitContext _context;

        public UnitRepository(UnitContext context)
        {
            _context = context;
        }
        public List<Unit> GetItems()
        {
            List<Unit> units = _context.Units.ToList();
            return units;
        }
    }
}
