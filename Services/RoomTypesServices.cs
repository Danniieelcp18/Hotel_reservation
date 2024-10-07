using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Reservation.Data;
using Hotel_Reservation.Models;
using Hotel_Reservation.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation.Services;

public class RoomTypesServices : IRoomTypesRepository

{


    private readonly ApplicationDbContext _context;

    public RoomTypesServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public  async Task<IEnumerable<RoomType>> GetAll()
    {
        return await _context.RoomTypes.ToListAsync();
    }

    public async Task<RoomType?> GetById(int id)
    {
        var room = await _context.RoomTypes.FindAsync(id);
        return room;
    }

    public async Task<RoomType?> GetByStatus(int id)
    {
        throw new NotImplementedException();
    }
}

