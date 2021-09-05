using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using InventoryManagmentWEBApi.Models;
using InventoryManagmentWEBApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentWEBApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        private readonly UnitRepository _context;
        public ValuesController(UnitRepository context)
        {
            _context = context;
        }
        [HttpGet]
        public List<UnitWebApi> Get()
        {

            return _context.GetItems();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<UnitWebApi> GetBydId(int id)
        {
            return _context.GetUnit(id);
        }

        // POST api/values
        [HttpPost]
        public UnitWebApi Create([FromBody] UnitWebApi unit)
        {
            return _context.Create(unit);
        }

        // PUT api/values/5
        [HttpPut]
        public UnitWebApi Edit([FromBody] UnitWebApi unit)
        {
            return _context.Edit(unit);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
