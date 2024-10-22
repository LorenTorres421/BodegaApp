using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IWineRepository
    {
        public List<Wine> GetWines();
        public void AddWine(int id, int amount);

        public Wine GetWineById(int id);

        public void UpdateWine(Wine wine);

        public List<Wine> GetStockByVariety(string variety);

        public void UpdateStockWineById(int id, int amount);

    }

}
