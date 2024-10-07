using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus.DataSets;

namespace Hotel_Reservation.Models;

public class Guest
{
    public int Id { get; set; }
    public required string FistName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string IdentificationNumber { get; set; }
    public required string PhoneNumber { get; set; }
    public Date? Bhirthdate { get; set; }
}
