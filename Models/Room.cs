using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Reservation.Models;

public class Room
{
    public int Id { get; set; }
    public required string RoomNumber { get; set; }
    public required int RoomTypeId { get; set; }
    public required double PriceForNight { get; set; }
    public required bool Availability { get; set; }
    public required int MaxOccupacyPersons { get; set; }
}
