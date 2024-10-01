using Data.Entities;
using Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BodegaApp.Controllers
{
    [ApiController]
[Route("api/[controller]")]
public class WineController : ControllerBase
{
    private readonly WineService _wineService;

    public WineController(WineService wineService)
    {
        _wineService = wineService;
    }

    [HttpPost]
    public IActionResult RegisterWine([FromBody] Wine wine)
    {
        if (wine == null) return BadRequest("Los detalles del vino no pueden ser nulos.");

        _wineService.RegisterWine(wine);
        return CreatedAtAction(nameof(GetWineById), new { id = wine.Id }, wine);
    }

    [HttpGet]
    public ActionResult<List<Wine>> GetAllWines()
    {
        var wines = _wineService.GetAllWines();
        return Ok(wines);
    }

    [HttpGet("{id}")]
    public ActionResult<Wine> GetWineById(int id)
    {
        var wine = _wineService.GetAllWines().FirstOrDefault(w => w.Id == id);
        if (wine == null) return NotFound("El vino no existe.");
        return Ok(wine);
    }
}


}
