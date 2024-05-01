namespace  BurgerHing.Configuration
{
    public class PriceDisplaySettings
    {
        public static string SectionName { get; } = "PirceDisplaySettings";
        public string PriceStringFormat { get; init; }
        public string PriceUnit { get; init; }
        public PriceUnitNotation PriceUnitNotation { get; init; }
    }
}
