namespace BookingApp.Models.Rooms.Models;

public class Apartment : Room
{
    private const int bedCapacity = 6;
    public Apartment()
        : base(bedCapacity)
    {

    }
}
