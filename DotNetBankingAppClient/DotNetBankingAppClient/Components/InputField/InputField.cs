using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Components;

public class InputFieldLogic : ComponentBase
{
    [Parameter]
    public string? classes { get; set; }
    [Parameter]
    public string value { get; set; } = "";
    [Parameter]
    public string placeholder { get; set; } = "";
    [Parameter]
    public Action<string>? onChange { get; set; }

    public void HandleValueChanged(ChangeEventArgs e)
    {
        string newValue = e?.Value?.ToString() ?? "";
        if (onChange != null)
        {
            onChange(newValue);
        }
    }
}