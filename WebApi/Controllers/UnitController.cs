using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly UnitContext _context;

        public UnitController(UnitContext context)
        {
            _context = context;
        }
     
        public IActionResult Get(bool includeAddress = false)
        {
          
          
            List<Unit> units = _context.Units.ToList();
            return Ok(units);
        }
        //[HttpPost]
        //[Route("{id}")]
        //public IActionResult GetById(int id)
        //{


        //    Unit unit = _context.Units.Where(u => u.Id == id).FirstOrDefault();
        //    return Ok(unit);
        //}
        [Route("{id}")]
        [HttpGet]
        public IActionResult DetailById(int id)
        {

            Unit unit = _context.Units.Where(u => u.Id == id).FirstOrDefault();
            return Ok(unit);
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Unit _unit)
        {

            _context.Units.Add(_unit);
            _context.SaveChanges();
            return Ok(_unit);
        }
        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(Unit _unit)
        {

            _context.Units.Attach(_unit);
            _context.Entry(_unit).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(_unit);
        }
      
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int Id)
        {
            Unit _unit = _context.Units.Where(u => u.Id == Id).FirstOrDefault();
            _context.Units.Attach(_unit);
            _context.Entry(_unit).State = EntityState.Deleted;
            _context.SaveChanges();
            return Ok();
        }
    }
}