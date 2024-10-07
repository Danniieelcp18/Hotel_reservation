using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Reservation.Models;

public class Booking
{
    public int Id { get; set; }
    public required int RoomId { get; set; }
    public required int GuestId { get; set; }
    public required int EmployeeId { get; set; }
    public required DateTime StarDate { get; set; }
    public DateTime EndDate { get; set; }
    public required double TotalCost { get; set; }
}
