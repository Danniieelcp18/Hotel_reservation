using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Reservation.Models;
using Hotel_Reservation.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Reservation.Controllers.v1.Rooms;

[ApiController]
[Route("api/v1/Rooms")]
public class RoomDeleteController(IRoomRepository roomRepository) : ControllerBase
{

    private readonly IRoomRepository _roomRepository = roomRepository;


    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Room>> DeleteRoom(int id)
    {
        var room = await _roomRepository.Delete(id);
        if (room == null)
        {
            return NotFound();
        }
        return Ok(room);
    }
}
