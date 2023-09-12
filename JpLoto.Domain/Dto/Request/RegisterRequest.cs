using System.ComponentModel.DataAnnotations;

namespace JPLoto.Domain.Dto.Request;

public class RegisterRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    public string? Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 6)]
    public string? Password { get; set; } = string.Empty;

    [Compare(nameof(Password), ErrorMessage = "As senhas devem ser iguais")]
    public string? ConfirmPassword { get; set; } = string.Empty;
    public bool isAdmin { get; set; } = false;
}
