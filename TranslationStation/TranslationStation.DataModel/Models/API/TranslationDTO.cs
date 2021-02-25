namespace TranslationStation.DataModel.Models.API
{
    public class TranslationDto
    {
        public string Key { get; set; }
        public string EnglishWord { get; set; }
        public string SpanishWord { get; set; }
        public bool IsVerified { get; set; }
    }
}
