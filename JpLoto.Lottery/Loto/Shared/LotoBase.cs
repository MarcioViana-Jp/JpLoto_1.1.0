global using JpLoto.Lottery.Constants;
global using JpLoto.Lottery.Dto;
using System.Collections.ObjectModel;

namespace JpLoto.Lottery.Loto.Shared;

public abstract class LotoBase
{
    public int MaxNumber { get; set; } = 0;
    public int NumbersPerCard { get; set; } = 0;
    public int Loto_Type { get; set; } = -1;
    public int[] Numbers { get; set; } = Array.Empty<int>();
    public List<LotoNumber> ButtonNumbers { get; set; } = new();
    public void SetAsFree(int index) => SetStatus(index, Status.Free);
    public void SetAsSuggested(int index) => SetStatus(index, Status.Suggested);

    public int QuantityOfNumbers => ButtonNumbers.Count;
    public int QuantityOfFixedNumbers => ButtonNumbers.Count(bd => bd.Status == Status.Fixed);
    public int QuantityOfFreeNumbers => ButtonNumbers.Count(bd => bd.Status == Status.Free);
    public int QuantityOfSuggestedNumbers => ButtonNumbers.Count(bd => bd.Status == Status.Suggested);
    public int QuantityOfSelectedNumbers => ButtonNumbers.Count(bd => bd.Status == Status.Selected);
    public int QuantityOfBlockedNumbers => ButtonNumbers.Count(bd => bd.Status == Status.Blocked);

    public int[] FixedNumbers { get => GetNumbersByStatus(Status.Fixed); }
    public List<LotoNumber> ButtonFixedNumbers { get => GetButtonsByStatus(Status.Fixed); }
    public int[] FreeNumbers { get => GetNumbersByStatus(Status.Free); }
    public List<LotoNumber> ButtonFreeNumbers { get => GetButtonsByStatus(Status.Free); }
    public int[] SuggestedNumbers { get => GetNumbersByStatus(Status.Suggested); }
    public List<LotoNumber> ButtonSuggestedNumbers { get => GetButtonsByStatus(Status.Suggested); }
    public int[] SelectedNumbers { get => GetNumbersByStatus(Status.Selected); }
    public List<LotoNumber> ButtonSelectedNumbers { get => GetButtonsByStatus(Status.Selected); }
    public int[] BlockedNumbers { get => GetNumbersByStatus(Status.Blocked); }
    public List<LotoNumber> ButtonBlockedNumbers { get => GetButtonsByStatus(Status.Blocked); }

    public LotoFileInfo LotoFileInfo { get; set; }
    private readonly int[] _numbersPerCard = { 5, 6, 7 };
    private readonly int[] _maxNumber = { 31, 43, 37 };

    public LotoBase(int numbersPerCard, int maxNumber)
    {
        NumbersPerCard = numbersPerCard;
        MaxNumber = maxNumber;
        Loto_Type = LotoType.GetType(numbersPerCard);
        Initialize();
    }

    public LotoBase(int lotoType)
    {
        Loto_Type = lotoType;
        NumbersPerCard = _numbersPerCard[lotoType];
        MaxNumber = _maxNumber[lotoType];
        Initialize();
    }

    public void Initialize()
    {
        Numbers = new int[MaxNumber];
        ButtonNumbers = new();
        for (int i = 0; i < MaxNumber; i++)
        {
            Numbers[i] = Status.Free;
            ButtonNumbers.Add(new LotoNumber
            {
                Indice = i,
                Status = Status.Free,
                DynamicUrl = false
            });
        }
        LotoFileInfo = new LotoFileInfo(Loto_Type);
    }

    /*
     * NormatizeIndex always returns a normatized array of index (for Loto numbers)
     */
    private int[] NormatizedIndex(object numbers, int lotoType = LotoType.Undefined)
    {
        int[] _numbers;
        if (numbers.GetType().IsArray)
            _numbers = (int[])numbers;
        else
        {
            try
                { _numbers = TextToArray((string)numbers, lotoType); }
            catch (Exception ex)  
                { _numbers = new int[0]; }
        }
        return _numbers;
    }

