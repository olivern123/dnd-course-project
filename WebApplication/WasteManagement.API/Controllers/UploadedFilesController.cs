using Microsoft.AspNetCore.Mvc;
using WasteManagement.API.Data;
using WasteManagement.API.Models;

namespace WasteManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UploadedFilesController : ControllerBase
{
    private readonly AppDbContext _context;

    public UploadedFilesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Upload([FromBody] UploadedFile file)
    {
        if (file == null || file.Content.Length == 0)
            return BadRequest("Invalid file upload.");

        _context.UploadedFiles.Add(file);
        await _context.SaveChangesAsync();

        return Ok(new { file.Id });
    }
}
