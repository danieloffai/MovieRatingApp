using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Controls.RatingView
{

    public class StarsDrawable : IDrawable
    {
        private readonly RatingView ratingView;

        public StarsDrawable(RatingView ratingView)
        {
            this.ratingView = ratingView ?? throw new ArgumentNullException(nameof(ratingView));
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            float starSize = dirtyRect.Width / 5;

            for (int i = 0; i < 5; i++)
            {
                float startX = i * starSize + (starSize / 2);
                float centerY = dirtyRect.Height / 2;
                float outerRadius = starSize / 2;
                float innerRadius = outerRadius / 2;
                float rotation = 2.256637f;

                PathF starPath = new PathF();

                for (int j = 0; j < 5; j++)
                {
                    float angle = (float)(j * 2 * Math.PI / 5);

                    float outerX = startX + (float)(Math.Cos(angle + rotation) * outerRadius);
                    float outerY = centerY + (float)(Math.Sin(angle + rotation) * outerRadius);
                    float innerX = startX + (float)(Math.Cos(angle + rotation + Math.PI / 5) * innerRadius);
                    float innerY = centerY + (float)(Math.Sin(angle + rotation + Math.PI / 5) * innerRadius);

                    if (j == 0)
                        starPath.MoveTo(outerX, outerY);
                    else
                        starPath.LineTo(outerX, outerY);

                    starPath.LineTo(innerX, innerY);
                }

                starPath.Close();

                if (this.ratingView.StarCountFilled >= 1 && i + 1 <= this.ratingView.StarCountFilled)
                {
                    canvas.FillColor = this.ratingView.StarColor;
                    canvas.FillPath(starPath);
                }
                else
                {
                    canvas.FillColor = Colors.Transparent;
                    canvas.FillPath(starPath);
                }

                canvas.StrokeColor = Colors.Black;
                canvas.StrokeSize = 2;

                canvas.DrawPath(starPath);
            }
        }
    }

}
