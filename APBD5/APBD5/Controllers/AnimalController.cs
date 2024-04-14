using Microsoft.AspNetCore.Mvc;

namespace APBD5.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalController : ControllerBase
{
    private static readonly List<Animal> _animals = new()
    {
        new Animal { Id = 1, Name = "Sledz", Category = "Dog", Weight = 13.5, FurColor = "Black" },
        new Animal { Id = 2, Name = "Bula", Category = "Cat", Weight = 3.7, FurColor = "Gray"},
        new Animal { Id = 3, Name = "Rudolf", Category = "Dog", Weight = 11.2, FurColor = "White"},
        new Animal { Id = 4, Name = "Mia", Category = "Cat", Weight = 4.2, FurColor = "Black"},

    };

    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAnimals(int id)
    {
        var animal = _animals.FirstOrDefault(s => s.Id == id);
        if (animal == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        return Ok(animal);
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        _animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var animalToEdit = _animals.FirstOrDefault(s => s.Id == id);

        if (animalToEdit == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        _animals.Remove(animalToEdit);
        _animals.Add(animal);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animalToDelete = _animals.FirstOrDefault(s => s.Id == id);
        if (animalToDelete == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        _animals.Remove(animalToDelete);
        return NoContent();
    }
}