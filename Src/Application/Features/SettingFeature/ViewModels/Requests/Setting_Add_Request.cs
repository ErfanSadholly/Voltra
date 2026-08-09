namespace Application.Features;

public class Setting_Add_Request
{
    public required string Key { get; set; }
    public required string Value { get; set; }
    public string? Description { get; set; }
    public bool IsEncrypted { get; set; }
}
