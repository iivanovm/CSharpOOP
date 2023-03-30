namespace BookingApp.Models.Rooms.Models;

public class DoubleBed : Room
{
    private const int maxBedCapacity = 2;

    public DoubleBed() : 
        base(maxBedCapacity)
    {

    }
}