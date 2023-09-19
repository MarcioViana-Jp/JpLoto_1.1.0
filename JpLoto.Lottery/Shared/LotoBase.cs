global using JpLoto.Lottery.Constants;
using JpLoto.Lottery.Dto;
using JpLoto.Lottery.Loto;
using System.Collections.ObjectModel;

namespace JpLoto.Lottery.Shared;

public abstract class LotoBase
{
    public int MaximaDezena { get; set; } = 0;
    public int DezenasPorJogo { get; set; } = 0;
    public int TipoLoto { get; set; } = -1;
    public int[] Dezenas { get; set; } = Array.Empty<int>();
    public List<Dezena> BotoesDezenas { get; set; }
    public void MarcaComoLivre(int indice) => DefineStatus(indice, Status.Livre);
    public void MarcaComoSugerida(int indice) => DefineStatus(indice, Status.Sugerida);

    public int QuantidadeDezenas => BotoesDezenas.Count;
    public int QuantidadeDezenasFixas => BotoesDezenas.Count(bd => bd.Status == Status.Fixa);
    public int QuantidadeDezenasLivres => BotoesDezenas.Count(bd => bd.Status == Status.Livre);
    public int QuantidadeDezenasSugeridas => BotoesDezenas.Count(bd => bd.Status == Status.Sugerida);
    public int QuantidadeDezenasSelecionadas => BotoesDezenas.Count(bd => bd.Status == Status.Selecionada);
    public int QuantidadeDezenasBloqueadas => BotoesDezenas.Count(bd => bd.Status == Status.Bloqueada);

    public int[] DezenasFixas { get => ObtemDezenas(Status.Fixa); }
    public List<Dezena> BotoesDezenasFixas { get => ObtemBotoesDezenas(Status.Fixa); }
    public int[] DezenasLivres { get => ObtemDezenas(Status.Livre); }
    public List<Dezena> BotoesDezenasLivres { get => ObtemBotoesDezenas(Status.Livre); }
    public int[] DezenasSugeridas { get => ObtemDezenas(Status.Sugerida); }
    public List<Dezena> BotoesDezenasSugeridas { get => ObtemBotoesDezenas(Status.Sugerida); }
    public int[] DezenasSelecionadas { get => ObtemDezenas(Status.Selecionada); }
    public List<Dezena> BotoesDezenasSelecionadas { get => ObtemBotoesDezenas(Status.Selecionada); }
    public int[] DezenasBloqueadas { get => ObtemDezenas(Status.Bloqueada); }
    public List<Dezena> BotoesDezenasBloqueadas { get => ObtemBotoesDezenas(Status.Bloqueada); }

    public LotoFileInfo LotoFileInfo { get; set; }
    private readonly int[] _dezenasPorJogo = { 5, 6, 7 };
    private readonly int[] _maximaDezena = { 31, 43, 37 };

    public LotoBase(int dezenasPorJogo, int maximaDezena)
    {
        DezenasPorJogo = dezenasPorJogo;
        MaximaDezena = maximaDezena;
        TipoLoto = LotoType.ObtemTipo(dezenasPorJogo);
        InicializaDezenas();
    }

    public LotoBase(int tipoLoto)
    {
        TipoLoto = tipoLoto;
        DezenasPorJogo = _dezenasPorJogo[tipoLoto];
        MaximaDezena = _maximaDezena[tipoLoto];
        InicializaDezenas();
    }

    public void SelecionaDezenas(object dezenas)
    {
        int[] _dezenas;
        if (!dezenas.GetType().IsArray)
        {
            string _dezenasTxt;
            try { _dezenasTxt = (string)dezenas; }
            catch { _dezenasTxt = string.Empty; }
            _dezenas = TextoParaVetor(_dezenasTxt, TipoLoto).DezenasVetor;
        }
        else
            _dezenas = (int[])dezenas;

        for (int i = 0; i < _dezenas.Length; i++)
        {
            MarcaComoSelecionada(_dezenas[i]);
        }
    }
    public void FixaDezenas(object dezenas)
    {
        int[] _dezenas;
        if (!dezenas.GetType().IsArray)
        {
            string _dezenasTxt;
            try { _dezenasTxt = (string)dezenas; }
            catch { _dezenasTxt = string.Empty; }
            _dezenas = TextoParaVetor(_dezenasTxt, TipoLoto).DezenasVetor;
        }
        else
            _dezenas = (int[])dezenas;
        for (int i = 0; i < _dezenas.Length; i++)
        {
            MarcaComoFixa(_dezenas[i]);
        }
    }

