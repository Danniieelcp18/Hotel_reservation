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
    public class BookingPostController(IBooking bookingService) : ControllerBase
    {
         private readonly IBooking _bookingService = bookingService;

          [HttpPost]
          [Authorize]
            [SwaggerOperation(
        Summary = "Creates a new booking",
        Description = "Adds a new booking to the system. Requires authorization."
    )]
    [ProducesResponseType(typeof(Booking), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateBooking([FromBody] Booking booking)
        {
            await _bookingService.Add(booking);
            return CreatedAtAction(nameof(BookingGetController.GetBooking), new { id = booking.Id }, booking);
        }
    }
