namespace JpLoto.Lottery.Loto
{
    public class Dezena
    {
        public int Indice { get; set; }
        public string DezenaTxt { get => (Indice + 1).ToString("00"); }
        public int Status { get; set; }
        public bool UrlDinamica { get; set; } = true;
        private string _urlDezenaLivre { get; set; } = string.Empty;
        private string _urlDezenaSelecionada { get; set; } = string.Empty;
        private string _urlDezenaFixa { get; set; } = string.Empty;
        private string _urlDezenaSugerida { get; set; } = string.Empty;
        private string _urlDezenaBloqueada { get; set; } = string.Empty;
        public string UrlDezenaLivre
        {
            get
            {
                if (!UrlDinamica) return _urlDezenaLivre;
                return $"DezenaLivre_{Indice:00}";
            }
            set => _urlDezenaLivre = value;
        }
        public string UrlDezenaSelecionada
        {
            get
            {
                if (!UrlDinamica) return _urlDezenaSelecionada;
                return $"DezenaSelecionada_{Indice:00}";
            }
            set => _urlDezenaSelecionada = value;
        }
        public string UrlDezenaFixa
        {
            get
            {
                if (!UrlDinamica) return _urlDezenaFixa;
                return $"DezenaFixa_{Indice:00}";
            }
            set => _urlDezenaFixa = value;
        }
        public string UrlDezenaSugerida
        {
            get
            {
                if (!UrlDinamica) return _urlDezenaSugerida;
                return $"DezenaSugerida_{Indice:00}";
            }
            set => _urlDezenaSugerida = value;
        }
        public string UrlDezenaBloqueada
        {
            get
            {
                if (!UrlDinamica) return _urlDezenaBloqueada;
                return $"DezenaBloqueada_{Indice:00}";
            }
            set => _urlDezenaBloqueada = value;
        }

    }
}
