using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Reservation.Models;
using Hotel_Reservation.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Reservation.Controllers.v1.Guests;

[ApiController]
[Route("api/v1/Guests")]

public class GuestGetController(IGuestRepository guestService) : ControllerBase
{
    private readonly IGuestRepository _guestService = guestService;

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<Guest>> GetGuest(int id)
    {
        var guest = await _guestService.GetById(id);
        if (guest == null) return NotFound();
        return Ok(guest);
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<Guest>>> GetAllGuests(string keyword = null)
    {
        var guests = await _guestService.GetByKeyword(keyword);
        return Ok(guests);
    }


    [HttpGet("keyword")]
    [Authorize]
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
