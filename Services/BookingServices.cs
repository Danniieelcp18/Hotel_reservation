using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Reservation.Data;
using Hotel_Reservation.Models;
using Hotel_Reservation.Repositories;

namespace Hotel_Reservation.Services;

public class BookingServices : IBooking
{

    private readonly ApplicationDbContext _context;

    public BookingServices (ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Add(Booking booking)
    {
        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();
    }

    public  async Task<Booking> DeleteBooking(int id)
    {
        var booking = await GetId(id);
        if (booking != null)
        {
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }
        return booking;
    }

    public Task<Booking?> GethNumberIdentificaction(string numeroIdentification)
    {
        throw new NotImplementedException();
    }

    public  async Task<Booking?> GetId(int id)
    {
        var booking = await _context.Bookings.FindAsync(id);

        return booking;
    }
}
