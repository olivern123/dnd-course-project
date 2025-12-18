# Blog Post 4 User Management
## User Model
The system contains two different types of users: Admin and User. The admin has added functionalities compared to the User, the admin has the option to delete records from the dashboard, where as the user only can upload data in the add waste page.
Users are stored in the SQLite database using Entity framework Core, the model in the api is shown below:

public class User {
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

passwords are stored in plain text, in a real system it would be hashed, but this was outside the scope

## Login endpoint
We created a UsersController that exposes a login endpoint:
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public async Task<ActionResult<User>> Login([FromBody] UserDto dto)
    {
        var foundUser = await _context.Users
            .FirstOrDefaultAsync(u =>
                u.Username == dto.Username &&
                u.Password == dto.Password);

        if (foundUser == null)
            return Unauthorized("Invalid credentials.");

        return Ok(foundUser); 
    }
}

this checks the username and password and returns the matching user if credentials are valid from the database.

## Login in the blazor app
The blazor page Login.razor, is responsible for logging in, which sends the credentials to the api using a HttpClient
var response = await Http.PostAsJsonAsync("users/login", loginModel);

if (response.IsSuccessStatusCode)
{
    var user = await response.Content.ReadFromJsonAsync<User>();
    error = null;
}
else
{
    error = "Invalid username or password.";
}

This gives the user feedback if autentication fails.
To enable API communication, we configured HttpClient in Program.cs

builder.Services.AddHttpClient("Default", client =>
{
    client.BaseAddress = new Uri("http://localhost:5104/api/");
});

builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("Default"));

This allows any blazor component to call the api by injecting httpclient.

Describe how the actors functionalities are assigned and handled 
