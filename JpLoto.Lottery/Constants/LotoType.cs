namespace JpLoto.Lottery.Constants;

public static class LotoType
{
    private static string[] _lotoType = { "MiniLoto", "Loto6", "Loto7" };
    private static int[] _numbersPerCard = { 5, 6, 7 };
    private static int[] _quantidadeDeBonus = { 1, 1, 2 };
    private static int[] _maxNumber = { 31, 43, 37 };

    public const int MiniLoto = 0;
    public const int Loto6 = 1;
    public const int Loto7 = 2;
    public static int NumbersPerCard(int lotoType) => _numbersPerCard[lotoType];
    public static int QuantityOfBonus(int lotoType) => _quantidadeDeBonus[lotoType];
    public static int MaxNumber(int lotoType) => _maxNumber[lotoType];
    public static class MiniLotoInfo
    {
        public const int MaxNumber = 31;
        public const int NumbersPerCard = 5;
        public const int QuantityOfBonus = 1;
    }
    public static class Loto6Info
    {
        public const int MaxNumber = 43;
        public const int NumbersPerCard = 6;
        public const int QuantityOfBonus = 1;
    }
    public static class Loto7Info
    {
        public const int MaxNumber = 37;
        public const int NumbersPerCard = 7;
        public const int QuantityOfBonus = 2;
    }
    public static string Name(int type)
    {
        return type > _lotoType.Length || type < 0 ? string.Empty : _lotoType[type];
    }
    public static int GetType(int numbersPerCard)
    {
        int[] tipos = { 0, 0, 0, 0, 0, 0, 1, 2 };
        return tipos[numbersPerCard];
    }
}
