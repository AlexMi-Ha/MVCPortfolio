﻿using MVCPortfolio.Models.ValueObjects;

namespace MVCPortfolio.Models.Interfaces {
    public interface IWeatherService {

        Task<WeatherModel> GetWeatherAsync(string location);
    }
}
