using System;

namespace parking.api.Models;

public class ParkingZone
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal HourlyRate { get; set; }

    public ICollection<ParkingSpot> Spots { get; set; } = new List<ParkingSpot>();
}
