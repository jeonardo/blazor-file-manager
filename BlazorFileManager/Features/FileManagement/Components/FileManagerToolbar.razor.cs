using BlazorFileManager.Features.FileManagement;
using BlazorFileManager.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorFileManager.Features.FileManagement.Components
{
    public partial class FileManagerToolbar : ComponentBase
    {
        [CascadingParameter]
        public FileManagerState FileManagerState { get; set; } = default!;

        public ConfirmDeleteModal? DeleteConfirmation { get; set; }

        public CreateFolderModal? CreateFolderModal { get; set; }

        protected override void OnInitialized()
        {
            FileManagerState.OnDataElementSelected += OnDataElementSelected;
            FileManagerState.OnDataElementUnSelected += OnDataElementUnSelected;
        }

        private void OnDataElementSelected(Element element) => StateHasChanged();

        private void OnDataElementUnSelected() => StateHasChanged();

        private void ConfirmCreateAction(string directoryName) => FileManagerState.CreateDirectory(directoryName);

        private void ConfirmDeleteAction(bool deleteConfirmed) => FileManagerState.DeleteElement();
    }
}
