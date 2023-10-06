using JpLoto.Domain.Entities;
using JpLoto.Globalization.Localization;
using JpLoto.Globalization.Resources;
using JpLoto.Lottery.Loto.Shared;

namespace JpLoto.Lottery.Loto;

public class MiniLoto : LotoBase
{
    private List<string> _combinations = new();
    public List<Card>? Combinations { get; set; }
    private readonly CommonLocalizationService _lotoLocalizer;

    public MiniLoto() : base(LotoType.MiniLoto) { }

    public MiniLoto(CommonLocalizationService authLocalizer) : base(LotoType.MiniLoto)
    {
        _lotoLocalizer = authLocalizer;
        _lotoLocalizer.SetResource(typeof(LotoResource), nameof(LotoResource));
    }

    public LotoResponse CreateCombinations(int quantidadeLimite, bool mantemAnteriores = true, bool combinacoesAleatorias = false)
    {
        int qtdNiveis = NumbersPerCard - QuantityOfFixedNumbers;

        int quantidadeLimiteCalculada = (int)GetCombinationCount();

        if (quantidadeLimite < 1 || quantidadeLimite > quantidadeLimiteCalculada)
            return new LotoResponse
            {
                Success = false,
                Message = _lotoLocalizer.Get("Error_InvalidMaxCombinations") //"Erro na quantidade máxima de combinações informada."
            };

        int[] _fixedNumbers = new int[FixedNumbers.Length];
        for (int i = 0; i < FixedNumbers.Length; i++)
            _fixedNumbers[i] = FixedNumbers[i] + 1;

        int[] _selectedNumbers = SelectedNumbers;

        // Ordena arrays das numbers selecionadas e fixas
        Array.Sort(_selectedNumbers);
        Array.Sort(_fixedNumbers);

        int[] cardTemp;
        List<string> cardsTemp = new();

        if (qtdNiveis == 1)         // Nivel 1: 4 numbers fixas
        {
            for (int a = 0; a <= (QuantityOfSelectedNumbers - qtdNiveis); a++)
            {
                cardTemp = new int[NumbersPerCard];
                cardTemp[0] = _fixedNumbers[0];
                cardTemp[1] = _fixedNumbers[1];
                cardTemp[2] = _fixedNumbers[2];
                cardTemp[3] = _fixedNumbers[3];
                cardTemp[4] = _selectedNumbers[a];
                Array.Sort(cardTemp);
                cardsTemp.Add(ArrayToText(cardTemp, LotoType.MiniLoto));
            }
        }
        else if (qtdNiveis == 2)    // Nivel 2: 3 numbers fixas
        {
            for (int a = 0; a <= (QuantityOfSelectedNumbers - qtdNiveis); a++)
            {
                for (int b = a + 1; b <= (QuantityOfSelectedNumbers - qtdNiveis + 1); b++)
                {
                    cardTemp = new int[NumbersPerCard];
                    cardTemp[0] = _fixedNumbers[0];
                    cardTemp[1] = _fixedNumbers[1];
                    cardTemp[2] = _fixedNumbers[2];
                    cardTemp[3] = _selectedNumbers[a];
                    cardTemp[4] = _selectedNumbers[b];
                    Array.Sort(cardTemp);
                    cardsTemp.Add(ArrayToText(cardTemp, LotoType.MiniLoto));
                }
            }
        }
        else if (qtdNiveis == 3)    // Nivel 3: 2 numbers fixas
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
                        cardTemp[2] = _selectedNumbers[a];
                        cardTemp[3] = _selectedNumbers[b];
                        cardTemp[4] = _selectedNumbers[c];
                        Array.Sort(cardTemp);
                        cardsTemp.Add(ArrayToText(cardTemp, LotoType.MiniLoto));
                    }
                }
            }
        }
        else if (qtdNiveis == 4)    // Nivel 4: 1 number fixas
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
                            cardTemp[1] = _selectedNumbers[a];
                            cardTemp[2] = _selectedNumbers[b];
                            cardTemp[3] = _selectedNumbers[c];
                            cardTemp[4] = _selectedNumbers[d];
                            Array.Sort(cardTemp);
                            cardsTemp.Add(ArrayToText(cardTemp, LotoType.MiniLoto));
                        }
                    }
                }
            }
        }
        else    // Nivel 5: nenhuma number fixa
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
                                cardTemp[0] = _selectedNumbers[a];
                                cardTemp[1] = _selectedNumbers[b];
                                cardTemp[2] = _selectedNumbers[c];
                                cardTemp[3] = _selectedNumbers[d];
                                cardTemp[4] = _selectedNumbers[e];
                                Array.Sort(cardTemp);
                                cardsTemp.Add(ArrayToText(cardTemp, LotoType.MiniLoto));
                            }
                        }
                    }
                }
            }
        }

        int idSequencial = 1;   // Novo index de cards usado quando ha necessidade de reordenamento.
                                // Ex: manter cards anteriores ou gerar combinacoes aleatorias

        if (combinacoesAleatorias)
        {
            int i = 0;
            int ii;
            List<string> cardsAleatorios = new();
            List<int> indexs = new();
            Random indexRandomico = new();
            while (i < quantidadeLimite)
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
            for (int i = 0; i < quantidadeLimite; i++)
            {
                cardsSelecionados.Add(cardsTemp[i]);
            }
            cardsTemp = cardsSelecionados;
        }

        // Mantem combinacoes anteriores, caso selecionado
        if (mantemAnteriores)
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

    public ResultResponse<MiniLotoResult, MiniLotoPrize> CheckResults(MiniLotoResult result)
    {
        MiniLotoPrize prizes = new();
        ResultResponse<MiniLotoResult, MiniLotoPrize> response = new();
        if (Combinations is null || Combinations.Count == 0)
            return response;

        var drawnNumbers = TextToArray(result.Numbers, Loto_Type);
        var drawnBonus = TextToArray(result.Bonus, Loto_Type, true);
        int commonNumbers, commonBonus;
        try
        {
            foreach (var card in Combinations)
            {
                commonNumbers = CommonNumbers(card.Numbers(Loto_Type), drawnNumbers);
                commonBonus = CommonNumbers(card.Numbers(Loto_Type), drawnBonus);
                if (commonNumbers == 5)
                {
                    prizes.WinningCards1.Insert(prizes.WinningCards1.Count, new MiniLotoPrize.Prize
                    {
                        Card = card,
                        CardPosition = $"{card.Id}/{Combinations.Count}"
                    });
                }
                else if (commonNumbers == 4 && commonBonus > 0)
                {
                    prizes.WinningCards2.Insert(prizes.WinningCards2.Count, new MiniLotoPrize.Prize
                    {
                        Card = card,
                        CardPosition = $"{card.Id}/{Combinations.Count}"
                    });
                }
                else if (commonNumbers == 4)
                {
                    prizes.WinningCards3.Insert(prizes.WinningCards3.Count, new MiniLotoPrize.Prize
                    {
                        Card = card,
                        CardPosition = $"{card.Id}/{Combinations.Count}"
                    });
                }
                else if (commonNumbers == 3)
                {
                    prizes.WinningCards4.Insert(prizes.WinningCards4.Count, new MiniLotoPrize.Prize
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
