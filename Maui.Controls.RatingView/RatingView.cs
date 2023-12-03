using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.GTKSpecific;
using Microsoft.Maui.Graphics;
using System;
using System.Runtime.InteropServices;

namespace Maui.Controls.RatingView;

public class RatingView : ContentView
{
    public static readonly BindableProperty StarCountFilledProperty =
            BindableProperty.Create(nameof(StarCountFilled), typeof(Int32), typeof(RatingView), 0);

    public Int32 StarCountFilled
    {
        get => (Int32)GetValue(StarCountFilledProperty);
        set => SetValue(StarCountFilledProperty, value);
    }

    public static readonly BindableProperty StarColorProperty =
        BindableProperty.Create(nameof(StarColor), typeof(Color), typeof(RatingView), Colors.Yellow);

    public Color StarColor
    {
        get => (Color)GetValue(StarColorProperty);
        set => SetValue(StarColorProperty, value);
    }

    private readonly GraphicsView graphicsView;

    public RatingView()
    {
        graphicsView = new GraphicsView
        {
            Drawable = new StarsDrawable(this),
            WidthRequest = 200,
            HeightRequest = 80,
        };

        graphicsView.InputTransparent = true;

        var gestureRecognizer = new TapGestureRecognizer();
        gestureRecognizer.Tapped += OnTap;

        Content = new StackLayout
        {
            Children = { graphicsView }
        };

        GestureRecognizers.Add(gestureRecognizer);
    }

    private void OnTap(object sender, TappedEventArgs e)
    {
        Point tapPosition = (Point)e.GetPosition(graphicsView);

        this.StarCountFilled = GetStarNumber(graphicsView.Width, tapPosition);

        graphicsView.Invalidate();

        Tapped?.Invoke(this, EventArgs.Empty);
    }

    public int GetStarNumber(double width, Point tapPosition)
    {
        int starNumber = 0;

        float starSize = (float)(width / 5);
        starNumber = (int)(tapPosition.X / starSize) + 1;
        starNumber = Math.Max(1, Math.Min(5, starNumber));

        return starNumber;
    }

    public event EventHandler Tapped;
}


