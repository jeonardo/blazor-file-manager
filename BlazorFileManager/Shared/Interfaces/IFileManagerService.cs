
using BlazorFileManager.Shared.Models;

namespace BlazorFileManager.Shared.Interfaces
{
    public interface IFileManagerService
    {
        DirectoryContent GetDirectoryContent(string path);

        void CreateDirectory(string path);

        void DeleteDataElement(Element element);

        void OpenFile(string path);
    }
}
