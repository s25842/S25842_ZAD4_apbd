using Microsoft.AspNetCore.Mvc;
using S25842_ZAD4.Data;
using S25842_ZAD4.Models;


namespace S25842_ZAD4.Controllers;

[ApiController]
[Route("api/rooms")]
public class RoomController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetRoomById(int id)
    {
        var room = TestData.Rooms.FirstOrDefault(x => x.Id == id);
        if (room == null)
        {
            return NotFound();
        }
            return Ok(room);
        
    }

    [HttpGet("building/{buildingCode}")]
    public IActionResult GetByBuildingCode(string buildingCode)
    {
        var rooms = TestData.Rooms.Where(x => x.BuildingCode == buildingCode);
        return Ok(rooms);
    }

    [HttpGet("")]
    public IActionResult GetRoomsFilteredByQueryString
        ([FromQuery] int? capacity,
            [FromQuery] bool? hasProjector,
            [FromQuery] bool? active)
    {
        var rooms = TestData.Rooms.AsEnumerable();
        if (active.HasValue)
        {
            rooms = rooms.Where(x => x.IsActive == active.Value);
        }

        if (hasProjector.HasValue)
        {
            rooms = rooms.Where(x => x.HasProjector == hasProjector.Value);
        }

        if (capacity.HasValue)
        {
            rooms = rooms.Where(x => x.Capacity >= capacity.Value);
        }
        return Ok(rooms);
    }

    [HttpPost]
    public IActionResult AddRoom(Room room)
    {
        if (TestData.Rooms.Any(x => x.Name == room.Name))
        {
            return Conflict("such room exists");
        }
        if(TestData.Rooms.Any())
        {
            room.Id = TestData.Rooms.Max(x => x.Id) + 1;
        }else
        {
            room.Id = 1;
        }
        TestData.Rooms.Add(room);

        return Created($"/api/rooms/{room.Id}", room);
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteRoom(int id)
    {
        var room = TestData.Rooms.FirstOrDefault(x => x.Id == id);
        if (room == null)
            return NotFound();
        if (TestData.Reservations.Any(r => r.RoomId == id))
        {
            return Conflict("room has reservation/s cant delete");
        }
        TestData.Rooms.Remove(room);
        return NoContent();
    }
    
    
    
}