using Divers.Data;
using Divers.Models;
using Divers.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divers.Services.Implementation
{
    public class MealService : IMealService
    {

        private readonly ApplicationDbContext _context;
        public MealService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Meal> GetMeals()
        {
            return _context.meals.ToList();
        }
    }
}
