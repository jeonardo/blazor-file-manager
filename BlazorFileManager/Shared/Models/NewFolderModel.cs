namespace BlazorFileManager.Shared.Models
{
    public class NewFolderModel
    {
        public string Name { get; set; } = string.Empty;

        public bool ValidateName()
        {
            var invalidChars = Path.GetInvalidPathChars();
            return !string.IsNullOrWhiteSpace(Name)
                && !Name.Any(x => invalidChars.Contains(x));
        }
    }
}
