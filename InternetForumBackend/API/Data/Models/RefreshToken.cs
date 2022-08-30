using System;

namespace API.Data.Models;

/// <summary>
/// This model doesn't need to be added in the database
/// </summary>
public class RefreshToken
{
    public string Token { get; set; } = string.Empty;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Expires { get; set; }
}