    public void MarcaComoSelecionada(int indice)
    {
        if (Dezenas[indice] == Status.Selecionada || Dezenas[indice] == Status.Fixa)
            MarcaComoLivre(indice);
        else
            DefineStatus(indice, Status.Selecionada);
    }

    public void MarcaComoFixa(int indice)
    {
        if (QuantidadeDezenasFixas < DezenasPorJogo - 1)
            DefineStatus(indice, Status.Fixa);
    }

    public void DesmarcaDezenasFixas()
    {
        for (int i = 0; i < Dezenas.Length; i++)
        {
            if (Dezenas[i] == Status.Fixa)
                MarcaComoLivre(i);
        }
    }

    public void DesmarcaDezenasSugeridas()
    {
        for (int i = 0; i < Dezenas.Length; i++)
        {
            if (Dezenas[i] == Status.Sugerida)
                MarcaComoLivre(i);
        }
    }

    public void DesmarcaDezenasSelecionadas()
    {
        for (int i = 0; i < Dezenas.Length; i++)
        {
            if (Dezenas[i] == Status.Selecionada)
                MarcaComoLivre(i);
        }
    }

    public void DesmarcaTodas()
    {
        DesmarcaDezenasSugeridas();
        DesmarcaDezenasSelecionadas();
        DesmarcaDezenasFixas();
        //DesmarcaDezenasBloqueadas();
    }

    public void AtualizaDezenasSelecionadas(int dezenasVariaveis)
    {
        var totalSelecionadas = QuantidadeDezenasSelecionadas;
        if (totalSelecionadas > dezenasVariaveis)
        {
            var botoesParaLiberar = BotoesDezenasSelecionadas.GetRange(dezenasVariaveis, totalSelecionadas - dezenasVariaveis);
            foreach (var botao in botoesParaLiberar)
            {
                DefineStatus(botao.Indice, Status.Livre);
            }
        }
    }

    public void InicializaDezenas()
    {
        Dezenas = new int[MaximaDezena];
        BotoesDezenas = new();
        for (int i = 0; i < MaximaDezena; i++)
        {
            Dezenas[i] = Status.Livre;
            BotoesDezenas.Add(new Dezena
            {
                Indice = i,
                Status = Status.Livre,
                UrlDinamica = false
            });
        }
        LotoFileInfo = new LotoFileInfo(TipoLoto);
    }

    public void DefineStatus(int indice, int status)
    {
        Dezenas[indice] = status;
        BotoesDezenas[indice].Status = status;
    }

    public long ObtemQuantidadeDeCombinacoes()
    {
        long quantidade = Fatorial(QuantidadeDezenasSelecionadas, DezenasPorJogo - QuantidadeDezenasFixas) / Fatorial(DezenasPorJogo - QuantidadeDezenasFixas);
        return quantidade;
    }

    private static long Fatorial(int num, int baseFatorial)
    {
        if (num <= 0) num *= -1;  // Evita números negativos
        long fatorial = num;
        int numBase;
        for (int i = 1; i < baseFatorial; i++)
        {
            numBase = num - i;
            fatorial *= numBase;
        }
        return fatorial;
    }

    private static long Fatorial(int num)
    {
        try
        {
            if (num <= 0) num *= -1;  // Evita números negativos

            if (num == 1)
            {
                return 1;
            }
            else
            {
                return num * Fatorial(num - 1);
            }
        }
        catch
        {
            return -1;
        }
    }

    public int[] ObtemDezenas(int status)
    {
        List<int> temp = new();
        for (int i = 0; i < Dezenas.Length; i++)
        {
            if (Dezenas[i] == status)
                temp.Insert(temp.Count, i);
        }
        return temp.ToArray();
    }

    public List<Dezena> ObtemBotoesDezenas(int status)
    {
        List<Dezena> temp = new();
        for (int i = 0; i < Dezenas.Length; i++)
        {
            if (BotoesDezenas[i].Status == status)
                temp.Insert(temp.Count, BotoesDezenas[i]);
        }
        return temp;
    }

