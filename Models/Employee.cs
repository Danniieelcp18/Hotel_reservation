using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Reservation.Models;

public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
     public int Id { get; set; }
    [Column("first_name")]
    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
    public required string FirstName { get; set; }
    [Column("last_name")]
    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
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

    [Column("password")]
    [Required(ErrorMessage = "Password is required.")]
    [StringLength(255, MinimumLength = 8)]
    [RegularExpression(@"^(?=.[a-z])(?=.[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one number.")]
    public required string Password { get; set; }

}
