using BurgerHing.Configuration;
using BurgerHing.Support.Local.Models;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace BurgerHing.Support.Local.Converters
{
    public class CartPriceDisplayConverter : MarkupExtension, IValueConverter
    {
        private readonly PriceDisplaySettings _priceDisplaySettings;
        public CartPriceDisplayConverter()
        {
             _priceDisplaySettings = new PriceDisplaySettings();
            AppSettings.Instance.Configuration.Bind(PriceDisplaySettings.SectionName,
                                                    _priceDisplaySettings);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is CartItemInfo cartItem)
            {
                var format = _priceDisplaySettings.PriceStringFormat;
                var notation = _priceDisplaySettings.PriceUnitNotation;
                var unit = _priceDisplaySettings.PriceUnit;

                var total = cartItem.Price * cartItem.Quantity;
                var convertedValue = notation == PriceUnitNotation.Prefix ? $"{unit} {total.ToString(format)}" 
                                                                          : $"{total.ToString(format)} {unit}";
                
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
