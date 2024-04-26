using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace DotNetBankingAppClient.Components;

public class CarouselLogic : ComponentBase
{
    [Inject]
    public IAppLogger Logger { get; set; } = default!;

    [Parameter]
    public required Action<int> OnChange { get; set; }

    [Parameter]
    public required int Value { get; set; } = 0;

    [Parameter]
    public int? Gap { get; set; } = 20;

    [Parameter]
    public string? Classes { get; set; }

    [Parameter]
    public int ItemWidth { get; set; } = 300;

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    private double? _xDown;
    private double? _yDown;


    private void HandleInteractionStart(double posX, double posY)
    {
        _xDown = posX;
        _yDown = posY;
    }

    private void HandleInteractionEnd(double posX, double posY)
    {
        if (OnChange == null)
        {
            return;
        }

        if (_xDown == null || _yDown == null)
        {
            return;
        }

        var xDiff = _xDown.Value - posX;
        var yDiff = _yDown.Value - posY;

        if (Math.Abs(xDiff) < 100 && Math.Abs(yDiff) < 100)
        {
            _xDown = null;
            _yDown = null;
            return;
        }

        if (Math.Abs(xDiff) > Math.Abs(yDiff))
        {
            if (xDiff > 0)
            {
                Logger.Log("Swipe left");
                OnChange(Value + 1);

                //InvokeAsync(() => OnSwipe(SwipeDirection.RightToLeft));
            }
            else
            {
                Logger.Log("Swipe right");
                OnChange(Value - 1);

                //InvokeAsync(() => OnSwipe(SwipeDirection.LeftToRight));
            }
        }
        else
        {
            if (yDiff > 0)
            {
                Logger.Log("Swipe up");
                //InvokeAsync(() => OnSwipe(SwipeDirection.BottomToTop));
            }
            else
            {
                Logger.Log("Swipe down");

                //InvokeAsync(() => OnSwipe(SwipeDirection.TopToBottom));
            }
        }

        _xDown = null;
        _yDown = null;
    }

    public void OnTouchStart(TouchEventArgs args)
    {
        HandleInteractionStart(args.Touches[0].ClientX, args.Touches[0].ClientY);
    }

    public void OnTouchEnd(TouchEventArgs args)
    {
        HandleInteractionEnd(args.ChangedTouches[0].ClientX, args.ChangedTouches[0].ClientY);

    }

    public void OnTouchCancel(TouchEventArgs args)
    {
        _xDown = null;
        _yDown = null;
    }

    public void OnMouseStart(MouseEventArgs args)
    {
        HandleInteractionStart(args.ClientX, args.ClientY);
    }

    public void OnMouseEnd(MouseEventArgs args)
    {
        HandleInteractionEnd(args.ClientX, args.ClientY);

    }

    public float CalculateHorizontalTranslation()
    {
        int gapValue = (Value * (Gap ?? 0));

        int itemValue = Value * ItemWidth;

        return -itemValue - gapValue;
    }
}