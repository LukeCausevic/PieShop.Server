﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace PieShop.Server.Service
{
    public class CountryDataService : ICountryDataService
    {
        private readonly HttpClient _httpClient;

        public CountryDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Country>>
                (await _httpClient.GetStreamAsync($"api/country"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Country> GetCountryById(int CountryId)
        {
            return await JsonSerializer.DeserializeAsync<Country>
                (await _httpClient.GetStreamAsync($"api/country/{CountryId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
