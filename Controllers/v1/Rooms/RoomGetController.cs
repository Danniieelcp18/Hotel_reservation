using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Reservation.DTOs;
using Hotel_Reservation.Models;
using Hotel_Reservation.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Reservation.Controllers.v1.Rooms;

[ApiController]
[Route("api/v1/Rooms")]
public class RoomGetController(IRoomRepository roomRepository) : ControllerBase
{
    private readonly IRoomRepository _roomRepository = roomRepository;

   
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Room>>> GetAllRooms()
    {
        var rooms = await _roomRepository.GetAllRooms();
        return Ok(rooms);
    }

    
    [HttpGet("available")]
    public async Task<ActionResult<IEnumerable<RoomDto>>> GetAvailableRooms()
    {
        var availableRooms = await _roomRepository.GetAvailableRoomsAsync();
        return Ok(availableRooms);
    }


    [HttpGet("occupied")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<Room>>> GetOccupiedRooms()
    {
        var occupiedRooms = await _roomRepository.GetOccupiedRoom();
        return Ok(occupiedRooms);
    }

    [HttpGet("{id}")]
    [Authorize]
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
