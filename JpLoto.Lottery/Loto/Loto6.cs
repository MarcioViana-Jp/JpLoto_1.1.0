using JpLoto.Domain.Entities;
using JpLoto.Globalization.Localization;
using JpLoto.Globalization.Resources;
using JpLoto.Lottery.Loto.Shared;

namespace JpLoto.Lottery.Loto;

public class Loto6 : LotoBase
{
    private List<string> _combinations = new();
    public List<Card>? Combinations { get; set; }
    private readonly CommonLocalizationService _lotoLocalizer;

    public Loto6() : base(LotoType.Loto6) { }

    public Loto6(CommonLocalizationService authLocalizer) : base(LotoType.Loto6)
    {
        _lotoLocalizer = authLocalizer;
        _lotoLocalizer.SetResource(typeof(LotoResource), nameof(LotoResource));
    }

    public LotoResponse CreateCombinations(int givenLimit, bool keepPrevious = true, bool aleatoryCombinations = false)
    {
        int qtdNiveis = NumbersPerCard - QuantityOfFixedNumbers;

        int calculatedLimit = (int)GetCombinationCount();

        if (givenLimit < 1 || givenLimit > calculatedLimit)
            return new LotoResponse
            {
                Success = false,
                Message = _lotoLocalizer.Get("Error_InvalidMaxCombinations")
            };

        int[] _fixedNumbers = new int[FixedNumbers.Length];
        for(int i = 0; i < FixedNumbers.Length; i++)
            _fixedNumbers[i] = FixedNumbers[i] + 1;
        
        int[] _selectedNumbers = new int[SelectedNumbers.Length];
        for (int i = 0; i < SelectedNumbers.Length; i++)
            _selectedNumbers[i] = SelectedNumbers[i] + 1;

        // Ordena arrays das numbers selecionadas e fixas
        Array.Sort(_selectedNumbers);
        Array.Sort(_fixedNumbers);

        int[] cardTemp;
        List<string> cardsTemp = new();

        if (qtdNiveis == 1)         // Nivel 1: 5 numbers fixas
        {
            for (int a = 0; a <= (QuantityOfSelectedNumbers - qtdNiveis); a++)
            {
                cardTemp = new int[NumbersPerCard];
                cardTemp[0] = _fixedNumbers[0];
                cardTemp[1] = _fixedNumbers[1];
                cardTemp[2] = _fixedNumbers[2];
                cardTemp[3] = _fixedNumbers[3];
                cardTemp[4] = _fixedNumbers[4];
                cardTemp[5] = _selectedNumbers[a];
                Array.Sort(cardTemp);
                cardsTemp.Add(ArrayToText(cardTemp, LotoType.Loto6));
            }
        }
        else if (qtdNiveis == 2)    // Nivel 2: 4 numbers fixas
        {
            for (int a = 0; a <= (QuantityOfSelectedNumbers - qtdNiveis); a++)
            {
                for (int b = a + 1; b <= (QuantityOfSelectedNumbers - qtdNiveis + 1); b++)
                {
                    cardTemp = new int[NumbersPerCard];
                    cardTemp[0] = _fixedNumbers[0];
                    cardTemp[1] = _fixedNumbers[1];
                    cardTemp[2] = _fixedNumbers[2];
                    cardTemp[3] = _fixedNumbers[3];
                    cardTemp[4] = _selectedNumbers[a];
                    cardTemp[5] = _selectedNumbers[b];
                    Array.Sort(cardTemp);
                    cardsTemp.Add(ArrayToText(cardTemp, LotoType.Loto6));
                }
            }
        }
        else if (qtdNiveis == 3)    // Nivel 3: 3 numbers fixas
        {
            for (int a = 0; a <= (QuantityOfSelectedNumbers - qtdNiveis); a++)
            {
                for (int b = a + 1; b <= (QuantityOfSelectedNumbers - qtdNiveis + 1); b++)
                {
                    for (int c = b + 1; c <= (QuantityOfSelectedNumbers - qtdNiveis + 2); c++)
                    {
                        cardTemp = new int[NumbersPerCard];
                        cardTemp[0] = _fixedNumbers[0];
                        cardTemp[1] = _fixedNumbers[1];
                        cardTemp[2] = _fixedNumbers[2];
                        cardTemp[3] = _selectedNumbers[a];
                        cardTemp[4] = _selectedNumbers[b];
                        cardTemp[5] = _selectedNumbers[c];
                        Array.Sort(cardTemp);
                        cardsTemp.Add(ArrayToText(cardTemp, LotoType.Loto6));
                    }
                }
            }
        }
        else if (qtdNiveis == 4)    // Nivel 4: 2 numbers fixas
        {
            for (int a = 0; a <= (QuantityOfSelectedNumbers - qtdNiveis); a++)
            {
                for (int b = a + 1; b <= (QuantityOfSelectedNumbers - qtdNiveis + 1); b++)
                {
                    for (int c = b + 1; c <= (QuantityOfSelectedNumbers - qtdNiveis + 2); c++)
                    {
                        for (int d = c + 1; d <= (QuantityOfSelectedNumbers - qtdNiveis + 3); d++)
                        {
                            cardTemp = new int[NumbersPerCard];
                            cardTemp[0] = _fixedNumbers[0];
                            cardTemp[1] = _fixedNumbers[1];
                            cardTemp[2] = _selectedNumbers[a];
                            cardTemp[3] = _selectedNumbers[b];
                            cardTemp[4] = _selectedNumbers[c];
                            cardTemp[5] = _selectedNumbers[d];
                            Array.Sort(cardTemp);
                            cardsTemp.Add(ArrayToText(cardTemp, LotoType.Loto6));
                        }
                    }
                }
            }
        }
        else if (qtdNiveis == 5)    // Nivel 5: 1 number fixa
        {
            for (int a = 0; a <= (QuantityOfSelectedNumbers - qtdNiveis); a++)
            {
                for (int b = a + 1; b <= (QuantityOfSelectedNumbers - qtdNiveis + 1); b++)
                {
                    for (int c = b + 1; c <= (QuantityOfSelectedNumbers - qtdNiveis + 2); c++)
                    {
                        for (int d = c + 1; d <= (QuantityOfSelectedNumbers - qtdNiveis + 3); d++)
                        {
                            for (int e = d + 1; e <= (QuantityOfSelectedNumbers - qtdNiveis + 4); e++)
                            {
                                cardTemp = new int[NumbersPerCard];
                                cardTemp[0] = _fixedNumbers[0];
                                cardTemp[1] = _selectedNumbers[a];
                                cardTemp[2] = _selectedNumbers[b];
                                cardTemp[3] = _selectedNumbers[c];
                                cardTemp[4] = _selectedNumbers[d];
                                cardTemp[5] = _selectedNumbers[e];
                                Array.Sort(cardTemp);
                                cardsTemp.Add(ArrayToText(cardTemp, LotoType.Loto6));
                            }
                        }
                    }
                }
            }
        }
        else    // Nivel 6: nenhuma number fixa
        {
            for (int a = 0; a <= (QuantityOfSelectedNumbers - qtdNiveis); a++)
            {
                for (int b = a + 1; b <= (QuantityOfSelectedNumbers - qtdNiveis + 1); b++)
                {
                    for (int c = b + 1; c <= (QuantityOfSelectedNumbers - qtdNiveis + 2); c++)
                    {
                        for (int d = c + 1; d <= (QuantityOfSelectedNumbers - qtdNiveis + 3); d++)
                        {
                            for (int e = d + 1; e <= (QuantityOfSelectedNumbers - qtdNiveis + 4); e++)
                            {
                                for (int f = e + 1; f <= (QuantityOfSelectedNumbers - qtdNiveis + 5); f++)
                                {
                                    cardTemp = new int[NumbersPerCard];
                                    cardTemp[0] = _selectedNumbers[a];
                                    cardTemp[1] = _selectedNumbers[b];
                                    cardTemp[2] = _selectedNumbers[c];
                                    cardTemp[3] = _selectedNumbers[d];
                                    cardTemp[4] = _selectedNumbers[e];
                                    cardTemp[5] = _selectedNumbers[f];
                                    Array.Sort(cardTemp);
                                    cardsTemp.Add(ArrayToText(cardTemp, LotoType.Loto6));
                                }
                            }
                        }
                    }
                }
            }
        }

        int idSequencial = 1;   // Novo index de cards usado quando ha necessidade de reordenamento.
                                // Ex: manter cards anteriores ou gerar combinacoes aleatorias

        if (aleatoryCombinations)
        {
            int i = 0;
            int ii;
            List<string> cardsAleatorios = new();
            List<int> indexs = new();
            Random indexRandomico = new();
            while (i < givenLimit)
            {
                ii = Convert.ToInt32(indexRandomico.Next(0, cardsTemp.Count));

                if (indexs.IndexOf(ii) == -1)  // Elimina redundancias
                {
                    indexs.Add(ii);
                    cardsAleatorios.Add(cardsTemp[ii]);
                    i++;
                    idSequencial++;
                }
            }
            cardsTemp = cardsAleatorios;
        }
        else
        {   // Copia os cards gerados ate o limite especificado             
            List<string> cardsSelecionados = new();
            for (int i = 0; i < givenLimit; i++)
            {
                cardsSelecionados.Add(cardsTemp[i]);
            }
            cardsTemp = cardsSelecionados;
        }

        // Mantem combinacoes anteriores, caso selecionado
        if (keepPrevious)
        {
            idSequencial = _combinations.Count;
            for (int i = 0; i < cardsTemp.Count; i++)
            {
                idSequencial++; // continua Id (sequencia) a partir do id do ultimo card.

                _combinations.Add(cardsTemp[i]);
            }
        }
        else
        {
            _combinations = cardsTemp;
        }

        List<Card> combinacoesFinais = new();
        for (int i = 0; i < _combinations.Count; i++)
        {
            combinacoesFinais.Add(new Card
            {
                Id = i + 1,
                NumbersText = _combinations[i]
            });
        }

        Combinations = combinacoesFinais;

        return new LotoResponse
        {
            Success = _combinations.Count > 0,
            Message = _combinations.Count > 0 ? $"{_combinations.Count} combinações geradas." : "Nenhuma combinação foi gerada.",
            Combinations = Combinations
        };
    }

