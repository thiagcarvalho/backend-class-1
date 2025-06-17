using MessagePack;

namespace Libraries.MessagePack.Models;

[MessagePackObject]
public class Pet
{
    [Key(0)]
    public string Name { get; set; } = string.Empty;
    [Key(1)]
    public string Type { get; set; } = string.Empty;
    [Key(2)]
    public int Age { get; set; } = 0;
    [Key(3)]
    public string Owner { get; set; } = string.Empty;

}
