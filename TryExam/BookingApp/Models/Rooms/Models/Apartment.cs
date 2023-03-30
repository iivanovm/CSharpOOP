namespace BookingApp.Models.Rooms.Models;

public class Apartment : Room
{
    private const int maxBedCapacity = 6;
    public Apartment() : base(maxBedCapacity)
    {
    }
}
