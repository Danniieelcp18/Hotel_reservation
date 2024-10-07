using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Reservation.Models;

namespace Hotel_Reservation.Repositories;

    public interface IRoomTypesRepository
    {
    Task<IEnumerable<RoomType>> GetAll();
    Task<RoomType?> GetById(int id);
    Task<RoomType?> GetByStatus(int id);
}
