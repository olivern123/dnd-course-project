namespace WasteManagement.API.Models
{
    public class UploadedFile
    {
        public int Id { get; set; }

        public string FileName { get; set; } = string.Empty;

        public byte[] Content { get; set; } = Array.Empty<byte>();

        // Link to WasteEntry
        public int WasteEntryId { get; set; }
        public WasteEntry? WasteEntry { get; set; }
    }
}
