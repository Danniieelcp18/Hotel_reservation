using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Reservation.Models;
using Hotel_Reservation.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Hotel_Reservation.Controllers.v1.Rooms;

[ApiController]
[Route("api/v1/rooms")]
[Tags("rooms")]
public class RoomDeleteController(IRoomRepository roomRepository) : ControllerBase
{

    private readonly IRoomRepository _roomRepository = roomRepository;


    [HttpDelete("{id}")]
    [Authorize]
    [Authorize]
    [SwaggerOperation(
        Summary = "Deletes a room by ID",
        Description = "Removes a room identified by the specified ID. Requires authorization."
    )]
    [ProducesResponseType(typeof(Room), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
