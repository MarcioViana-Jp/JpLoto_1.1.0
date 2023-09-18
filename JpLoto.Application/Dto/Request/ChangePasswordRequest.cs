using System.ComponentModel.DataAnnotations;

namespace JpLoto.Application.Dto.Request;

public class ChangePasswordRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 6)]
    public string CurrentPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 6)]
    public string NewPassword { get; set; } = string.Empty;

    [Compare(nameof(NewPassword), ErrorMessage = "As Passwords devem ser iguais")]
    public string ConfirmPassword { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
}
