using BlazorFileManager.Shared.Enums;
using Microsoft.AspNetCore.Components;

namespace BlazorFileManager.Features.FileManagement.Components
{
    public partial class DataElement : ComponentBase
    {
        [CascadingParameter]
        public FileManagerState FileManagerState { get; set; } = default!;
        
        [Parameter, EditorRequired]
        public Element Element { get; set; } = default!;

        private string ElementName => Element.Path.Substring(Element.Path.LastIndexOf("\\") + 1);

        private bool Active;

        protected override void OnInitialized()
        {
            FileManagerState.OnDataElementSelected += HandleAnotherDataElementActivation;
        }

        private void HandleClick()
        {
            Active = !Active;
            FileManagerState.SelectDataElement(Element);
        }

        private void HandleDoubleClick()
        {
            Active = false;
            FileManagerState.OpenDataElement(Element);
        }

        private void HandleAnotherDataElementActivation(Element element)
        {
            if (Element.Path != element.Path || Element.Type != element.Type)
            {
                Active = false;
                StateHasChanged();
            }
        }
    }
}
