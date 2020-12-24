using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
// Триангуляция плоских фигур. Программа должна позволять вводить плоскую многосвязную фигуру, ограниченную прямыми линиями 
// или сплайнами, а затем проводить разбиение этой области на треугольники. 
// После автоматического разбиения должна быть предоставлена возможность просмотра с масштабированием и ручного редактирования триангуляции
namespace task_6_18
{
    public partial class Form1 : Form
    {
        Point[] points;
        Graphics graphics;
        DelaunayTriangulator delaunay = new DelaunayTriangulator();

        public Form1()
        {
            InitializeComponent();
        }

        public void Draw(Graphics graphics)
        {
            int n = int.Parse(textBox1.Text);
            points = new Point[n];
            string[] temp_X = textBox2.Text.Split(' ');
            string[] temp_Y = textBox3.Text.Split(' ');
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point();
                points[i].X = double.Parse(temp_X[i]);
                points[i].Y = double.Parse(temp_Y[i]);
            }

            int AmountOfTriangles = int.Parse(textBox4.Text);
            var point = delaunay.GeneratePoints(AmountOfTriangles, points);

            Figure figures = new Figure();
            var triangulation = delaunay.BowyerWatson(point);
            DrawTriangulation(triangulation);

            // figures.setRadious(AmountOfPoints);
            figures.SetColor(Color.Blue);
            figures.SetPoints(points);

            figures.DrawFigure(graphics);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            graphics = CreateGraphics();
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;
            Draw(graphics);
        }


        private void DrawTriangulation(IEnumerable<Triangle> triangulation)
        {
            var edges = new List<Edge>();
            foreach (var triangle in triangulation)
            {
                edges.Add(new Edge(triangle.Vertices[0], triangle.Vertices[1]));
                edges.Add(new Edge(triangle.Vertices[1], triangle.Vertices[2]));
                edges.Add(new Edge(triangle.Vertices[2], triangle.Vertices[0]));
            }
      
            foreach (var edge in edges)
            {    
                float X1 = (float)edge.Point1.X;
                float X2 = (float)edge.Point2.X;
                float Y1 = (float)edge.Point1.Y;
                float Y2 = (float)edge.Point2.Y;
                graphics.DrawLine(new Pen(Color.LightBlue, 2), X1, Y1, X2, Y2);
                
            }
        }
    }
}
