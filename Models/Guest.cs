using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Bogus.DataSets;

namespace Hotel_Reservation.Models;

public class Guest
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("first_name")]
    [Required(ErrorMessage = "First name is required.")]
    [StringLength(255, ErrorMessage = "First name cannot exceed 255 characters.")]
    public required string FistName { get; set; }
    [Column("last_name")]
    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(255, ErrorMessage = "Last name cannot exceed 255 characters.")]
    public required string LastName { get; set; }

    [Column("email")]
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    [MaxLength(255, ErrorMessage = "The email must have a maximum of {255} character ")]
    public required string Email { get; set; }

    [Column("identification_number")]
    [Required(ErrorMessage = "identification number is required.")]
    [MaxLength(20, ErrorMessage = "The identification number must have a maximum of {20} character ")]
    public required string IdentificationNumber { get; set; }
    [Column("phone_number")]
    [Required(ErrorMessage = "phone number is required.")]
    [MaxLength(20, ErrorMessage = "The phone number must have a maximum of {20} character ")]
    public required string PhoneNumber { get; set; }

    [Column("bhirtdate")]
    public DateTime? Bhirthdate { get; set; }
}
