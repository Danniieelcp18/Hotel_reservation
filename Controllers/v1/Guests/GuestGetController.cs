using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Reservation.Models;
using Hotel_Reservation.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Hotel_Reservation.Controllers.v1.Guests;

[ApiController]
[Route("api/v1/guests")]
[Tags("guests")]

public class GuestGetController(IGuestRepository guestService) : ControllerBase
{
    private readonly IGuestRepository _guestService = guestService;

     [SwaggerOperation(
        Summary = "Gets a guest by ID",
        Description = "Retrieves the details of a guest identified by the specified ID. Requires authorization."
    )]
    [ProducesResponseType(typeof(Guest), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<Guest>> GetGuest(int id)
    {
        var guest = await _guestService.GetById(id);
        if (guest == null) return NotFound();
        return Ok(guest);
    }

    [HttpGet("get_all")]
    [Authorize]
    [SwaggerOperation(
        Summary = "Gets all guests",
        Description = "Retrieves a list of all guests. Can filter by an optional keyword."
    )]
    [ProducesResponseType(typeof(IEnumerable<Guest>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Guest>>> GetAllGuests(string keyword = null)
    {
        var guests = await _guestService.GetByKeyword(keyword);
        return Ok(guests);
    }


    [HttpGet("keyword")]
    [Authorize] 
    [SwaggerOperation(
        Summary = "Gets guests by keyword",
        Description = "Retrieves guests that match the specified search keyword. Requires authorization."
    )]
    [ProducesResponseType(typeof(IEnumerable<Guest>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<Guest>>> GetGuestsByKeyword(string keyword)
    {
        var guests = await _guestService.GetByKeyword(keyword);

        if (guests == null || !guests.Any())
        {
            return NotFound("No se encontraron resultados.");
        }

        return Ok(guests);
    }
}
