using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class WineRepository : IWineRepository
    {
        private readonly BodegaContext _context;
        
        public WineRepository(BodegaContext context)
        {
            _context = context;  
        }

        public List<Wine> GetWines()
        {
            return _context.Wines.ToList();
        }

        public void AddWine(Wine wine)
        {
            if (wine == null)
            {
                throw new ArgumentException("El vino no puede ser nulo.");
            }
            _context.Wines.Add(wine);
            _context.SaveChanges();
        }

        public Wine GetWineById(int id)
        {
            return _context.Wines.FirstOrDefault(w => w.Id == id);
        }

        public void UpdateWine(Wine wine)
        {
            _context.Wines.Add(wine);
        }

        public List<Wine> GetStockByVariety(string variety)
        {
            return _context.Wines.Where(w => w.Variety == variety)
                    .ToList();
        }

        public void UpdateWineById(int id, int amount)
        {
            var wine = _context.Wines.FirstOrDefault(w => w.Id == id);

            if (wine != null)
            {
                wine.Stock += amount;
                _context.SaveChanges();
            }
        }

    }

}


