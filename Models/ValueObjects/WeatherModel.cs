using MVCPortfolio.Models.Enums;

namespace MVCPortfolio.Models.ValueObjects {
    public struct WeatherModel {

        public string? Location { get; set; }

        public double Degree { get; init; }
        public WeatherType WeatherType { get; init; }

        public string WeatherDescription { 
            get => WeatherType switch {
                    WeatherType.CLOUDY => "Bewölkt",
                    WeatherType.RAIN => "Regen",
                    WeatherType.SNOWY => "Schnee",
                    WeatherType.THUNDER => "Gewitter",
                    WeatherType.SUNNY => "Sonnig",
                    _ => throw new ArgumentException("Unknown Weather Type")
            };
        }

        public string ImgSrc {
            get => "/svgs/" + WeatherType.ToString() + ".svg";
        }

        public int Humidity { get; init; }

        public WeatherModel(double degree, WeatherType weatherType, int humidity) {
            this.Degree = degree;
            this.WeatherType = weatherType;
            this.Humidity = humidity;
            Location = null;
        }

    }
}
