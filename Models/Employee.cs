using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Reservation.Models;

public class Employee
{
    public int Id { get; set; }
    public required string FistName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string IdentificationNumber { get; set; }
    public required string Password { get; set; }

}
