using System;

namespace parking.api.Models;

public class ParkingTicket
{
    public int Id { get; set; }
    public string PlateNumber { get; set; } = string.Empty;
    public int SpotId { get; set; }
    public ParkingSpot? Spot { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public decimal? TotalPrice { get; set; }
}
