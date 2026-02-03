using Microsoft.EntityFrameworkCore;
using parking.api.Models;

namespace parking.api.Data;

public class ParkingContext : DbContext
{
    public ParkingContext(DbContextOptions<ParkingContext> options)
        : base(options)
    {
    }

    public DbSet<ParkingZone> ParkingZones => Set<ParkingZone>();
    public DbSet<ParkingSpot> ParkingSpots => Set<ParkingSpot>();
    public DbSet<ParkingTicket> ParkingTickets => Set<ParkingTicket>();
}