    public void ClearCombinations()
    {
        _combinations = new();
    }

    public ResultResponse<Loto6Result, Loto6Prize> CheckResults(Loto6Result result)
    {
        Loto6Prize prizes = new();
        ResultResponse<Loto6Result, Loto6Prize> response = new();
        if (Combinations is null || Combinations.Count == 0)
            return response;

        var drawnNumbers = TextToArray(result.Numbers);
        var drawnBonus = TextToArray(result.Bonus, true);
        int commonNumbers, commonBonus;
        try
        {
            foreach (var card in Combinations)
            {
                commonNumbers = CommonNumbers(card.Numbers, drawnNumbers);
                commonBonus = CommonNumbers(card.Numbers, drawnBonus);
                if (commonNumbers == 6)
                {
                    prizes.WinningCards1.Insert(prizes.WinningCards1.Count, new Loto6Prize.Prize
                    {
                        Card = card,
                        CardPosition = $"{card.Id}/{Combinations.Count}"
                    });
                }
                else if (commonNumbers == 5 && commonBonus > 0)
                {
                    prizes.WinningCards2.Insert(prizes.WinningCards2.Count, new Loto6Prize.Prize
                    {
                        Card = card,
                        CardPosition = $"{card.Id}/{Combinations.Count}"
                    });
                }
                else if (commonNumbers == 5)
                {
                    prizes.WinningCards3.Insert(prizes.WinningCards3.Count, new Loto6Prize.Prize
                    {
                        Card = card,
                        CardPosition = $"{card.Id}/{Combinations.Count}"
                    });
                }
                else if (commonNumbers == 4)
                {
                    prizes.WinningCards4.Insert(prizes.WinningCards4.Count, new Loto6Prize.Prize
                    {
                        Card = card,
                        CardPosition = $"{card.Id}/{Combinations.Count}"
                    });
                }
                else if (commonNumbers == 3)
                {
                    prizes.WinningCards5.Insert(prizes.WinningCards5.Count, new Loto6Prize.Prize
                    {
                        Card = card,
                        CardPosition = $"{card.Id}/{Combinations.Count}"
                    });
                }
            }
            response.Result = result;
            response.Prizes = prizes;
        }
        catch (Exception ex)
        {
            response.Errors.Add(ex.Message);
        }
        return response;
    }

}
