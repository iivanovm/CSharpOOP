using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Rooms.Models;

public abstract class Room : IRoom
{

    private int bedCapacity;
    protected double pricePerNight;

    public Room(int bedCapacity)
    {
        BedCapacity = bedCapacity;
    }

    public int BedCapacity
    {
        get { return bedCapacity; }
        private set { bedCapacity = value; }
    }
    public double PricePerNight
    {
        get => pricePerNight;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
            }
            pricePerNight = value;
        }
    }

    public void SetPrice(double price)=>PricePerNight = price;
}
