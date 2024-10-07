using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Reservation.Models;

namespace Hotel_Reservation.Repositories;

    public interface IBooking
    {
    Task<Booking> DeleteBooking(int id);
    Task Add(Booking booking);

    Task<Booking?> GetId(int id);
    Task<Booking?> GethNumberIdentificaction(string numeroIdentification);
}
