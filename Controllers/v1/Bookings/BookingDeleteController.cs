using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Reservation.Models;
using Hotel_Reservation.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Hotel_Reservation.Controllers.v1.Bookings;

[ApiController]
[Route("api/v1/bookings")]
[Tags("bookings")]

public class BookingDeleteController(IBooking bookingService) : ControllerBase
{
    private readonly IBooking _bookingService = bookingService;

    [HttpDelete("{id}")]
    [Authorize]
    [SwaggerOperation(
        Summary = "Deletes a booking",
        Description = "Deletes a booking identified by the specified ID. Requires authorization."
    )]
    [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Booking>> DeleteBooking(int id)
    {
        var booking = await _bookingService.DeleteBooking(id);
        if (booking == null) return NotFound();
        return Ok(booking);
    }
}
