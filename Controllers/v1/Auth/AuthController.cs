using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Reservation.Config;
using Hotel_Reservation.Data;
using Hotel_Reservation.DTOs;
using Hotel_Reservation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Hotel_Reservation.Controllers.v1.Auth;

[ApiController]
[Route("api/v1/auth")]
[Tags("auth")]


public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly Utilities _utilities;


    public AuthController(ApplicationDbContext context, Utilities utilities)
    {
        _context = context;
        _utilities = utilities;
    }


    [HttpPost("register_employee")]
    [SwaggerOperation(Summary = "Register a new employee",
     Description = "you can register a new employee"
    )]
    [SwaggerResponse(200, "Employee registered successfully")]
    [SwaggerResponse(400, "Invalid model state or email already exists")]

    public async Task<IActionResult> Register(Employee newEmployee)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (_context.Employees.Any(u => u.Email == newEmployee.Email))
        {
            return BadRequest("Email already exists");
        }

        newEmployee.Password = _utilities.EncryptSHA256(newEmployee.Password);

        _context.Employees.Add(newEmployee);
        await _context.SaveChangesAsync();
        return Ok("Employee registered successfully");
    }

    [HttpPost("register_guest")]
    [SwaggerOperation(Summary = "Register a new guest",
   Description = "you can register a new guest"
  )]
    [SwaggerResponse(200, "Guest registered successfully")]
    [SwaggerResponse(400, "Invalid model state or email already exists")]

    public async Task<IActionResult> RegisterGuest(Guest newGuest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (_context.Employees.Any(u => u.Email == newGuest.Email))
        {
            return BadRequest("Email already exists");
        }


        _context.Guests.Add(newGuest);
        await _context.SaveChangesAsync();
        return Ok("Guest registered successfully");
    }

    [HttpPost("login")]
    
    [SwaggerOperation(
        Summary = "Logs in an employee",
        Description = "Authenticates an employee by email and password, returning a JWT token upon successful login."
    )]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login(LoginEmployeeDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _context.Employees.FirstOrDefaultAsync(u => u.Email == request.Email);
        if (user == null)
        {
            return Unauthorized("Invalid email");
        }

        var passwordIsValid = user.Password == _utilities.EncryptSHA256(request.Password);

        if (passwordIsValid == false)
        {
            return Unauthorized("Invalid password");
        }

        var token = _utilities.GenerateJwtToken(user);
        return Ok(new
        {
            message = "Please,save this token",
            jwt = token
        });
    }


}
