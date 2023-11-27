using BlazorFileManager.Shared.Enums;
using BlazorFileManager.Shared.Interfaces;
using BlazorFileManager.Shared.Models;

namespace BlazorFileManager.Services
{
    public class FileManagerService : IFileManagerService
    {
        public DirectoryContent GetDirectoryContent(string path) => new()
        {
            Folders = Directory
                    .GetDirectories(path)
                    .Where(x => !new DirectoryInfo(x).Attributes.HasFlag(FileAttributes.Hidden))
                    .ToList(),
            Files = Directory
                    .GetFiles(path)
                    .ToList()
        };

        public void CreateDirectory(string path)
        {
            if (Directory.Exists(path))
                return;
           
            _ = Directory.CreateDirectory(path);
        }

        public void OpenFile(string path)
        {
            _ = System.Diagnostics.Process.Start("cmd.exe", $"/c {path}");
        }

        public void DeleteDataElement(Element element)
        {
            if (element.Type == DataElementType.FOLDER)
            {
                if (!Directory.Exists(element.Path))
                    return;

                Directory.Delete(element.Path, true);
            }
            else if (element.Type == DataElementType.FILE)
            {
                if (!File.Exists(element.Path))
                    return;

                File.Delete(element.Path);
            }
        }
    }
}
