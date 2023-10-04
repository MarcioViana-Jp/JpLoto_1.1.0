using JpLoto.Application.Dto.Shared;
using JpLoto.Domain.Entities;

namespace JpLoto.Application.Dto;

public class MiniLotoResultDto : LotoResultDtoBase
{
    public MiniLotoResultDto() { }
    public MiniLotoResultDto(int drawnNumber, DateTime date, string numbers, string bonus, int prize1Value, int prize2Value, int prize3Value, int prize4Value)
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
        Editing = false;
        IsNew = false;
    }
    public MiniLotoResultDto(int id, int drawnNumber, DateTime date, string numbers, string bonus, int prize1Value, int prize2Value, int prize3Value, int prize4Value)
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
        Editing = false;
        IsNew = false;
    }
    public MiniLotoResultDto (MiniLotoResult result)
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
        Editing = false;
        IsNew = false;
    }
    public MiniLotoResult ConvertToEntity(MiniLotoResultDto dto)
    {
        return new MiniLotoResult
        {
            DrawNumber = dto.DrawNumber,
            Date = dto.Date,
            Numbers = dto.Numbers,
            Bonus = dto.Bonus,
            Prize1Value = dto.Prize1Value,
            Prize2Value = dto.Prize2Value,
            Prize3Value = dto.Prize3Value,
            Prize4Value = dto.Prize4Value,
            Editing = false,
            IsNew = false
        };
    }
}
