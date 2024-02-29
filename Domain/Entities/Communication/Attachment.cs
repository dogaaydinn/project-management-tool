namespace Domain.Entities;

public class Attachment
{
    public int Id { get; set; }
    public string FileName { get; set; } // Consider using a unique identifier like a GUID
    public string FilePath { get; set; } // Relative or absolute path to the file
    public string ContentType { get; set; } // MIME type of the file
    public long Size { get; set; } // File size in bytes (optional)
    public int OriginId { get; set; } // Foreign key referencing the entity the attachment belongs to
    // Depending on your needs, you could add:
    // - UploadDate: DateTime for when the attachment was uploaded
    // - Description: String describing the attachment
}