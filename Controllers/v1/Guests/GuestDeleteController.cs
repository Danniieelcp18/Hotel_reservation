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
public class GuestDeleteController(IGuestRepository guestService) : ControllerBase
{

    private readonly IGuestRepository _guestService = guestService;

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Guest>> DeleteGuest(int id)
    {
        var guest = await _guestService.Delete(id);
        if (guest == null) return NotFound();
        return Ok(guest);
    }

}
