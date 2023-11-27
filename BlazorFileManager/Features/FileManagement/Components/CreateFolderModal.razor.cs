using BlazorFileManager.Shared.Models;
using BlazorFileManager.SharedComponents.Modals;
using Microsoft.AspNetCore.Components;

namespace BlazorFileManager.Features.FileManagement.Components
{
    public partial class CreateFolderModal : ModalBase<string>
    {
        [CascadingParameter]
        public FileManagerState FileManagerState { get; set; } = default!;

        public NewFolderModel Model { get; set; } = new();

        protected override void TargetActionInvoke(string value)
        {
            base.TargetActionInvoke(value);
            Model = new();
        }

        private void OnSubmit(NewFolderModel model)
        {
            TargetActionInvoke(model.Name);
        }
    }
}
