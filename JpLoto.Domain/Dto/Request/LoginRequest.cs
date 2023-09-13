using System.ComponentModel.DataAnnotations;

namespace JpLoto.Domain.Dto.Request;

public class LoginRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    [StringLength(50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 10)]
    public string? Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string? Password { get; set; } = string.Empty;
    public bool IsPersistent { get; set; } = false;
}
