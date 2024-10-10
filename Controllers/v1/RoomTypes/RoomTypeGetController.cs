using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Reservation.Models;
using Hotel_Reservation.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Reservation.Controllers.v1.RoomTypes;

    [ApiController]
    [Route("api/v1/RoomTypes")]
    public class RoomTypeGetController(IRoomTypesRepository roomTypeRepository) : ControllerBase
    {
        private readonly IRoomTypesRepository _roomTypeRepository = roomTypeRepository;

        [HttpGet]
    public async Task<ActionResult<IEnumerable<RoomType>>> GetAll()
    {
        var roomTypes = await _roomTypeRepository.GetAll();
        return Ok(roomTypes);
    }

  
    [HttpGet("{id}")]
    public async Task<ActionResult<RoomType>> GetById(int id)
    {
        var roomType = await _roomTypeRepository.GetById(id);
        if (roomType == null)
        {
            return NotFound();
        }
        return Ok(roomType);
    }

 
    [HttpGet("status/{id}")]
    public async Task<ActionResult<RoomType>> GetByStatus(int id)
    {
        var roomType = await _roomTypeRepository.GetByStatus(id);
        if (roomType == null)
        {
            return NotFound();
        }
        return Ok(roomType);
    }
    }
