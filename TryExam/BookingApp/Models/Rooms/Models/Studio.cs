namespace BookingApp.Models.Rooms.Models;

public class Studio : Room
{
    private const int MaxBedCapacity = 4;
    public Studio() : base(MaxBedCapacity)
    {
    }
}