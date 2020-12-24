using System.Drawing;

namespace task_6_18
{
    class Figure
    {
        Point[] points;
        Color color;

        public void DrawFigure(Graphics graphics)
        {
            PointF[] pointF = new PointF[points.Length];
            
            for (int i = 0, k = 1; i < points.Length; i++, k++)
            {
                pointF[i].X = (float)points[i].X;
                pointF[i].Y = (float)points[i].Y;
                pointF[k].X = (float)points[k].X;
                pointF[k].Y = (float)points[k].Y;
                graphics.DrawLine(new Pen(color, 5), pointF[k], pointF[i]);
                if (k == points.Length - 1) k = -1;
            }
        }

        public void setColor(Color color)
        {
            this.color = color;
        }

        public void setPoints(Point[] points)
        {
            this.points = points;
        }

        public Point[] GetPoints()
        {
            return points;
        }
    }
}
