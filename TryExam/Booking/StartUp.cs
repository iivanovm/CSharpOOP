namespace BookingApp
{
    using BookingApp.Core;
    using BookingApp.Utilities;
    using BookingApp.Core.Contracts;
    using System.Reflection;
    using BookingApp.Models.Bookings.Models;
    using BookingApp.Models.Rooms.Models;
    using System.Linq;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
           // Don't forget to comment out the commented code lines in the Engine class!
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
