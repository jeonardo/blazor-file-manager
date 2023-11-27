using BlazorFileManager.Features.FileManagement;
using Microsoft.AspNetCore.Components;

namespace BlazorFileManager.Features.FileManagement.Components
{
    public partial class FileManagerRouter : ComponentBase
    {
        [CascadingParameter]
        public FileManagerState FileManagerState { get; set; } = default!;
    }
}
