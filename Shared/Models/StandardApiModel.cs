namespace Shared.Models
{
    public enum Status
    {
        OK,
        Fehler,
        Abbruch
    }

    public class StandardApiModel
    {
        public Status Status { get; set; }
        public string? Heading { get; set; }
        public string? Description { get; set; }
        public object? Data { get; set; }
    }
}
