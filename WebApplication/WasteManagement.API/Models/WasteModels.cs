namespace WasteManagement.API.Models;
// Klasser for vores waste management api (HUSK KLASSE DIAGRAM)
public class Site
{
    public int SiteId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
}

public class WasteType
{
    public int WasteTypeId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
}

public class HandlingMethod
{
    public int HandlingId { get; set; }
    public string Method { get; set; } = string.Empty;
    public decimal CostPerTon { get; set; }
    public decimal CO2FactorPerTon { get; set; }
}

public class WasteEntry
{
    public int EntryId { get; set; }
    public int SiteId { get; set; }
    public Site? Site { get; set; }
    public int WasteTypeId { get; set; }
    public WasteType? WasteType { get; set; }
    public int HandlingId { get; set; }
    public HandlingMethod? HandlingMethod { get; set; }
    public decimal QuantityKg { get; set; }
    public DateTime Date { get; set; }
}
