using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Reservation.Models;
using Hotel_Reservation.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Reservation.Controllers.v1.Bookings;

[ApiController]
[Route("api/v1/Bookings")]
public class BookinDeleteController(IBooking bookingService) : ControllerBase
{
    private readonly IBooking _bookingService = bookingService;

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Booking>> DeleteBooking(int id)
    {
        var booking = await _bookingService.DeleteBooking(id);
        if (booking == null) return NotFound();
        return Ok(booking);
    }
}
