using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WasteManagement.API.Data;
using WasteManagement.API.Models;

namespace WasteManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WasteEntriesController : ControllerBase
{
    private readonly AppDbContext _context;

    public WasteEntriesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/wasteentries
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WasteEntry>>> GetWasteEntries()
    {
        return await _context.WasteEntries
            .Include(w => w.Site)
            .Include(w => w.WasteType)
            .Include(w => w.HandlingMethod)
            .ToListAsync();
    }

    // GET: api/wasteentries/5
    [HttpGet("{id}")]
    public async Task<ActionResult<WasteEntry>> GetWasteEntry(int id)
    {
        var entry = await _context.WasteEntries
            .Include(w => w.Site)
            .Include(w => w.WasteType)
            .Include(w => w.HandlingMethod)
            .FirstOrDefaultAsync(e => e.EntryId == id);

        if (entry == null)
            return NotFound();

        return entry;
    }

    // POST: api/wasteentries
    [HttpPost]
    public async Task<ActionResult<WasteEntry>> PostWasteEntry(WasteEntry entry)
    {
        _context.WasteEntries.Add(entry);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetWasteEntry), new { id = entry.EntryId }, entry);
    }

    // DELETE: api/wasteentries/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWasteEntry(int id)
    {
        var entry = await _context.WasteEntries.FindAsync(id);
        if (entry == null)
            return NotFound();

        // If there are uploaded files linked to this entry, remove them first
        var files = _context.UploadedFiles.Where(f => f.WasteEntryId == id);
        if (files.Any())
        {
            _context.UploadedFiles.RemoveRange(files);
        }

        _context.WasteEntries.Remove(entry);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
