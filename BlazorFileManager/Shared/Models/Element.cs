using BlazorFileManager.Shared.Enums;

namespace BlazorFileManager.Shared.Models
{
    public record Element(DataElementType Type = DataElementType.NONE, string Path = "");
}
