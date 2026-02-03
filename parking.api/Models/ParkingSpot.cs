using System;

namespace parking.api.Models;

public class ParkingSpot
{
    public int Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public bool IsOccupied { get; set; }
    public int ZoneId { get; set; }
}
