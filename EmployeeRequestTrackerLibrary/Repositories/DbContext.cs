/*
 * Author: Sakthi Santhosh
 * Created on: 10/05/2024
 */
using Microsoft.EntityFrameworkCore;

using EmployeeRequestTrackerLibrary.Models;

namespace EmployeeRequestTrackerLibrary.Repositories;

public class RequestTrackerContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Request> Requests { get; set; }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"<connection-string>");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(
            new Employee {
                Id = 101, Name = "Ilsa", Password = "secret", Role = "Admin" },
            new Employee {
                Id = 102, Name = "Faut", Password = "secret", Role = "Admin" },
            new Employee {
                Id = 103, Name = "Sandy", Password = "secret", Role = "User" }
        );

        modelBuilder.Entity<Request>().HasKey(request => request.RequestNumber);

        modelBuilder.Entity<Request>()
            .HasOne(request => request.RaisedByEmployee)
            .WithMany(employee => employee.RequestsRaised)
            .HasForeignKey(request => request.RequestRaisedBy)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        modelBuilder.Entity<Request>()
            .HasOne(request => request.RequestClosedByEmployee)
            .WithMany(employee => employee.RequestsClosed)
            .HasForeignKey(request => request.RequestClosedBy)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