    public void SelectNumbers(object numbers, int lotoType = LotoType.Undefined)
    {
        int[] _numbers = NormatizedIndex(numbers, lotoType);
        for (int i = 0; i < _numbers.Length; i++)
            SetAsSelected(_numbers[i]);
    }

    public void FixNumbers(object numbers, int lotoType = LotoType.Undefined)
    {
        int[] _numbers = NormatizedIndex(numbers, lotoType);
        for (int i = 0; i < _numbers.Length; i++)
            SetAsFixed(_numbers[i]);
    }

    public void SetAsSelected(int index)
    {
        if (Numbers[index] == Status.Selected || Numbers[index] == Status.Fixed)
            SetAsFree(index);
        else
            SetStatus(index, Status.Selected);
    }

    public void SetAsFixed(int index)
    {
        if (QuantityOfFixedNumbers < NumbersPerCard - 1)
            SetStatus(index, Status.Fixed);
    }

    public void ReleaseFixedNumbers()
    {
        for (int i = 0; i < Numbers.Length; i++)
        {
            if (Numbers[i] == Status.Fixed)
                SetAsFree(i);
        }
    }

    public void ReleaseSuggestedNumbers()
    {
        for (int i = 0; i < Numbers.Length; i++)
        {
            if (Numbers[i] == Status.Suggested)
                SetAsFree(i);
        }
    }

    public void ReleaseSelectedNumbers()
    {
        for (int i = 0; i < Numbers.Length; i++)
        {
            if (Numbers[i] == Status.Selected)
                SetAsFree(i);
        }
    }

    public void ReleaseAll()
    {
        ReleaseSuggestedNumbers();
        ReleaseSelectedNumbers();
        ReleaseFixedNumbers();
        //DesmarcaBlockedNumbers();
    }

    public void RefreshSelectedNumbers(int variableNumbers)
    {
        var totalSelected = QuantityOfSelectedNumbers;
        if (totalSelected > variableNumbers)
        {
            var botoesParaLiberar = ButtonSelectedNumbers.GetRange(variableNumbers, totalSelected - variableNumbers);
            foreach (var botao in botoesParaLiberar)
            {
                SetStatus(botao.Indice, Status.Free);
            }
        }
    }

    public void SetStatus(int index, int status)
    {
        Numbers[index] = status;
        ButtonNumbers[index].Status = status;
    }

    public long GetCombinationCount()
    {
        long quantidade = Factorial(QuantityOfSelectedNumbers, NumbersPerCard - QuantityOfFixedNumbers) / Factorial(NumbersPerCard - QuantityOfFixedNumbers);
        return quantidade;
    }

    private static long Factorial(int num, int baseFactorial)
    {
        if (num <= 0) num *= -1;  // Prevent negative numbers
        long fatorial = num;
        int numBase;
        for (int i = 1; i < baseFactorial; i++)
        {
            numBase = num - i;
            fatorial *= numBase;
        }
        return fatorial;
    }

    private static long Factorial(int num)
    {
        try
        {
            if (num <= 0) num *= -1;  // Prevent negative numbers

            if (num == 1)
            {
                return 1;
            }
            else
            {
                return num * Factorial(num - 1);
            }
        }
        catch
        {
            return -1;
        }
    }

    public int[] GetNumbersByStatus(int status)
    {
        List<int> temp = new();
        for (int i = 0; i < Numbers.Length; i++)
        {
            if (Numbers[i] == status)
                temp.Insert(temp.Count, i);
        }
        return temp.ToArray();
    }

