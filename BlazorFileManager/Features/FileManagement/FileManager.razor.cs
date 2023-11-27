using BlazorFileManager.Shared.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazorFileManager.Features.FileManagement
{
    public partial class FileManager : ComponentBase
    {
        [Inject]
        public IFileManagerService FileManagerService { get; set; } = default!;

        public FileManagerState? FileManagerState { get; set; }

        protected override void OnInitialized()
        {
            FileManagerState = new(FileManagerService);
            FileManagerState.OnDirectoryHasBeenChanged += StateHasChanged;
        }
    }
}
