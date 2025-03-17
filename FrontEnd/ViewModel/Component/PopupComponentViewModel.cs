using Blazing.Mvvm.ComponentModel;
using Microsoft.AspNetCore.Components;

namespace FrontEnd.ViewModel.Component
{
    public partial class PopupComponentViewModel : ViewModelBase
    {
        [ViewParameter("IsOpen")]
        public bool IsOpen { get; set; }

        [ViewParameter("Message")]
        public string Message { get; set; } = "";

        [ViewParameter("OnWindowVisibleChanged")]
        public EventCallback<bool> OnWindowVisibleChanged { get; set; }

        public async Task OnSubmit()
        {
            IsOpen = false;
            await OnWindowVisibleChanged.InvokeAsync(IsOpen);
        }
    }
}
