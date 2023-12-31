﻿using System.ComponentModel.DataAnnotations;

namespace JpLoto.Application.Dto.Request;

public class EmailRequest
{
    [Required]
    [StringLength(50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 10)]
    [EmailAddress]
    [Display(Name = "E-mail")]
    public string Email { get; set; } = string.Empty;
    public string Host { get; set; } = string.Empty;
}
