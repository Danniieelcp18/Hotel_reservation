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

namespace Hotel_Reservation.Controllers.v1.Auth;

[ApiController]
[Route("api/v1/Auth")]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly Utilities _utilities;


    public AuthController(ApplicationDbContext context, Utilities utilities)
    {
        _context = context;
        _utilities = utilities;
    }


    [HttpPost("register")]
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
        return Ok("User registered successfully");
    }

    [HttpPost("login")]
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
