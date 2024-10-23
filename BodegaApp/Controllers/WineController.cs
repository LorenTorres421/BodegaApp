using Data.Entities;
using Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.Dtos;

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
        public IActionResult RegisterWine([FromBody] WineDto wineDto)
        {
            try
            {
                _wineService.RegisterWine(wineDto);
                return CreatedAtAction(nameof(GetWineById), new { id = wineDto.Id }, wineDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllWines(WineDto wineDto)
        {
            var wines = _wineService.GetAllWines();

            var wineDtos = wines.Select(w => new WineDto
            {
                Name = w.Name,
                Variety = w.Variety,
                Year = w.Year
            }).ToList();

            return Ok(wineDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetWineById(int id)
        {
            var wine = _wineService.GetAllWines().FirstOrDefault(w => w.Id == id);
            if (wine == null) return NotFound("El vino no existe.");

            // Convertir a WineDto antes de devolver la respuesta
            var wineDto = new WineDto
            {
                Name = wine.Name,
                Variety = wine.Variety,
                Year = wine.Year
            };

            return Ok(wineDto);
        }

        [HttpPut("{id}/stock")]
        public IActionResult UpdateStockWineById([FromBody] int id, int newStock)
        {
            var wine = _wineService.GetWineById(id);
            if (wine == null) return NotFound();

            wine.Stock = newStock;

            return NoContent();
        }
    }
}
