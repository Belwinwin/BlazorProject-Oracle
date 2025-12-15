using Microsoft.JSInterop;

namespace BlazorProject.Services.Extensions
{
    public static class IJSRuntimeExtensions
    {
        public static async Task ToastrSuccess(this IJSRuntime js,string message)
        {
            await js.InvokeVoidAsync("ShowToastr","success", message);
        }

    }
}
