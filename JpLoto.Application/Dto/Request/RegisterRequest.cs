using System.ComponentModel.DataAnnotations;

namespace JpLoto.Application.Dto.Request;

public class RegisterRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    [StringLength(50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 10)]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 6)]
    public string Password { get; set; } = string.Empty;

    [Compare(nameof(Password), ErrorMessage = "As Passwords devem ser iguais")]
    public string ConfirmPassword { get; set; } = string.Empty;
}