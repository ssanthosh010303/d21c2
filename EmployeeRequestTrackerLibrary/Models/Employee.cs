/*
 * Author: Sakthi Santhosh
 * Created on: 10/05/2024
 */
#nullable enable

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeRequestTrackerLibrary.Models;

public class Employee
{
    private string _passwordHash;

    public int EmployeeId { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }


    [Required]
    [StringLength(50)]
    public string Password
    {
        get { return _passwordHash; }
        set { _passwordHash = HashPassword(value); }
    }

    [Required]
    [StringLength(50)]
    public string Role { get; set; }

    // Navigation Properties
    public ICollection<Request> RequestsRaised { get; set; }
    public ICollection<Request> RequestsClosed { get; set; }

    public bool VerifyPassword(string password)
    {
        string hashedPassword = HashPassword(password);
        return passwordHash == hashedPassword;
    }

    private string HashPassword(string password)
    {
        // PBKDF + Hashing Implementation
    }
}
