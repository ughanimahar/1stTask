using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagment.Models;
using InventoryManagmentWEBApi.Models;

namespace InventoryManagment.Interfaces
{
    public interface IUnit
    {
        List<UnitWebApi> GetItems();

        UnitWebApi GetUnit(int id);

        UnitWebApi Create(UnitWebApi unit);

        UnitWebApi Edit(UnitWebApi unit);

        UnitWebApi Delete(UnitWebApi unit);
    }
}
