﻿using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {

        private List<IBooking> bookings;
        public BookingRepository()
        {
            bookings = new List<IBooking>();
        }
        public void AddNew(IBooking model) => bookings.Add(model);
        public IReadOnlyCollection<IBooking> All() => bookings;
        public IBooking Select(string criteria) => bookings.FirstOrDefault(b => b.GetType().Name == criteria);
    }
}
