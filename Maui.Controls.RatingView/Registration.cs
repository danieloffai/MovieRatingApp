using Microsoft.Maui.Handlers;

namespace Maui.Controls.RatingView
{
    public static class Registration
    {
        public static MauiAppBuilder UseRatingView(this MauiAppBuilder builder)
        {
            builder.ConfigureMauiHandlers(h =>
            {
                h.AddHandler<RatingView, ContentViewHandler>();
            });

            return builder;
        }
    }
}
