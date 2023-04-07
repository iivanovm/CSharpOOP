﻿using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Bookings.Models;

public class Booking : IBooking
{
    private IRoom room;
    private int residenceDuration;
    private int adultsCount;
    private int childrenCount;
    private int bookingNumber;
    public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
    {
        Room = room;
        ResidenceDuration = residenceDuration;
        AdultsCount = adultsCount;
        ChildrenCount = childrenCount;
        BookingNumber = bookingNumber;
    }

    public IRoom Room
    {
        get { return room; }
        private set { room = value; }
    }
    public int ResidenceDuration
    {
        get => residenceDuration;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
            }
            residenceDuration = value;
        }
    }
    public int AdultsCount
    {
        get => adultsCount;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
            }
            adultsCount = value;
        }
    }
    public int ChildrenCount
    {
        get => childrenCount;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.ChildrenNegative);
            }
            childrenCount = value;
        }
    }
    public int BookingNumber
    {
        get { return bookingNumber; }
        private set { bookingNumber = value; }
    }


    public string BookingSummary()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Booking number: {BookingNumber}")
        .AppendLine($"Room type: {room.GetType().Name}")
        .AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}")
        .AppendLine($"Total amount paid: {Math.Round(ResidenceDuration * this.room.PricePerNight, 2):F2}");

        return sb.ToString().Trim();
    }
  
}
