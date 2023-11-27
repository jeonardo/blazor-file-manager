using BlazorFileManager.Shared.Interfaces;
using System.Reflection;

namespace BlazorFileManager.Features.FileManagement
{
    public class FileManagerState
    {
        private readonly IFileManagerService fileManagerService;

        public FileManagerState(IFileManagerService fileManagerService)
        {
            this.fileManagerService = fileManagerService;
            CurrentDirectoryContent = fileManagerService.GetDirectoryContent(CurrentDirectory);
        }

        public const string RootDirectory = "C:\\";

        public string CurrentDirectory { get; private set; } = RootDirectory;

        public DirectoryContent CurrentDirectoryContent { get; private set; } = new();

        public Element ActiveElement { get; private set; } = new();

        #region Events

        public Action<Element>? OnDataElementSelected { get; set; }

        public Action? OnDataElementUnSelected { get; set; }

        public Action<Element>? OnPreviewDataElementRequested { get; set; }

        public Action? OnDirectoryHasBeenChanged { get; set; }

        #endregion

        public void RefreshCurrentDirectoryContent() => CurrentDirectoryContent = fileManagerService.GetDirectoryContent(CurrentDirectory);
        
        public void SelectDataElement(Element element)
        {
            if (element.Path == ActiveElement.Path)
                RemoveActiveElement();
            else
                SetActiveElement(element);
        }

        public void SetActiveElement(Element element)
        {
            ActiveElement = new(element.Type, element.Path);
            OnDataElementSelected!.Invoke(element);
            OnPreviewDataElementRequested!.Invoke(element);
        }

        public void RemoveActiveElement()
        {
            ActiveElement = new();
            OnDataElementUnSelected!.Invoke();
        }

        public void CreateDirectory(string name)
        {
            fileManagerService.CreateDirectory($"{CurrentDirectory}\\{name}");
            RefreshCurrentDirectoryContent();
            OnDirectoryHasBeenChanged!.Invoke();
        }

        public void DeleteElement()
        {
            if (ActiveElement.Type.Equals(DataElementType.NONE))
                return;

            fileManagerService.DeleteDataElement(ActiveElement);
            RefreshCurrentDirectoryContent();
            OnDirectoryHasBeenChanged!.Invoke();
        }

        public void NavigateDirectory(string path)
        {
            if (path == CurrentDirectory)
                return;

            if (!path.Contains(RootDirectory))
            {
                CurrentDirectory = RootDirectory;
                RefreshCurrentDirectoryContent();
            }
            else
            {
                CurrentDirectory = path;
                RefreshCurrentDirectoryContent();
            }

            OnDirectoryHasBeenChanged!.Invoke();
        }

        public void NavigateDirectoryUp()
        {
            int index = CurrentDirectory.LastIndexOf("\\");

            if (index >= 0 && index > RootDirectory.Length - 1)
                NavigateDirectory(CurrentDirectory.Substring(0, index));
            else
                NavigateDirectory(RootDirectory);
        }

        public void OpenDataElement(Element element)
        {
            switch (element.Type)
            {
                case DataElementType.FOLDER:
                    NavigateDirectory(element.Path);
                    break;
                case DataElementType.FILE:
                    fileManagerService.OpenFile(element.Path);
                    break;
                case DataElementType.RETURN:
                    NavigateDirectoryUp();
                    break;
            }

            RemoveActiveElement();
        }
    }
}
