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
    public class bookingPostController(IBooking bookingService) : ControllerBase
    {
         private readonly IBooking _bookingService = bookingService;

          [HttpPost]
          [Authorize]
        public async Task<ActionResult> CreateBooking([FromBody] Booking booking)
        {
            await _bookingService.Add(booking);
            return CreatedAtAction(nameof(BookinGetController.GetBooking), new { id = booking.Id }, booking);
        }
    }
   