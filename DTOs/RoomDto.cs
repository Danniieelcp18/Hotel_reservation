using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Reservation.DTOs;

    public class RoomDto
    {
    public int Id { get; set; }
    public required string RoomNumber { get; set; }
    public decimal PricePerNight { get; set; }
    public bool Availability { get; set; }
}
