using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Reservation.DTOs;
using Hotel_Reservation.Models;
using Hotel_Reservation.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Hotel_Reservation.Controllers.v1.Rooms;

[ApiController]
[Route("api/v1/rooms")]
[Tags("rooms")]
public class RoomGetController(IRoomRepository roomRepository) : ControllerBase
{
    private readonly IRoomRepository _roomRepository = roomRepository;

   
    [HttpGet]
     [SwaggerOperation(
        Summary = "Gets all rooms",
        Description = "Retrieves a list of all rooms."
    )]
    [ProducesResponseType(typeof(IEnumerable<Room>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Room>>> GetAllRooms()
    {
        var rooms = await _roomRepository.GetAllRooms();
        return Ok(rooms);
    }

    
    [HttpGet("available")]
     [SwaggerOperation(
        Summary = "Gets available rooms",
        Description = "Retrieves a list of rooms that are currently available."
    )]
    [ProducesResponseType(typeof(IEnumerable<RoomDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<RoomDto>>> GetAvailableRooms()
    {
        var availableRooms = await _roomRepository.GetAvailableRoomsAsync();
        return Ok(availableRooms);
    }


    [HttpGet("occupied")]
    [Authorize]
    [SwaggerOperation(
        Summary = "Gets occupied rooms",
        Description = "Retrieves a list of rooms that are currently occupied. Requires authorization."
    )]
    [ProducesResponseType(typeof(IEnumerable<Room>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Room>>> GetOccupiedRooms()
    {
        var occupiedRooms = await _roomRepository.GetOccupiedRoom();
        return Ok(occupiedRooms);
    }

    [HttpGet("{id}")]
    [Authorize]
     [SwaggerOperation(
        Summary = "Gets a room by ID",
        Description = "Retrieves the details of a room identified by the specified ID. Requires authorization."
    )]
    [ProducesResponseType(typeof(Room), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Room>> GetRoomById(int id)
    {
        var room = await _roomRepository.GetById(id);
        if (room == null)
        {
            return NotFound();
        }
        return Ok(room);
    }

}
