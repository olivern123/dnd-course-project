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
