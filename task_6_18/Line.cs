using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_6_18
{
    public class Line
    {
        Point point1;
        Point point2;
        public Line(Point point1, Point point2)
        {
            this.point1 = point1;
            this.point2 = point2;
        }
        public void SetLine(Point point1, Point point2)
        {
            this.point1 = point1; 
            this.point2 = point2;
        }
    }
}
