using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Reservation.Models;

public class RoomType
{


    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [Required(ErrorMessage = "Room type name is required.")]
    [MinLength(4, ErrorMessage = "The field Name needs {1} characters at least")]
    [MaxLength(255, ErrorMessage = "The name must have a maximum of {255} character ")]
    public required string Name { get; set; }

    [Column("description")]
    [MaxLength(255, ErrorMessage = "The description must have a maximum of {255} character ")]
    public string? Description { get; set; }

}
