using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Reservation.Data;
using Hotel_Reservation.Models;
using Hotel_Reservation.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Reservation.Controllers.v1.Bookings;

[ApiController]
[Route("api/v1/Booking")]
public class BookinGetController(IBooking bookingService) : ControllerBase
{  private readonly IBooking _bookingService = bookingService;

    [HttpGet("{id}")]
    [Authorize]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _bookingService.GetId(id);
            if (booking == null) return NotFound();
            return Ok(booking);
        }

            
}
