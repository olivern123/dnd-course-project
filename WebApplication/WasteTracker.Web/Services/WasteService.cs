using WasteTracker.Web.Models;
using System.Net.Http.Json;

namespace WasteTracker.Web.Services
{
    public class WasteService
    {
        private readonly HttpClient _http;

        public HttpClient Http => _http;  // <-- FIX: expose HttpClient safely

        public WasteService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<WasteEntry>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<WasteEntry>>("wasteentries")
                   ?? new List<WasteEntry>();
        }

        public async Task AddAsync(WasteEntry entry)
        {
            await _http.PostAsJsonAsync("wasteentries", entry);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"wasteentries/{id}");
            return response.IsSuccessStatusCode;
        }

        // ================================================
        // BUSINESS CALCULATIONS
        // ================================================

        /// <summary>
        /// Get total waste in kg across all entries
        /// </summary>
        public async Task<decimal> GetTotalWasteKg()
        {
            var entries = await GetAllAsync();
            return entries.Sum(e => e.QuantityKg);
        }

        /// <summary>
        /// Get Kantspild (edge waste) in kg
        /// </summary>
        public async Task<decimal> GetKantspildKg()
        {
            var entries = await GetAllAsync();
            return entries
                .Where(e => e.WasteType?.Name.Equals("Kantspild", StringComparison.OrdinalIgnoreCase) == true)
                .Sum(e => e.QuantityKg);
        }

        /// <summary>
        /// Get other waste types (excluding Kantspild and InternalReuse)
        /// </summary>
        public async Task<decimal> GetOtherWasteKg()
        {
            var entries = await GetAllAsync();
            return entries
                .Where(e => e.WasteType?.Name != "Kantspild" && e.WasteType?.Name != "InternalReuse")
                .Sum(e => e.QuantityKg);
        }

        /// <summary>
        /// Get waste that is reused internally as materials
        /// </summary>
        public async Task<decimal> GetInternalReuseKg()
        {
            var entries = await GetAllAsync();
            return entries
                .Where(e => e.WasteType?.Name.Equals("InternalReuse", StringComparison.OrdinalIgnoreCase) == true)
                .Sum(e => e.QuantityKg);
        }

        /// <summary>
        /// Get percentage breakdown: reused vs disposed
        /// </summary>
        public async Task<(decimal percentReused, decimal percentDisposed)> GetReuseStats()
        {
            decimal total = await GetTotalWasteKg();
            decimal reuse = await GetInternalReuseKg();
            decimal disposed = total - reuse;

            if (total == 0)
                return (0, 0);

            return (
                percentReused: (reuse / total) * 100m,
                percentDisposed: (disposed / total) * 100m
            );
        }

        /// <summary>
        /// Get breakdown by waste type name
        /// </summary>
        public async Task<Dictionary<string, decimal>> GetWasteByType()
        {
            var entries = await GetAllAsync();
            return entries
                .GroupBy(e => e.WasteType?.Name ?? "Unknown")
                .ToDictionary(g => g.Key, g => g.Sum(e => e.QuantityKg));
        }
    }
}
