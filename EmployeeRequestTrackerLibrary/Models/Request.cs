/*
 * Author: Sakthi Santhosh
 * Created on: 10/05/2024
 */
#nullable enable

using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeRequestTrackerLibrary.Models;

public class Request
{
    [Key]
    public int RequestId { get; set; }

    [Required]
    public string RequestMessage { get; set; }

    [Required]
    public DateTime RequestDate { get; set; } = DateTime.Now;
    public DateTime? ClosedDate { get; set; }

    [Required]
    [StringLength(50)]
    public string RequestStatus { get; set; }

    [Required]
    public int RequestRaisedById { get; set; }
    public int? RequestClosedById { get; set; }

    // Navigation Property
    public Employee RaisedByEmployee { get; set; }
    public Employee RequestClosedByEmployee { get; set; }
}
