using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Reservation.Models;

namespace Hotel_Reservation.Repositories;

    public interface IGuestRepository
    {

    Task<IEnumerable<Guest>> GetByKeyword(string keyword);
    Task<IEnumerable<Guest>> GetAll();
    Task<Guest> Update(Guest guest);
    Task<Guest> Delete(int id);
    Task<Guest> GetById(int id);



}
