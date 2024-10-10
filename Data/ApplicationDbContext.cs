using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Reservation.Models;
using Hotel_Reservation.Seeders;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet <RoomType> RoomTypes { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        RoomTypeSeeder.Seed(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    internal async Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}
