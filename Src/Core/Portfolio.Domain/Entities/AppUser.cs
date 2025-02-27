﻿
using Microsoft.AspNetCore.Identity;

namespace Portfolio.Domain.Entities;

public class AppUser:IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string RefreshToken { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime RefreshTokenExpiredDate { get; set; }
    public List<Project> Projects { get; set; }
    public List<Skill> Skills { get; set; }
}
