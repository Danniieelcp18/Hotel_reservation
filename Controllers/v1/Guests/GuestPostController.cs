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
    public class GuestPostController(IGuestRepository guestService) : ControllerBase
    { 
         private readonly IGuestRepository _guestService = guestService;

    [HttpPost]
    [Authorize]
        public async Task<ActionResult> CreateGuest([FromBody] Guest guest)
        {
            
            return CreatedAtAction(nameof(GuestGetController.GetGuest), new { id = guest.Id }, guest);
        }

    }
