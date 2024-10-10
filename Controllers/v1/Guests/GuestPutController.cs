using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Reservation.Models;
using Hotel_Reservation.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Reservation.Controllers.v1.Guests;

    [ApiController]
    [Route("api/v1/Guests")]
    
    public class GuestPutController(GuestServices guestService) : ControllerBase
    {
        private readonly GuestServices _guestService = guestService;


    [HttpPut]
    [Authorize]
    public async Task<ActionResult<Guest>> UpdateGuest(Guest guest)
    {
        if (guest == null)
        {
            return BadRequest("El huésped no puede ser nulo.");
        }

        try
        {
            var updatedGuest = await _guestService.Update(guest);
            return Ok(updatedGuest);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error en el servidor: " + ex.Message);
        }
    }
}
