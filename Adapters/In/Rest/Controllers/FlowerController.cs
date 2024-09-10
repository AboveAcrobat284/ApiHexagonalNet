using Microsoft.AspNetCore.Mvc;
using ApiHexagonalNet.Application.Ports;
using ApiHexagonalNet.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiHexagonalNet.Adapters.In.Rest.Controllers
{
[ApiController]
[Route("api/[controller]")]
public class FlowerController : ControllerBase
{
    private readonly IFlowerService _flowerService;

    public FlowerController(IFlowerService flowerService)
    {
        _flowerService = flowerService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFlowerById(string id)
    {
        var flower = await _flowerService.GetFlowerById(id);

        if (flower == null)
        {
            return NotFound();
        }

        return Ok(flower);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFlowers()
    {
        var flowers = await _flowerService.GetAllFlowers();
        return Ok(flowers);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFlower([FromBody] Flower flower)
    {
        await _flowerService.CreateFlower(flower);
        return CreatedAtAction(nameof(GetFlowerById), new { id = flower.Id }, flower);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFlower(string id, [FromBody] Flower flower)
    {
        if (id != flower.Id)
        {
            return BadRequest("El ID de la URL no coincide con el ID del objeto.");
        }

        await _flowerService.UpdateFlower(id, flower); // No asignar a una variable

        return NoContent(); // O cualquier respuesta apropiada, como Ok()
    }




    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFlower(string id)
    {
        var existingFlower = await _flowerService.GetFlowerById(id);
        if (existingFlower == null)
        {
            return NotFound();
        }

        await _flowerService.DeleteFlower(id);

        return NoContent();
    }
}
}