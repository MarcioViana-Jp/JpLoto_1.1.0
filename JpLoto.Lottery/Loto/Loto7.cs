using JpLoto.Globalization.Localization;
using JpLoto.Globalization.Resources;
using JpLoto.Lottery.Dto;
using JpLoto.Lottery.Shared;

namespace JpLoto.Lottery.Loto;

public class Loto7 : LotoBase
{
    private List<string> _combinacoes = new();
    public List<Jogo>? Combinacoes { get; set; }
    private readonly CommonLocalizationService _lotoLocalizer;

    public Loto7() : base(LotoType.Loto7) { }

    public Loto7(CommonLocalizationService authLocalizer) : base(LotoType.Loto7)
    {
        _lotoLocalizer = authLocalizer;
        _lotoLocalizer.SetResource(typeof(LotoResource), nameof(LotoResource));
    }

    public LotoResponse GeraCombinacoes(int quantidadeLimite, bool mantemAnteriores = true, bool combinacoesAleatorias = false)
    {
        int qtdNiveis = DezenasPorJogo - QuantidadeDezenasFixas;

        int quantidadeLimiteCalculada = (int)ObtemQuantidadeDeCombinacoes();

        if (quantidadeLimite < 1 || quantidadeLimite > quantidadeLimiteCalculada)
            return new LotoResponse
            {
                Successo = false,
                Mensagem = _lotoLocalizer.Get("Error_InvalidMaxCombinations") //"Erro na quantidade máxima de combinações informada."
            };

        int[] _dezenasFixas = DezenasFixas;
        int[] _dezenasSelecionadas = DezenasSelecionadas;

        // Ordena arrays das dezenas selecionadas e fixas
        Array.Sort(_dezenasSelecionadas);
        Array.Sort(_dezenasFixas);

        int[] jogoTemp;
        List<string> jogosTemp = new();

        if (qtdNiveis == 1)         // Nivel 1: 6 dezenas fixas
        {
            for (int a = 0; a <= (QuantidadeDezenasSelecionadas - qtdNiveis); a++)
            {
                jogoTemp = new int[DezenasPorJogo];
                jogoTemp[0] = _dezenasFixas[0];
                jogoTemp[1] = _dezenasFixas[1];
                jogoTemp[2] = _dezenasFixas[2];
                jogoTemp[3] = _dezenasFixas[3];
                jogoTemp[4] = _dezenasFixas[4];
                jogoTemp[5] = _dezenasFixas[5];
                jogoTemp[6] = _dezenasSelecionadas[a];
                Array.Sort(jogoTemp);
                jogosTemp.Add(VetorParaTexto(jogoTemp, LotoType.Loto7));
            }
        }
        else if (qtdNiveis == 2)    // Nivel 2: 5 dezenas fixas
        {
            for (int a = 0; a <= (QuantidadeDezenasSelecionadas - qtdNiveis); a++)
            {
                for (int b = a + 1; b <= (QuantidadeDezenasSelecionadas - qtdNiveis + 1); b++)
                {
                    jogoTemp = new int[DezenasPorJogo];
                    jogoTemp[0] = _dezenasFixas[0];
                    jogoTemp[1] = _dezenasFixas[1];
                    jogoTemp[2] = _dezenasFixas[2];
                    jogoTemp[3] = _dezenasFixas[3];
                    jogoTemp[4] = _dezenasFixas[4];
                    jogoTemp[5] = _dezenasSelecionadas[a];
                    jogoTemp[6] = _dezenasSelecionadas[b];
                    Array.Sort(jogoTemp);
                    jogosTemp.Add(VetorParaTexto(jogoTemp, LotoType.Loto7));
                }
            }
        }
        else if (qtdNiveis == 3)    // Nivel 3: 4 dezenas fixas
        {
            for (int a = 0; a <= (QuantidadeDezenasSelecionadas - qtdNiveis); a++)
            {
                for (int b = a + 1; b <= (QuantidadeDezenasSelecionadas - qtdNiveis + 1); b++)
                {
                    for (int c = b + 1; c <= (QuantidadeDezenasSelecionadas - qtdNiveis + 2); c++)
                    {
                        jogoTemp = new int[DezenasPorJogo];
                        jogoTemp[0] = _dezenasFixas[0];
                        jogoTemp[1] = _dezenasFixas[1];
                        jogoTemp[2] = _dezenasFixas[2];
                        jogoTemp[3] = _dezenasFixas[3];
                        jogoTemp[4] = _dezenasSelecionadas[a];
                        jogoTemp[5] = _dezenasSelecionadas[b];
                        jogoTemp[6] = _dezenasSelecionadas[c];
                        Array.Sort(jogoTemp);
                        jogosTemp.Add(VetorParaTexto(jogoTemp, LotoType.Loto7));
                    }
                }
            }
        }
        else if (qtdNiveis == 4)    // Nivel 4: 3 dezenas fixas
        {
            for (int a = 0; a <= (QuantidadeDezenasSelecionadas - qtdNiveis); a++)
            {
                for (int b = a + 1; b <= (QuantidadeDezenasSelecionadas - qtdNiveis + 1); b++)
                {
                    for (int c = b + 1; c <= (QuantidadeDezenasSelecionadas - qtdNiveis + 2); c++)
                    {
                        for (int d = c + 1; d <= (QuantidadeDezenasSelecionadas - qtdNiveis + 3); d++)
                        {
                            jogoTemp = new int[DezenasPorJogo];
                            jogoTemp[0] = _dezenasFixas[0];
                            jogoTemp[1] = _dezenasFixas[1];
                            jogoTemp[2] = _dezenasFixas[2];
                            jogoTemp[3] = _dezenasSelecionadas[a];
                            jogoTemp[4] = _dezenasSelecionadas[b];
                            jogoTemp[5] = _dezenasSelecionadas[c];
                            jogoTemp[6] = _dezenasSelecionadas[d];
                            Array.Sort(jogoTemp);
                            jogosTemp.Add(VetorParaTexto(jogoTemp, LotoType.Loto7));
                        }
                    }
                }
            }
        }
        else if (qtdNiveis == 5)    // Nivel 5: 2 dezenas fixas
        {
            for (int a = 0; a <= (QuantidadeDezenasSelecionadas - qtdNiveis); a++)
            {
                for (int b = a + 1; b <= (QuantidadeDezenasSelecionadas - qtdNiveis + 1); b++)
                {
                    for (int c = b + 1; c <= (QuantidadeDezenasSelecionadas - qtdNiveis + 2); c++)
                    {
                        for (int d = c + 1; d <= (QuantidadeDezenasSelecionadas - qtdNiveis + 3); d++)
                        {
                            for (int e = d + 1; e <= (QuantidadeDezenasSelecionadas - qtdNiveis + 4); e++)
                            {
                                jogoTemp = new int[DezenasPorJogo];
                                jogoTemp[0] = _dezenasFixas[0];
                                jogoTemp[1] = _dezenasFixas[1];
                                jogoTemp[2] = _dezenasSelecionadas[a];
                                jogoTemp[3] = _dezenasSelecionadas[b];
                                jogoTemp[4] = _dezenasSelecionadas[c];
                                jogoTemp[5] = _dezenasSelecionadas[d];
                                jogoTemp[6] = _dezenasSelecionadas[e];
                                Array.Sort(jogoTemp);
                                jogosTemp.Add(VetorParaTexto(jogoTemp, LotoType.Loto7));
                            }
                        }
                    }
                }
            }
        }
        else if (qtdNiveis == 6)    // Nivel 6: 1 dezena fixa
        {
            for (int a = 0; a <= (QuantidadeDezenasSelecionadas - qtdNiveis); a++)
            {
                for (int b = a + 1; b <= (QuantidadeDezenasSelecionadas - qtdNiveis + 1); b++)
                {
                    for (int c = b + 1; c <= (QuantidadeDezenasSelecionadas - qtdNiveis + 2); c++)
                    {
                        for (int d = c + 1; d <= (QuantidadeDezenasSelecionadas - qtdNiveis + 3); d++)
                        {
                            for (int e = d + 1; e <= (QuantidadeDezenasSelecionadas - qtdNiveis + 4); e++)
                            {
                                for (int f = e + 1; f <= (QuantidadeDezenasSelecionadas - qtdNiveis + 5); f++)
                                {
                                    jogoTemp = new int[DezenasPorJogo];
                                    jogoTemp[0] = _dezenasFixas[0];
                                    jogoTemp[1] = _dezenasSelecionadas[a];
                                    jogoTemp[2] = _dezenasSelecionadas[b];
                                    jogoTemp[3] = _dezenasSelecionadas[c];
                                    jogoTemp[4] = _dezenasSelecionadas[d];
                                    jogoTemp[5] = _dezenasSelecionadas[e];
                                    jogoTemp[6] = _dezenasSelecionadas[f];
                                    Array.Sort(jogoTemp);
                                    jogosTemp.Add(VetorParaTexto(jogoTemp, LotoType.Loto7));
                                }
                            }
                        }
                    }
                }
            }
        }
        else    // Nivel 7: nenhuma dezena fixa
        {
            for (int a = 0; a <= (QuantidadeDezenasSelecionadas - qtdNiveis); a++)
            {
                for (int b = a + 1; b <= (QuantidadeDezenasSelecionadas - qtdNiveis + 1); b++)
                {
                    for (int c = b + 1; c <= (QuantidadeDezenasSelecionadas - qtdNiveis + 2); c++)
                    {
                        for (int d = c + 1; d <= (QuantidadeDezenasSelecionadas - qtdNiveis + 3); d++)
                        {
                            for (int e = d + 1; e <= (QuantidadeDezenasSelecionadas - qtdNiveis + 4); e++)
                            {
                                for (int f = e + 1; f <= (QuantidadeDezenasSelecionadas - qtdNiveis + 5); f++)
                                {
                                    for (int g = f + 1; g <= (QuantidadeDezenasSelecionadas - qtdNiveis + 6); g++)
                                    {
                                        jogoTemp = new int[DezenasPorJogo];
                                        jogoTemp[0] = _dezenasSelecionadas[a];
                                        jogoTemp[1] = _dezenasSelecionadas[b];
                                        jogoTemp[2] = _dezenasSelecionadas[c];
                                        jogoTemp[3] = _dezenasSelecionadas[d];
                                        jogoTemp[4] = _dezenasSelecionadas[e];
                                        jogoTemp[5] = _dezenasSelecionadas[f];
                                        jogoTemp[6] = _dezenasSelecionadas[g];
                                        Array.Sort(jogoTemp);
                                        jogosTemp.Add(VetorParaTexto(jogoTemp, LotoType.Loto7));
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        int idSequencial = 1;   // Novo indice de jogos usado quando ha necessidade de reordenamento.
                                // Ex: manter jogos anteriores ou gerar combinacoes aleatorias

        if (combinacoesAleatorias)
        {
            int i = 0;
            int ii;
            List<string> jogosAleatorios = new();
            List<int> indices = new();
            Random indiceRandomico = new();
            while (i < quantidadeLimite)
            {
                ii = Convert.ToInt32(indiceRandomico.Next(0, jogosTemp.Count));

                if (indices.IndexOf(ii) == -1)  // Elimina redundancias
                {
                    indices.Add(ii);
                    jogosAleatorios.Add(jogosTemp[ii]);
                    i++;
                    idSequencial++;
                }
            }
            jogosTemp = jogosAleatorios;
        }
        else
        {   // Copia os jogos gerados ate o limite especificado             
            List<string> jogosSelecionados = new();
            for (int i = 0; i < quantidadeLimite; i++)
            {
                jogosSelecionados.Add(jogosTemp[i]);
            }
            jogosTemp = jogosSelecionados;
        }

        // Mantem combinacoes anteriores, caso selecionado
        if (mantemAnteriores)
        {
            idSequencial = _combinacoes.Count;
            for (int i = 0; i < jogosTemp.Count; i++)
            {
                idSequencial++; // continua Id (sequencia) a partir do id do ultimo jogo.

                _combinacoes.Add(jogosTemp[i]);
            }
        }
        else
        {
            _combinacoes = jogosTemp;
        }

        List<Jogo> combinacoesFinais = new();
        for (int i = 0; i < _combinacoes.Count; i++)
        {
            combinacoesFinais.Add(new Jogo
            {
                Id = i + 1,
                DezenasTexto = _combinacoes[i]
            });
        }

        Combinacoes = combinacoesFinais;

        return new LotoResponse
        {
            Successo = _combinacoes.Count > 0,
            Mensagem = _combinacoes.Count > 0 ? $"{_combinacoes.Count} combinações geradas." : "Nenhuma combinação foi gerada.",
            Combinacoes = Combinacoes
        };
    }

    public void LimpaCombinacoes()
    {
        _combinacoes = new();
    }

}
