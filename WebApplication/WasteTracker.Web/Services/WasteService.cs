using System.Net.Http.Json;
using WasteTracker.Web.Models;

public class WasteService
{
    private readonly HttpClient _http;
    private const string ApiBase = "http://localhost:5104/api/waste";

    public WasteService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<WasteEntry>> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<WasteEntry>>(ApiBase) ?? new();
    }

    public async Task AddAsync(WasteEntry entry)
    {
        await _http.PostAsJsonAsync(ApiBase, entry);
    }
}
