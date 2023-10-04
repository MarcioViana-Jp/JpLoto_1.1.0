using JpLoto.Application.Dto.Shared;
using JpLoto.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace JpLoto.Application.Dto;

public class Loto7ResultDto : LotoResultDtoBase
{
    [Required]
    public int Prize5Value { get; set; }
    [Required]
    public int Prize6Value { get; set; }
    public Loto7ResultDto() { }
    public Loto7ResultDto(int drawnNumber, DateTime date, string numbers, string bonus, int prize1Value, int prize2Value, int prize3Value, int prize4Value, int prize5Value, int prize6Value)
    {
        Id = default;
        DrawNumber = drawnNumber;
        Date = date;
        Numbers = numbers;
        Bonus = bonus;
        Prize1Value = prize1Value;
        Prize2Value = prize2Value;
        Prize3Value = prize3Value;
        Prize4Value = prize4Value;
        Prize5Value = prize5Value;
        Prize6Value = prize6Value;
        Editing = false;
        IsNew = false;
    }
    public Loto7ResultDto(int id, int drawnNumber, DateTime date, string numbers, string bonus, int prize1Value, int prize2Value, int prize3Value, int prize4Value, int prize5Value, int prize6Value)
    {
        Id = id;
        DrawNumber = drawnNumber;
        Date = date;
        Numbers = numbers;
        Bonus = bonus;
        Prize1Value = prize1Value;
        Prize2Value = prize2Value;
        Prize3Value = prize3Value;
        Prize4Value = prize4Value;
        Prize5Value = prize5Value;
        Prize6Value = prize6Value;
        Editing = false;
        IsNew = false;
    }
    public Loto7ResultDto(Loto7Result result)
    {
        Id = result.Id;
        DrawNumber = result.DrawNumber;
        Date = result.Date;
        Numbers = result.Numbers;
        Bonus = result.Bonus;
        Prize1Value = result.Prize1Value;
        Prize2Value = result.Prize2Value;
        Prize3Value = result.Prize3Value;
        Prize4Value = result.Prize4Value;
        Prize5Value = result.Prize5Value;
        Prize6Value = result.Prize6Value;
        Editing = false;
        IsNew = false;
    }
    public Loto7Result ConvertToEntity(Loto7ResultDto dto)
    {
        return new Loto7Result
        {
            DrawNumber = dto.DrawNumber,
            Date = dto.Date,
            Numbers = dto.Numbers,
            Bonus = dto.Bonus,
            Prize1Value = dto.Prize1Value,
            Prize2Value = dto.Prize2Value,
            Prize3Value = dto.Prize3Value,
            Prize4Value = dto.Prize4Value,
            Prize5Value = dto.Prize5Value,
            Prize6Value = dto.Prize6Value,
            Editing = false,
            IsNew = false
        };
    }
}
