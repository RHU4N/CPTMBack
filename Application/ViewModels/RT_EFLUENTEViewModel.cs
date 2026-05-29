namespace CPTMBack.Application.ViewModels
{
    public class RT_EFLUENTEViewModel
    {
        public int attachmentId { get; set; }

        public string relObjectId { get; set; } = string.Empty;

        public string? contentType { get; set; }

        public string? attName { get; set; }

        public long dataSize { get; set; }

        public IFormFile? data { get; set; }
    }
}
