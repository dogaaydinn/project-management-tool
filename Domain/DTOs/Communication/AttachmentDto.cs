namespace Domain.DTOs.Communication;

public class AttachmentDto
{
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public string FileType { get; set; }
    public long FileSize { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid UploaderId { get; set; }
    public string UploaderName { get; set; }
    public DateTime UploadDate { get; set; }
    public DateTime LastAccessed { get; set; }
    public int DownloadCount { get; set; }
}