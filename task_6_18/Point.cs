using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_6_18
{
    public class Point
    {
        private static int _counter;

        private readonly int _instanceId = _counter++;

        public double X { get; set; }
        public double Y { get; set; }
        public HashSet<Triangle> AdjacentTriangles { get; set; } = new HashSet<Triangle>();

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Point() { }
        public override string ToString()
        {
            return $"{nameof(Point)} {_instanceId} {X:0.##}@{Y:0.##}";
        }
    }
}
