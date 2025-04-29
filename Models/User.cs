using System.ComponentModel.DataAnnotations;

namespace SRS6.Models;

/// <summary>
/// Модель данных
/// </summary>

public class User
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Role { get; set; }
}