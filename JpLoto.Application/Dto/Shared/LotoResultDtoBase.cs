using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JpLoto.Application.Dto.Shared;

public class LotoResultDtoBase
{
    public int Id { get; set; }
    [Required]
    public int DrawNumber { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public string? Numbers { get; set; } = string.Empty;
    [Required]
    public string? Bonus { get; set; } = string.Empty;
    [Required]
    public int Prize1Value { get; set; }
    [Required]
    public int Prize2Value { get; set; }
    [Required]
    public int Prize3Value { get; set; }
    [Required]
    public int Prize4Value { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public bool Editing { get; set; } = false;
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public bool IsNew { get; set; } = false;
}
