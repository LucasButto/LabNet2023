using PracticaEF.Data;
using PracticaEF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaEF.Logic
{
    public class CategoriesLogic
    {
        private readonly NorthwindContext _context;

        public CategoriesLogic()
        {
            _context = new NorthwindContext();
        }

        public List<Categories> GetAll()
        {
            return _context.Categories.ToList();
        }
    }
}
