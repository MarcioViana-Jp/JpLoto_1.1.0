namespace JpLoto.Lottery.Constants
{
    public static class LotoType
    {
        private static string[] _tipoLoto = { "MiniLoto", "Loto6", "Loto7" };
        private static int[] _dezenasPorJogo = { 5, 6, 7 };
        private static int[] _quantidadeDeBonus = { 1, 1, 2 };
        private static int[] _maximaDezena = { 31, 43, 37 };

        public const int MiniLoto = 0;
        public const int Loto6 = 1;
        public const int Loto7 = 2;
        public static int DezenasPorJogo(int tipoLoto) => _dezenasPorJogo[tipoLoto];
        public static int QuantidadeDeBonus(int tipoLoto) => _quantidadeDeBonus[tipoLoto];
        public static int MaximaDezena(int tipoLoto) => _maximaDezena[tipoLoto];
        public static class MiniLotoInfo
        {
            public const int MaximaDezena = 31;
            public const int DezenasPorJogo = 5;
            public const int QuantidadeDeBonus = 1;
        }
        public static class Loto6Info
        {
            public const int MaximaDezena = 43;
            public const int DezenasPorJogo = 6;
            public const int QuantidadeDeBonus = 1;
        }
        public static class Loto7Info
        {
            public const int MaximaDezena = 37;
            public const int DezenasPorJogo = 7;
            public const int QuantidadeDeBonus = 2;
        }
        public static string Nome(int tipo)
        {
            return tipo > _tipoLoto.Length || tipo < 0 ? string.Empty : _tipoLoto[tipo];
        }
        public static int ObtemTipo(int dezenasPorJogo)
        {
            int[] tipos = { 0, 0, 0, 0, 0, 0, 1, 2 };
            return tipos[dezenasPorJogo];
        }
    }
}

