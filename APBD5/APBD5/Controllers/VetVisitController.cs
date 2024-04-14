using APBD5.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBD5.Controllers;

[Route("api/visits")]
[ApiController]
public class VisitController : ControllerBase
{
    private static readonly List<VetVisit> _visits = new()
    {
        new VetVisit { Date = new DateTime(2022, 6, 15), AnimalId = 1, Description = "vaccination", Price = 350 },
        new VetVisit { Date = new DateTime(2018, 1, 20), AnimalId = 1, Description = "tooth removal", Price = 220 },
        new VetVisit { Date = new DateTime(2021, 8, 13), AnimalId = 2, Description = "injured paw", Price = 100 },
        new VetVisit { Date = new DateTime(2015, 8, 6), AnimalId = 2, Description = "control visit", Price = 90 },
        new VetVisit { Date = new DateTime(2023, 9, 2), AnimalId = 3, Description = "injured paw", Price = 350 },
        new VetVisit { Date = new DateTime(2019, 5, 12), AnimalId = 3, Description = "tooth removal", Price = 220 },
        new VetVisit { Date = new DateTime(2013, 11, 17), AnimalId = 4, Description = "vaccination", Price = 450 },
        new VetVisit { Date = new DateTime(2018, 12, 22), AnimalId = 4, Description = "control visit", Price = 90 }
    };

    [HttpGet("{id:int}")]
    public IActionResult GetVisits(int id)
    {
        var visit = _visits.FindAll(s => s.AnimalId == id);
        if (visit == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        return Ok(visit);
    }

    [HttpPost]
    public IActionResult CreateVisit(VetVisit visit)
    {
        _visits.Add(visit);
        return StatusCode(StatusCodes.Status201Created);
    }
}