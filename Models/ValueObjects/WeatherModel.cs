using MVCPortfolio.Models.Enums;

namespace MVCPortfolio.Models.ValueObjects {
    public struct WeatherModel {

        public string? Location { get; set; }

        public double Degree { get; init; }
        public WeatherType WeatherType { get; init; }
        public int Humidity { get; init; }

        public string WeatherDescription {
            get {
                var weatherString = WeatherType.ToString().ToLower();
                return string.Concat(weatherString[0].ToString().ToUpper(), weatherString.AsSpan(1));
            }
        }

        public string ImgSrc {
            get => "/svgs/" + WeatherType.ToString() + ".svg";
        }

        public WeatherModel(double degree, WeatherType weatherType, int humidity, string? location = null) {
            this.Degree = degree;
            this.WeatherType = weatherType;
            this.Humidity = humidity;
            this.Location = location;
        }

    }
}
