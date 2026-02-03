using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using parking.api.Data;
using parking.api.Models;

namespace parking.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController(ParkingContext context) : ControllerBase
    {
        [HttpGet("zones")]
        public IActionResult GetParkingZones()
        {
            var zones = new
            {
                ZoneA = new { Capacity = 50, Occupied = 20 },
                ZoneB = new { Capacity = 30, Occupied = 15 },
                ZoneC = new { Capacity = 20, Occupied = 5 }
            }; //context.ParkingZones.ToList();
            return Ok(zones);
        }

        [HttpGet("zones/all")]
        public async Task<ActionResult<IEnumerable<ParkingZone>>> GetParkZones()
        {
            try
            {
                var parkingZones = await context.ParkingZones.ToListAsync();
                parkingZones.ForEach(zone =>
                {
                    zone.Spots = context.ParkingSpots
                        .Where(spot => spot.ZoneId == zone.Id)
                        .ToList();
                });
                return Ok(parkingZones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "GetParkZones - Internal server error: " + ex.Message);
            }
        }

        [HttpGet("spots")]
        public async Task<ActionResult<IEnumerable<ParkingSpot>>> GetSpots()
        {
            return await context.ParkingSpots
                .ToListAsync();
        }

        // GET: api/parkings/spots/5
        [HttpGet("spots/{id:int}")]
        public async Task<ActionResult<ParkingSpot>> GetSpot(int id)
        {
            var spot = await context.ParkingSpots
                .FirstOrDefaultAsync(s => s.Id == id);

            if (spot == null) return NotFound();
            return spot;
        }

        // POST: api/parkings/spots
        [HttpPost("spots")]
        public async Task<ActionResult<ParkingSpot>> CreateSpot(ParkingSpot spot)
        {
            context.ParkingSpots.Add(spot);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSpot), new { id = spot.Id }, spot);
        }

        // PUT: api/parkings/spots/5
        [HttpPut("spots/{id:int}")]
        public async Task<IActionResult> UpdateSpot(int id, ParkingSpot spot)
        {
            if (id != spot.Id) return BadRequest();

            context.Entry(spot).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/parkings/spots/5
        [HttpDelete("spots/{id:int}")]
        public async Task<IActionResult> DeleteSpot(int id)
        {
            var spot = await context.ParkingSpots.FindAsync(id);
            if (spot == null) return NotFound();

            context.ParkingSpots.Remove(spot);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
