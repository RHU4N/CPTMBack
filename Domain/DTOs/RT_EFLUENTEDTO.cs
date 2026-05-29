using System.Text.Json.Serialization;

namespace CPTMBack.Domain.DTOs
{
    public class RT_EFLUENTEDTO
    {
        public int attachmentId { get; set; }

        public string relObjectId { get; set; } = string.Empty;

        public string? contentType { get; set; }

        public string? attName { get; set; }

        public long dataSize { get; set; }

        [JsonIgnore]
        public byte[] data { get; set; } = Array.Empty<byte>();

        public string dataBase64 => Convert.ToBase64String(data);
    }
}
