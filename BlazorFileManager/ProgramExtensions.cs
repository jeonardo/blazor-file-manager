using BlazorFileManager.Services;
using BlazorFileManager.Shared.Interfaces;

namespace BlazorFileManager
{
    public static class ProgramExtensions
    {
        public static void AddFileManagerFeature(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IFileManagerService, FileManagerService>();
        }
    }
}
