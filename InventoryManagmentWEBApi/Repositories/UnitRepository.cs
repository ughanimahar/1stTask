using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using InventoryManagment.Interfaces;
using InventoryManagment.Models;
using InventoryManagmentWEBApi.Data;
using InventoryManagmentWEBApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentWEBApi.Repositories
{
    public class UnitRepository : IUnit
    {
        private readonly InventoryContext _context;

        public UnitRepository(InventoryContext context)
        {
            _context = context;
        }

        public UnitWebApi Create(UnitWebApi _unit)
        {

            _context.Units.Add(_unit);
            _context.SaveChanges();
            return _unit;
        }

        public UnitWebApi Delete(UnitWebApi _unit)
        {
            _context.Units.Attach(_unit);
            _context.Entry(_unit).State = EntityState.Deleted;
            _context.SaveChanges();
            return _unit;
        }

        public UnitWebApi Edit(UnitWebApi _unit)
        {
            _context.Units.Attach(_unit);
            _context.Entry(_unit).State = EntityState.Modified;
            _context.SaveChanges();
            return _unit;
        }
        public List<UnitWebApi> GetItems()
        {
            List<UnitWebApi> units = _context.Units.ToList();
            return units;
        }

        public UnitWebApi GetUnit(int id)
        {
            UnitWebApi _unit = _context.Units.Where(u => u.Id == id).FirstOrDefault();
            return _unit;
        }
       
    }
}
