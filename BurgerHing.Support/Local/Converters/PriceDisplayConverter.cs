using BurgerHing.Configuration;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace BurgerHing.Support.Local.Converters
{
    public class PriceDisplayConverter : MarkupExtension, IValueConverter
    {
        private readonly PriceDisplaySettings _priceDisplaySettings;
        public PriceDisplayConverter()
        {
             _priceDisplaySettings = new PriceDisplaySettings();
            AppSettings.Instance.Configuration.Bind(PriceDisplaySettings.SectionName, _priceDisplaySettings);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal decimalValue)
            {
                var format = _priceDisplaySettings.PriceStringFormat;
                var notation = _priceDisplaySettings.PriceUnitNotation;
                var unit = _priceDisplaySettings.PriceUnit;

                var convertedValue = notation == PriceUnitNotation.Prefix ? $"{unit} {decimalValue.ToString(format)}" 
                                                                          : $"{decimalValue.ToString(format)} {unit}";

                return convertedValue;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
