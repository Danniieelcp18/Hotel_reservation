using Hotel_Reservation.Data;
using Hotel_Reservation.DTOs;
using Hotel_Reservation.Models;
using Hotel_Reservation.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation.Services;

public class RoomServices : IRoomRepository
{

    private readonly ApplicationDbContext _context;

    public RoomServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Room?> Delete(int id)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room == null)
        {
            return null;
        }
        _context.Rooms.Remove(room);

        await _context.SaveChangesAsync();
        return room;


    }



    public async Task<IEnumerable<Room>> GetAllRooms()
    {
        return await _context.Rooms.ToListAsync();
    }

    public async Task<IEnumerable<RoomDto>> GetAvailableRoomsAsync()
    {
        return await _context.Rooms
                  .Where(r => r.Availability)
                  .Select(r => new RoomDto
                  {
                      Id = r.Id,
                      RoomNumber = r.RoomNumber,
                      PricePerNight = (decimal)r.PriceForNight,
                      Availability = r.Availability
                  }).ToListAsync();
    }



    public async Task<Room> GetById(int id)
    {
        var room = await _context.Rooms.FindAsync(id);
        return room;
    }

    public async Task<IEnumerable<Room>> GetOccupiedRoom()
    {
        return await _context.Rooms
            .Where(room => !room.IsAvailable)
            .ToListAsync();
    }
}

