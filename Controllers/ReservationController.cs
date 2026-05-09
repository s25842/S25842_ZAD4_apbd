using Microsoft.AspNetCore.Mvc;
using S25842_ZAD4.Data;
using S25842_ZAD4.Models;

namespace S25842_ZAD4.Controllers;
[ApiController]
[Route("api/reservations")]
public class ReservationController : ControllerBase
{
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        
        var reservation = TestData.Reservations.FirstOrDefault(x=>x.Id == id);
        if (reservation == null)
        {
            return NotFound();
        }
            
        return Ok(reservation);
    }

    [HttpGet]
    public IActionResult GetFiltered(
        [FromQuery] DateTime? date,
        [FromQuery] string? status,
        [FromQuery] int? roomId)
    {
        var reservations = TestData.Reservations.AsEnumerable();

        if (date.HasValue)
        {
            reservations = reservations.Where(x => x.StartTime == date);
        }

        if (!string.IsNullOrEmpty(status))
        {
            reservations = reservations.Where(x => x.Status.Equals(status));
        }

        if (roomId.HasValue)
        {
            reservations = reservations.Where(r => r.RoomId == roomId.Value);
        }
        return Ok(reservations);
    }

    [HttpPost]
    public IActionResult CreateReservation(Reservation reservation)
    {
        var room = TestData.Rooms.FirstOrDefault(x => x.Id == reservation.RoomId);

        if (room == null || !room.IsActive)
        {
            return BadRequest("inactive or non existent room");
        }

        var result = (TestData.Reservations.Any(x =>
            ((x.RoomId == reservation.RoomId)
             && !(reservation.EndTime < x.StartTime || reservation.StartTime > x.EndTime))));
        if (result)
        {
            return Conflict("reservation for that date already exists");
        }

        if (TestData.Reservations.Any())
        {
            reservation.Id = TestData.Reservations.Max(x => x.Id) + 1;
        }
        else
        {
            reservation.Id = 1;
        }
        TestData.Reservations.Add(reservation);
        return CreatedAtAction(nameof(GetById), new { id = reservation.Id }, reservation);
        
    }

    [HttpPut("{id}")]
    public IActionResult UpdateReservation(int id, Reservation updated)
    {
        var reservation = TestData.Reservations.FirstOrDefault(x => x.Id == id);

        if (reservation == null)
        {
            return NotFound();
        }

        var room = TestData.Rooms.FirstOrDefault(x => x.Id == updated.RoomId);

        if (room == null || !room.IsActive)
            return BadRequest("inactive or non existent room");

        var result = TestData.Reservations.Any(x =>
            x.Id != id &&
            x.RoomId == updated.RoomId &&
            !(updated.EndTime < x.StartTime || updated.StartTime > x.EndTime)
        );

        if (result)
            return Conflict("reservation overlaps with existing one");
        
        reservation.RoomId = updated.RoomId;
        reservation.OrganizerName = updated.OrganizerName;
        reservation.Topic = updated.Topic;
        reservation.StartTime = updated.StartTime;
        reservation.EndTime = updated.EndTime;
        reservation.Status = updated.Status;

        return Ok(reservation);
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteReservation(int id)
    {
        var reservation = TestData.Reservations.FirstOrDefault(x => x.Id == id);
        if (reservation == null)
        {
            return NotFound();
        }
        TestData.Reservations.Remove(reservation);
        return NoContent();
    }
}