using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Reservation.Models;

public class Booking
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("room_id")]
    [Required(ErrorMessage = "Room ID is required.")]
    public required int RoomId { get; set; }

    [Column("guest_id")]
    [Required(ErrorMessage = "Guest ID is required.")]
    public required int GuestId { get; set; }

    [Column("employee_id")]
    [Required(ErrorMessage = "Employee ID is required.")]
    public required int EmployeeId { get; set; }

    [Column("star_date")]
    [Required(ErrorMessage = "Start date is required.")]
    public required DateTime StarDate { get; set; }

    [Column("end_date")]
    public DateTime EndDate { get; set; }

    [Column("total_cost")]
    [Required(ErrorMessage = "Total cost is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Total cost must be greater than zero.")]
    public required double TotalCost { get; set; }


    [ForeignKey(nameof(RoomId))]
    public Room? Room { get; set; }

    [ForeignKey(nameof(GuestId))]
    public Guest? Guest { get; set; }

    [ForeignKey(nameof(EmployeeId))]
  
    public Employee? Employee{ get; set; }
}
