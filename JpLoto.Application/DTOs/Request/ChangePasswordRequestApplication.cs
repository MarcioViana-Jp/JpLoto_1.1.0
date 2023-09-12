using System.ComponentModel.DataAnnotations;

namespace JpLoto.Application.DTOs.Request;

public class ChangePasswordRequestApplication
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 6)]
    public string SenhaAtual { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 6)]
    public string NovaSenha { get; set; } = string.Empty;

    [Compare(nameof(NovaSenha), ErrorMessage = "As senhas devem ser iguais")]
    public string SenhaConfirmacao { get; set; } = string.Empty;
}
