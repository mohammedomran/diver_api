using Divers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divers.Services.Interfaces
{
    public interface IMealService
    {
        IEnumerable<Meal> GetMeals();
    }
}
