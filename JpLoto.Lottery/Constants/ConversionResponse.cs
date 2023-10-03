using JpLoto.Lottery.Loto.Shared;

namespace JpLoto.Lottery.Constants;

public static class ConversionActionType
{
    public const int TextToArray = 0;
    public const int ArrayToText = 1;
}

public static class ConversionResponseCode
{
    public const int Ok = 0;
    public const int DuplicateNumber = 1;
    public const int OutOfRange = 2;
    public const int MissingParameters = 3;
    public const int NumbersLenghtError = 4;
    public const int BonusLenghtError = 5;
    public const int BonusError = 6;
    public const int InputError = 7;

    public static string[] ErrorResource = {
        "cr_Ok",
        "cr_DuplicateNumberError",
        "cr_OutOfRangeError",
        "cr_MissingParametersError",
        "cr_InvalidNumbersLenght",
        "cr_InvalidBonusLenght",
        "cr_BonusError",
        "cr_InputError"
    };
}

public class ConversionResponse
{
    public int ActionType { get; set; } = -1; // No action yet
    public int ResponseCode { get; set; } = ConversionResponseCode.Ok;
    public string ErrorResource { get => ConversionResponseCode.ErrorResource[ResponseCode]; }
    public string NumbersText { get; set; } = string.Empty;
    public int[] NumbersVetor { get; set; } = Array.Empty<int>();
    public ConversionResponse() { }
    public ConversionResponse(string numbersTexto, int lotoType)
    {
        ActionType = ConversionActionType.TextToArray;
        ResponseCode = ConversionResponseCode.Ok;
        NumbersText = numbersTexto;
        NumbersVetor = LotoBase.TextToArray(numbersTexto);
    }
    public ConversionResponse(int[] numbersVetor, int lotoType)
    {
        ActionType = ConversionActionType.ArrayToText;
        ResponseCode = ConversionResponseCode.Ok;
        NumbersVetor = numbersVetor;
        NumbersText = LotoBase.ArrayToText(numbersVetor, lotoType);
    }
    public ConversionResponse(List<int> numbersList, int lotoType)
    {
        ActionType = ConversionActionType.ArrayToText;
        ResponseCode = ConversionResponseCode.Ok;
        NumbersVetor = numbersList.ToArray();
        NumbersText = LotoBase.ArrayToText(NumbersVetor, lotoType);
    }
}
