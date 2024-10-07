using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Reservation.Models;

public class Room
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("room_number")]
    [Required(ErrorMessage = "Room number is required.")]
    [MinLength(1, ErrorMessage = "The field Name needs {1} characters at least")]
    [MaxLength(10, ErrorMessage = "The name must have a maximum of {10} character ")]

    public required string RoomNumber { get; set; }



    [Column("room_type_id")]
    [Required(ErrorMessage = "Room type ID is required.")]
    public required int RoomTypeId { get; set; }

    [Column("price_for_night")]
    [Required(ErrorMessage = "Price per night is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price for night must be greater than zero.")]
    public required double PriceForNight { get; set; }

    [Column("availability")]
    [Required(ErrorMessage = "Availability is required.")]
    public required bool Availability { get; set; }
    
    [Column("max_occupacy_persons")]
    [Required(ErrorMessage = "Maximum occupancy is required.")]
    [Range(1, 10, ErrorMessage = "Maximum occupancy must be between 1 and 10.")]
    public required int MaxOccupacyPersons { get; set; }

    [ForeignKey(nameof(RoomTypeId))]
    public RoomType? RoomType { get; set; }
    public bool IsAvailable { get; internal set; }
}
