using MVCPortfolio.Models.Enums;
using MVCPortfolio.Models.Interfaces;
using MVCPortfolio.Models.ValueObjects;

namespace MVCPortfolio.Models.Services {
    public class WeatherService : IWeatherService{

        public Task<WeatherModel> GetWeatherAsync() {
            Random rand = new();

            var wType = Enum.GetValues(typeof(WeatherType))
                            .OfType<WeatherType>()
                            .OrderBy(e => rand.Next())
                            .FirstOrDefault();

            var deg = wType == WeatherType.SNOWY ? rand.Next(15) - 10 : rand.Next(20) + 10;
            var humidity = rand.Next(60) + 40;

            return Task.FromResult(new WeatherModel(deg, wType, humidity));
        }

        public async Task<WeatherModel> GetWeatherForLocationAsync(string location) {
            var weather = await GetWeatherAsync();
            weather.Location = location;
            return weather;
        }
    }
}
