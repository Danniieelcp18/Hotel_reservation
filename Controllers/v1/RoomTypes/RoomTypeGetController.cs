using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Reservation.Models;
using Hotel_Reservation.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Hotel_Reservation.Controllers.v1.RoomTypes;

[ApiController]
[Route("api/v1/room_types")]
[Tags("room_types")]
public class RoomTypeGetController(IRoomTypesRepository roomTypeRepository) : ControllerBase
{
    private readonly IRoomTypesRepository _roomTypeRepository = roomTypeRepository;

    [HttpGet]
    [SwaggerOperation(
    Summary = "Gets all room types",
    Description = "Retrieves a list of all available room types."
)]
    [ProducesResponseType(typeof(IEnumerable<RoomType>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<RoomType>>> GetAll()
    {
        var roomTypes = await _roomTypeRepository.GetAll();
        return Ok(roomTypes);
    }


    [HttpGet("{id}")]

    [SwaggerOperation(
        Summary = "Gets a room type by ID",
        Description = "Retrieves the details of a room type identified by the specified ID."
    )]
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

    [SwaggerOperation(
        Summary = "Gets a room type by status",
        Description = "Retrieves the room type associated with the specified status ID."
    )]
    [ProducesResponseType(typeof(RoomType), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
