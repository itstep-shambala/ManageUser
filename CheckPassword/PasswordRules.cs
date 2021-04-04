namespace CheckPassword
{
    public class PasswordRules
    {
        public int MinLen { get; set; }
        public int MinCapLetter { get; set; }
        public int MinSmallLetter { get; set; }
        public int MinInt { get; set; }
        public int MinSymbol { get; set; }
        public int RusYesNo { get; set; }
        public int EnYesNo { get; set; }
        public string CapLettersRus { get; set; }
        public string SmallLettersRus { get; set; }
        public string CapLettersEn { get; set; }
        public string SmallLettersEn { get; set; }
        public string Symbols { get; set; }
        public string Int { get; set; }
        
    }
}