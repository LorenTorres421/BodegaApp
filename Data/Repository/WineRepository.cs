using Data.Entities;
using Data.Repository;

namespace Data.Repository
{
    public class WineRepository : IWineRepository
    {
        private readonly List<Wine> _wines = new List<Wine>();

        public List<Wine> GetWines()
        {
            return _wines;
        }

        public void AddWine(Wine wine)
        {
            wine.Id = _wines.Count + 1;
            _wines.Add(wine);
        }
    }

}

