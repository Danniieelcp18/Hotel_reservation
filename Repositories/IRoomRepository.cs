using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Reservation.DTOs;
using Hotel_Reservation.Models;

namespace Hotel_Reservation.Repositories;

public interface IRoomRepository
{

    Task<Room> GetById(int id);

    Task<Room> Delete(int id);
    Task<IEnumerable<Room>> GetOccupiedRoom();

    Task<IEnumerable<Room>> GetAllRooms();
    Task<IEnumerable<RoomDto>> GetAvailableRoomsAsync();



}