    public List<LotoNumber> GetButtonsByStatus(int status)
    {
        List<LotoNumber> temp = new();
        for (int i = 0; i < Numbers.Length; i++)
        {
            if (ButtonNumbers[i].Status == status)
                temp.Insert(temp.Count, ButtonNumbers[i]);
        }
        return temp;
    }

    public void CreateSuggestions(int variableNumbers)
    {
        if (QuantityOfSelectedNumbers == variableNumbers)
            return;

        ReleaseSuggestedNumbers();
        int[] _numbersLivres = FreeNumbers;
        int[] _numbersSugeridas;

        // Sugere/completa lista de numbers variaveis ate o limite especificado pelo parametro 'variableNumbers'
        int quantityOfSuggestions = variableNumbers - SelectedNumbers.Length;

        Random indexRandom = new();
        ObservableCollection<int> indexsRandomicos = new();
        int indTmp;
        int iSugestao = 0;

        _numbersSugeridas = new int[quantityOfSuggestions];

        while (iSugestao < quantityOfSuggestions)
        {
            indTmp = Convert.ToInt16(indexRandom.Next(0, QuantityOfFreeNumbers));

            if (indexsRandomicos.IndexOf(indTmp) == -1)    // Elimina redundancias
            {
                indexsRandomicos.Add(indTmp);
                SetAsSuggested(_numbersLivres[indTmp]);
                _numbersSugeridas[iSugestao] = _numbersLivres[indTmp];   // Salva index da number sugerida
                iSugestao++;
            }
        }

    }

    public void ApplySuggestions()
    {
        var _numbersSugeridas = SuggestedNumbers;
        for (int i = 0; i < _numbersSugeridas.Length; i++)
        {
            SetAsSelected(_numbersSugeridas[i]);
        }
    }

    /*
     * TextToArray always returns the index, not the actual number.
     */
    public static int[] TextToArray(string text, int lotoType, bool isBonus = false, string separador = ",")
    {
        if (string.IsNullOrEmpty(text))
            return new int[0];

        string[] cardsTxt = text.Split(separador);
        int maxNumber = 0; 

        if(lotoType != LotoType.Undefined)
        {
            maxNumber = LotoType.MaxNumber(lotoType);
            if ((!isBonus && cardsTxt.Length != LotoType.NumbersPerCard(lotoType)) ||
                 (isBonus && cardsTxt.Length != LotoType.QuantityOfBonus(lotoType)))
                return new int[0];
        }

        List<int> cardNumbers = new();
        int number;

        bool hasOutOfRangeNumber = false;
        for (int i = 0; i < cardsTxt.Length; i++)
        {
            if (int.TryParse(cardsTxt[i], out number))
            {            
                if(lotoType == LotoType.Undefined || (number > 0 && number <= maxNumber))
                {
                    cardNumbers.Add(number - 1);
                }
                else
                {
                    hasOutOfRangeNumber = true;
                }
            }
        }
        if (hasOutOfRangeNumber)
            return new int[0];

        cardNumbers.Sort();
        return cardNumbers.ToArray();
    }
    
    /*
     * ArrayToText always returns the actual number, not the index.
     */
    public static string ArrayToText(int[] cards, int lotoType, string separador = ",")
    {
        if (cards.Length == 0)
            return string.Empty;

        string _separador = string.Empty;
        string cardsTxt = string.Empty;
        for (int i = 0; i < cards.Length; i++)
        {
            if(lotoType == LotoType.Undefined ||
              (cards[i] >= 0 && cards[i] < LotoType.MaxNumber(lotoType)))            
            {
                cardsTxt += _separador + (cards[i] + 1).ToString("00");
                _separador = separador;
            }
        }
        return cardsTxt;
    }

    public static int CommonNumbers(int[] first, int[] second)
    {
        int count = 0;
        for(int fst = 0; fst < first.Length; fst++)
        {
            for (int snd = 0; snd < second.Length; snd++)
            {
                if (first[fst] == second[snd])
                    count++;
            }
        }
        return count;
    }
}
