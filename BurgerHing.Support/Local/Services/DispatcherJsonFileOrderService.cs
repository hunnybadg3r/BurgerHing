using BurgerHing.Support.Local.Models;
using Serilog;
using System.IO;
using System.Text.Json;

namespace BurgerHing.Support.Local.Services
{
    public class DispatcherJsonFileOrderService(ILogger logger) : IDispatcherOrderService
    {
        private readonly ILogger _logger = logger;

        public bool DispatcherOrder(OrderInfo orderInfo)
        {
            try
            {
                var folderPath = "orders";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                
                DateTime localOrderDate = TimeZoneInfo.ConvertTimeFromUtc(orderInfo.OrderDate, TimeZoneInfo.Local);

                orderInfo.OrderDate = localOrderDate;

                var fileName = localOrderDate.ToString("yyyyMMdd_HHmmss");
                var filePath = Path.Combine(folderPath, $"{fileName}-{orderInfo.OrderNumber}.json");
                
                ExportOrderToJson(orderInfo, filePath);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Failed to dispatch order: {OrderNumber}", orderInfo.OrderNumber);
                
                return false;
            }

            return true; 
        }

        public void ExportOrderToJson(OrderInfo order, string filePath)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
            };
            
            string json = JsonSerializer.Serialize(order, options);
            
            File.WriteAllText(filePath, json);
        }
    }
}
