using System.ComponentModel.DataAnnotations;

namespace JPLoto.Domain.Dto.Request;

public class LoginRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    public string? Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string? Password { get; set; } = string.Empty;
    public bool IsPersistent { get; set; } = false;
}
