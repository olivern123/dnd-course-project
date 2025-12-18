# Blog Post 3 - Web Application (Blazor Frontend)
## Overview
In this phase of the project, we developed the Blazor Server application that acts as the user-facing frontend for our ESG waste-tracking system. The goal was to build an interactive, responsive, and API-connected UI where users can view, upload, and manage waste data. The frontend communicates directly with our RESTful Web API (created in Blog Post 2) using HTTP requests.

## Connecting Blazor to the API
To make the frontend communicate with the backend, we configured a shared HttpClient instance in Program.cs:

builder.Services.AddHttpClient("Default", client =>
{
    client.BaseAddress = new Uri("http://localhost:5104/api/");
});
builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("Default"));

This allows every Razor component to inject an HttpClient and call API endpoints like:

We also created a WasteService class that wraps API logic and provides reusable methods such as GetAllAsync().
The user interface is built with Razor components .razor files

## Dashboard
Displays all waste entries retrieved from the API. The blazor component loads data here:

entries = await WasteService.GetAllAsync();

The dashboard presents each entry along with its Site, WasteType, and HandlingMethod, which are included from the API via EF Core.

One of the most important features implemented at this stage was the ability to upload Excel files (Opgørelse PO xxxx.xlsx) and automatically extract waste numbers. The Blazor page uses <InputFile> to accept file uploads and the ClosedXML library to parse spreadsheets.
The logic extracts:

The date (Dato:)

Total waste (Spild ialt)

Automatically posts a WasteEntry to the API

This allows large datasets to be imported efficiently without manual typing.

## Login page
We implemented a simple login screen that sends credentials to the API’s UsersController:

var response = await Http.PostAsJsonAsync("users/login", loginModel);

By the end of this phase, we developed a fully functional Blazor Server application that communicates seamlessly with the backend Web API. Users can log in, upload Excel files, and view dynamically loaded waste data. This establishes the foundation for adding KPIs, graphs, and advanced reporting in the next development phase.

## Add Waste page
In order to upload excel files/data we have created the add waste page which is made to upload excel files and extract relevant data and showing it in a preview. This was done using closedXML:
private decimal TryParseCellValue(IXLCell? cell)
    {
        if (cell == null) return 0;
        try
        {
            if (cell.DataType == XLDataType.Number)
            {
                try { return Convert.ToDecimal(cell.GetDouble()); } catch { }
            }

            var s = cell.GetString();
            if (string.IsNullOrWhiteSpace(s)) return 0;

            // Remove non-breaking spaces and normal spaces used as thousand separators
            s = s.Replace("\u00A0", "").Replace(" ", "").Trim();

            // Handle parentheses for negatives
            var isNegative = s.StartsWith("(") && s.EndsWith(")");
            s = s.Replace("(", "").Replace(")", "");

            // Replace comma with dot for invariant parse, but allow either
            s = s.Replace(',', '.');

            // Remove any non-digit except dot and minus
            var filtered = new System.Text.StringBuilder();
            foreach (var ch in s)
            {
                if ((ch >= '0' && ch <= '9') || ch == '.' || ch == '-') filtered.Append(ch);
            }

            var cleaned = filtered.ToString();
            if (string.IsNullOrWhiteSpace(cleaned)) return 0;

            if (decimal.TryParse(cleaned, NumberStyles.Number | NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var v))
            {
                return isNegative ? -v : v;
            }
        }
        catch { }

        return 0;
    }
The method presented here is used to parse data from the Excel files and return them in a consistent numeric format, ensuring that variations in number formatting, such as different decimal separators, thousand separators, and negative value representations, are handled correctly before the data is processed further by the system.

## Competitor page
When navigating to the competitor page the user once again has the option to upload a file, where the system will try to parse the document and extract relevant data to show as KPIs.

<div class="mb-3">
    <InputFile OnChange="HandleFile" accept=".xlsx" />
</div>

@if (error != null)
{
    <div class="alert alert-danger">@error</div>
}

@if (competitors != null && competitors.Any())
{
    <h5>Loaded rows: @competitors.Count</h5>

    <div class="mb-3">
        <label class="form-label">Filter by Year</label>
        <select class="form-select" @onchange="OnYearChanged">
            <option value="">All</option>
            @foreach (var y in years)
            {
                <option value="@y">@y</option>
            }
        </select>
    </div>

    <table class="table table-sm table-striped">
        <thead>
            <tr>
                <th>Company</th>
                <th>Year</th>
                <th>Total (kg)</th>
                <th>Kantspild (kg)</th>
                <th>Kvalitetspild (kg)</th>
                <th>Internal Reuse (kg)</th>
                <th>Incineration (kg)</th>
                <th>Reuse %</th>
                <th>Data Source</th>
            </tr>
        </thead>
        <tbody>
            @foreach (var c in filtered)
            {
                <tr>
                    <td>@c.Company</td>
                    <td>@c.Year</td>
                    <td>@c.TotalWasteKg</td>
                    <td>@c.KantspildKg</td>
                    <td>@c.KvalitetsspildKg</td>
                    <td>@c.InternalReuseKg</td>
                    <td>@c.WasteToIncinerationKg</td>
                    <td>
                        <div style="display:flex;align-items:center;gap:8px;">
                            <div style="width:120px;background:#eee;height:12px;border-radius:6px;overflow:hidden;">
                                <div style="height:12px;background:linear-gradient(90deg,#2ecc71,#27ae60);width:@Math.Min(100,(double)c.ReusePercentage)%"></div>
                            </div>
                            <div>@c.ReusePercentage.ToString("0.0")% </div>
                        </div>
                    </td>
                    <td>@c.DataSource</td>
                </tr>
            }
        </tbody>
    </table>
    
