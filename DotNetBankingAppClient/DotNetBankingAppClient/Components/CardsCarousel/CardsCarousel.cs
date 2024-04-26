using DotNetBankingAppClient.Models;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace DotNetBankingAppClient.Components;

public class CardsCarouselLogic : ComponentBase
{
    [Inject]
    public IAppResponsive AppResponsive { get; set; } = default!;

    [Inject]
    public IAppLogger Logger { get; set; } = default!;
    [Parameter]
    public required Action<int> OnChange { get; set; }

    [Parameter]
    public required int SelectedCard { get; set; } = 0;

    [Parameter]
    public required List<CardDTO> Cards { get; set; } = new List<CardDTO>();

    [Parameter]
    public int? SideSpacing { get; set; } = 24;
    [Parameter]
    public int? Gap { get; set; } = 20;

    [Parameter]
    public bool? FullWidthItem { get; set; } = true;

    [Parameter]
    public string? Classes { get; set; }

    [Parameter]
    public int ItemWidth { get; set; } = 300;

    private int TotalWidth { get; set; } = 400;

    private double? _xDown;
    private double? _yDown;


    public List<CardDTO> GetCards()
    {
        return Cards ?? new List<CardDTO>();
    }

    public int GetSideSpacing()
    {
        return SideSpacing ?? 24;
    }

    public void OnTouchStart(TouchEventArgs args)
    {
        _xDown = args.Touches[0].ClientX;
        _yDown = args.Touches[0].ClientY;
    }

    public void OnTouchEnd(TouchEventArgs args)
    {
        if (OnChange == null)
        {
            return;
        }

        if (_xDown == null || _yDown == null)
        {
            return;
        }

        var xDiff = _xDown.Value - args.ChangedTouches[0].ClientX;
        var yDiff = _yDown.Value - args.ChangedTouches[0].ClientY;

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
                OnChange(SelectedCard + 1);

                //InvokeAsync(() => OnSwipe(SwipeDirection.RightToLeft));
            }
            else
            {
                Logger.Log("Swipe right");
                OnChange(SelectedCard - 1);

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

    public void OnTouchCancel(TouchEventArgs args)
    {
        _xDown = null;
        _yDown = null;
    }

    public float CalculateHorizontalTranslation()
    {
        float differenceInSpacing = (TotalWidth - ItemWidth) / 2;
        int gapValue = (SelectedCard * (Gap ?? 0));

        int itemValue = SelectedCard * ItemWidth;

        return differenceInSpacing - itemValue - gapValue;
    }

    protected override async Task OnInitializedAsync()
    {
        await AppResponsive.ListenForResponsiveChanges((ResponsiveWindowSize size, int width) =>
        {
            var space = GetSideSpacing();
            TotalWidth = width;
        });
    }
}