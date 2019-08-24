using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yardy.Models;

namespace Yardy.Services
{
    public class YardSaleService
    {
        private readonly YardyDbContext _context;

        public YardSaleService(YardyDbContext yardyDbContext)
        {
            _context = yardyDbContext;
        }

        public void CreateYardSale(YardSale yardSale)
        {

        }
    }
}
