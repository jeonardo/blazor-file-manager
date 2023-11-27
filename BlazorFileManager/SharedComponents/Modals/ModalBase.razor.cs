using Microsoft.AspNetCore.Components;

namespace BlazorFileManager.SharedComponents.Modals
{
    public partial class ModalBase<T> : ComponentBase
    {
        [Parameter, EditorRequired]
        public Action<T> TargetAction { get; set; } = default!;

        [Parameter]
        public string ConfirmationTitle { get; set; } = string.Empty;

        [Parameter]
        public string ConfirmationMessage { get; set; } = string.Empty;

        protected bool Visible { get; set; }

        protected virtual void TargetActionInvoke(T value)
        {
            Hide();
            TargetAction.Invoke(value);
        }

        public void Show()
        {
            Visible = true;
            StateHasChanged();
        }

        public void Hide()
        {
            Visible = false;
            StateHasChanged();
        }
    }
}
