using System;
using System.ComponentModel.DataAnnotations;

namespace Prism.Presentation.Models;

public class LoginFormModel
{
    private string email = string.Empty;

    [EmailAddress]
    [Required]
    public string Email
    {
        get => email;
        set => email = value.ToLower();
    }

    [Required]
    public string Password { get; set; } = string.Empty;
    public bool Remember { get; set; }
}