    public void GeraSugestoes(int dezenasVariaveis)
    {
        if (QuantidadeDezenasSelecionadas == dezenasVariaveis)
            return;

        DesmarcaDezenasSugeridas();
        int[] _dezenasLivres = DezenasLivres;
        int[] _dezenasSugeridas;

        // Sugere/completa lista de dezenas variaveis ate o limite especificado pelo parametro 'dezenasVariaveis'
        int quantidadeDeSugestoes = dezenasVariaveis - DezenasSelecionadas.Length;

        Random indiceRandom = new();
        ObservableCollection<int> indicesRandomicos = new();
        int indTmp;
        int iSugestao = 0;

        _dezenasSugeridas = new int[quantidadeDeSugestoes];

        while (iSugestao < quantidadeDeSugestoes)
        {
            indTmp = Convert.ToInt16(indiceRandom.Next(0, QuantidadeDezenasLivres));

            if (indicesRandomicos.IndexOf(indTmp) == -1)    // Elimina redundancias
            {
                indicesRandomicos.Add(indTmp);
                MarcaComoSugerida(_dezenasLivres[indTmp]);
                _dezenasSugeridas[iSugestao] = _dezenasLivres[indTmp];   // Salva indice da dezena sugerida
                iSugestao++;
            }
        }

    }

    public void AplicaSugestoes()
    {
        var _dezenasSugeridas = DezenasSugeridas;
        for (int i = 0; i < _dezenasSugeridas.Length; i++)
        {
            MarcaComoSelecionada(_dezenasSugeridas[i]);
        }
    }

    public static ConversionResponse TextoParaVetor(string jogos, int tipoLoto, bool isBonus = false, string separador = ",")
    {
        if (string.IsNullOrEmpty(jogos))
            return new ConversionResponse()
            {
                ActionType = ConversionActionType.TextToArray,
                ResponseCode = ConversionResponseCode.MissingParameters
            };

        int maximaDezena = LotoType.MaximaDezena(tipoLoto);

        string[] jogosTxt = jogos.Split(separador);

        if (!isBonus && jogosTxt.Length != LotoType.DezenasPorJogo(tipoLoto))
            return new ConversionResponse()
            {
                ActionType = ConversionActionType.TextToArray,
                ResponseCode = ConversionResponseCode.NumbersLenghtError
            };

        if (isBonus && jogosTxt.Length != LotoType.QuantidadeDeBonus(tipoLoto))
            return new ConversionResponse()
            {
                ActionType = ConversionActionType.TextToArray,
                ResponseCode = ConversionResponseCode.BonusLenghtError
            };

        int[] jogosNum = Array.Empty<int>();
        int dezena;
        try
        {
            bool haDezenaForaDaFaixa = false;
            for (int i = 0; i < jogosTxt.Length; i++)
            {
                dezena = Convert.ToInt32(jogosTxt[i]);
                if (dezena > 0 && dezena <= maximaDezena)
                {
                    jogosNum = jogosNum.Concat(new int[] { dezena }).ToArray();
                }
                else
                {
                    haDezenaForaDaFaixa = true;
                }
            }
            if (haDezenaForaDaFaixa)
                return new ConversionResponse()
                {
                    ActionType = ConversionActionType.TextToArray,
                    ResponseCode = ConversionResponseCode.OutOfRange
                };

            Array.Sort(jogosNum);
            return new ConversionResponse(jogosNum, tipoLoto)
            {
                ActionType = ConversionActionType.TextToArray
            };
        }
        catch
        {
            return new ConversionResponse() { ResponseCode = ConversionResponseCode.InputError };
        }
    }

    public static string VetorParaTexto(int[] jogos, int tipoLoto, string separador = ",")
    {
        if (jogos.Length == 0)
            return string.Empty;

        int maximaDezena = LotoType.MaximaDezena(tipoLoto);

        string _separador = string.Empty;
        string jogosTxt = string.Empty;
        for (int i = 0; i < jogos.Length; i++)
        {
            if (jogos[i] > 0 && jogos[i] <= maximaDezena)
            {
                jogosTxt += _separador + jogos[i].ToString("00");
                _separador = separador;
            }
        }
        return jogosTxt;
    }

}
