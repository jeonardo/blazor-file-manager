using BlazorFileManager.Features.FileManagement;
using BlazorFileManager.Shared.Enums;
using BlazorFileManager.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorFileManager.Features.FileManagement.Components
{
    public partial class DataElementPreviewer : ComponentBase
    {
        [CascadingParameter]
        public FileManagerState FileManagerState { get; set; } = default!;

        private readonly string[] AvailableTextFormats = new string[] { ".txt" };

        private readonly string[] AvailableImageFormats = new string[] { ".bmp", ".jpg", ".jpeg", ".png" };

        private byte[] FileContent = {};

        private FileFormatType FileFormatType;

        private bool Visible;

        protected override void OnInitialized()
        {
            FileManagerState.OnPreviewDataElementRequested += ShowPreview;
            FileManagerState.OnDataElementUnSelected += HidePreview;
        }

        private void ShowPreview(Element element)
        {
            if (!element.Type.Equals(DataElementType.FILE))
            {
                HidePreview();
                return;
            }

            // Load file meta data with FileInfo
            var fileInfo = new System.IO.FileInfo(element.Path);

            if (AvailableTextFormats.Any(x => fileInfo.Extension.Contains(x)))
                FileFormatType = FileFormatType.TEXT;

            else if (AvailableImageFormats.Any(x => fileInfo.Extension.Contains(x)))
                FileFormatType = FileFormatType.IMAGE;

            else
            {
                HidePreview();
                return;
            }

            FileContent = ReadFile(fileInfo);
            Visible = true;
            StateHasChanged();
        }

        private void HidePreview()
        {
            Visible = false;
            StateHasChanged();
        }

        private byte[] ReadFile(System.IO.FileInfo fileInfo)
        {
            // The byte[] to save the data in
            var data = new byte[fileInfo.Length];

            // Load a filestream and put its content into the byte[]
            using FileStream fileStream = fileInfo.OpenRead();
            fileStream.Read(data, 0, data.Length);

            // TODO Access failed exception
            // TODO May be in used
            // TODO Delete the temporary file
            // fileInfo.Delete();

            return data;
        }
    }
}
