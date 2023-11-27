namespace BlazorFileManager.Features.FileManagement.Components
{
    public partial class DirectoryViewer : ComponentBase
    {
        [CascadingParameter]
        public FileManagerState FileManagerState { get; set; } = default!;

        private readonly Element ReturnElement = new(DataElementType.RETURN, "\\Вернуться");
    }
}
