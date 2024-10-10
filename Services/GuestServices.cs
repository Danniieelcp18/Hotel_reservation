using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Reservation.Data;
using Hotel_Reservation.Models;
using Hotel_Reservation.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation.Services;

public class GuestServices : IGuestRepository
{

    private readonly ApplicationDbContext _context;

    public GuestServices(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Guest> Delete(int id)
    {
        var guest = await GetById(id);
        if (guest != null)
        {
            _context.Guests.Remove(guest);
            await _context.SaveChangesAsync();
        }
        return guest;

    }

    public async Task<IEnumerable<Guest>> GetAll()
    {
        return await _context.Guests.ToListAsync();
    }

    public async Task<Guest> GetById(int id)
    {
        var guest = await _context.Guests.FindAsync(id);
        return guest;
    }

    public async Task<IEnumerable<Guest>> GetByKeyword(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            return await GetAll();
        }

        return await _context.Guests.Where(
            v => v.FistName.Contains(keyword) ||
            v.LastName.Contains(keyword) ||
            v.Email.Contains(keyword)).ToListAsync();
    }

    public async Task<Guest> Update(Guest guest)
    {

        if (guest == null)
        {
            throw new ArgumentNullException(nameof(guest), "El cliente no puede ser nullo.");
        }
        _context.Entry(guest).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return guest;



    }


}
