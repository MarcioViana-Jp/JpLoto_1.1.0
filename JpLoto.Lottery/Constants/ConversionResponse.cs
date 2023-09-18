using JpLoto.Lottery.Shared;

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
    public string DezenasTexto { get; set; } = string.Empty;
    public int[] DezenasVetor { get; set; } = Array.Empty<int>();
    public ConversionResponse() { }
    public ConversionResponse(string dezenasTexto, int tipoLoto)
    {
        ActionType = ConversionActionType.TextToArray;
        ResponseCode = ConversionResponseCode.Ok;
        DezenasTexto = dezenasTexto;
        DezenasVetor = LotoBase.TextoParaVetor(dezenasTexto, tipoLoto).DezenasVetor;
    }
    public ConversionResponse(int[] dezenasVetor, int tipoLoto)
    {
        ActionType = ConversionActionType.ArrayToText;
        ResponseCode = ConversionResponseCode.Ok;
        DezenasVetor = dezenasVetor;
        DezenasTexto = LotoBase.VetorParaTexto(dezenasVetor, tipoLoto);
    }
}
