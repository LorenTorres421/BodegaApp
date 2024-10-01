using Data.Entities;
using Data.Repository;

public class WineService 
{
    private readonly WineRepository _repository;

    public WineService(WineRepository repository)
    {
        _repository = repository;
    }

    public List<Wine> GetAllWines()
    {
        return _repository.GetWines();
    }

    public void RegisterWine(Wine wine)
    {
        _repository.AddWine(wine);
    }

    public void AddStock(int wineId, int amount)
    {
        if (amount <= 0) throw new ArgumentException("La cantidad a añadir debe ser mayor a 0.");

        var wine = _repository.GetWines().FirstOrDefault(w => w.Id == wineId);
        if (wine == null) throw new KeyNotFoundException("El vino no existe.");

        wine.Stock += amount;
    }

    public void RemoveStock(int wineId, int amount)
    {
        if (amount <= 0) throw new ArgumentException("La cantidad a reducir debe ser mayor a 0.");

        var wine = _repository.GetWines().FirstOrDefault(w => w.Id == wineId);
        if (wine == null) throw new KeyNotFoundException("El vino no existe.");

        if (wine.Stock - amount < 0) throw new InvalidOperationException("No hay suficiente stock disponible.");
        wine.Stock -= amount;
    }
}
