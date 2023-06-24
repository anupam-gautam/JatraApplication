using System;
using System.Collections.Generic;

namespace JatraApplication.Models.DatabaseModels;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;
    public int Roles { get; set; } 

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
    public string VCode { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public DateTime? CreatedDate { get; set; }
}
