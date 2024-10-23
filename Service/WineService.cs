using Common.Dtos;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class WineService
    {
        private readonly IWineRepository _repository;

        public WineService(IWineRepository repository)
        {
            _repository = repository;
        }

        public List<Wine> GetAllWines()
        {
            return _repository.GetWines();
        }

        public void RegisterWine(WineDto wineDto)
        {
            if (wineDto == null)
            {
                throw new ArgumentException("Los detalles del vino no pueden ser nulos.");
            }

            var wine = new Wine
            {
                Name = wineDto.Name,
                Variety = wineDto.Variety,
                Year = wineDto.Year
            };

            _repository.AddWine(wine);
        }

        public Wine GetWineById(int id)
        {
            return _repository.GetWineById(id);
        }

        public List<Wine> GetStockByVariety(string variety)
        {
            return _repository.GetStockByVariety(variety);
        }

        public void UpdateWineStockById(int id, int amount)
        {
            _repository.UpdateWineById(id, amount);
        }

    }
}
