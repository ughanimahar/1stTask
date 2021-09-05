using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Interfaces
{
   public interface IUnit
    {
        List<Unit> GetItems();
    }
}
