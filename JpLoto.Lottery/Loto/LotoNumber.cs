namespace JpLoto.Lottery.Loto
{
    public class LotoNumber
    {
        public int Indice { get; set; }
        public string NumberTxt { get => (Indice + 1).ToString("00"); }
        public int Status { get; set; }
        public bool DynamicUrl { get; set; } = true;
        private string _url_FreeNumber { get; set; } = string.Empty;
        private string _urlSelectedNumber { get; set; } = string.Empty;
        private string _urlFixedNumber { get; set; } = string.Empty;
        private string _urlSuggestedNumber { get; set; } = string.Empty;
        private string _urlBlockedNumber { get; set; } = string.Empty;
        public string Url_FreeNumber
        {
            get
            {
                if (!DynamicUrl) return _url_FreeNumber;
                return $"_FreeNumber_{Indice:00}";
            }
            set => _url_FreeNumber = value;
        }
        public string UrlSelectedNumber
        {
            get
            {
                if (!DynamicUrl) return _urlSelectedNumber;
                return $"SelectedNumber_{Indice:00}";
            }
            set => _urlSelectedNumber = value;
        }
        public string UrlFixedNumber
        {
            get
            {
                if (!DynamicUrl) return _urlFixedNumber;
                return $"FixedNumber_{Indice:00}";
            }
            set => _urlFixedNumber = value;
        }
        public string UrlSuggestedNumber
        {
            get
            {
                if (!DynamicUrl) return _urlSuggestedNumber;
                return $"SuggestedNumber_{Indice:00}";
            }
            set => _urlSuggestedNumber = value;
        }
        public string UrlBlockedNumber
        {
            get
            {
                if (!DynamicUrl) return _urlBlockedNumber;
                return $"BlockedNumber_{Indice:00}";
            }
            set => _urlBlockedNumber = value;
        }

    }
}
