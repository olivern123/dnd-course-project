using WasteTracker.Web.Models;
using System.Net.Http.Json;

namespace WasteTracker.Web.Services
{
    public class WasteService
    {
        private readonly HttpClient _http;

        public WasteService(HttpClient http)
        {
            _http = http;
        }

        // Because BaseAddress = http://localhost:5104/api/
        // we must call "wasteentries" (NOT "api/wasteentries")
        public async Task<List<WasteEntry>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<WasteEntry>>("wasteentries")
                   ?? new List<WasteEntry>();
        }

        public async Task AddAsync(WasteEntry entry)
        {
            await _http.PostAsJsonAsync("wasteentries", entry);
        }
    }
}
