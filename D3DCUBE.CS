Here's an example of how to create a simple 3D cube in C# using WinForms and GDI+:

```
using System;
using System.Drawing;
using System.Windows.Forms;

public class Cube : Form
{
    private const int WIDTH = 640;
    private const int HEIGHT = 480;
    private const int CUBE_SIZE = 100;
    private const double ANGLE = Math.PI / 4; // 45 degrees

    private Timer timer;
    private double cubeAngleX;
    private double cubeAngleY;

    public Cube()
    {
        ClientSize = new Size(WIDTH, HEIGHT);
        BackColor = Color.Black;

        // Set up initial cube rotation angles
        cubeAngleX = Math.PI / 4;
        cubeAngleY = Math.PI / 4;

        // Set up timer
        timer = new Timer();
        timer.Interval = 16; // 60 fps
        timer.Tick += new EventHandler(OnTimerTick);
        timer.Start();
    }

    private void OnTimerTick(object sender, EventArgs e)
    {
        // Update the cube rotation angles
        cubeAngleX += ANGLE / 60; // rotate 1 degree per frame
        cubeAngleY += ANGLE * 2 / 60; // rotate 2 degrees per frame

        // Redraw the screen
        Invalidate();
    }

    private Point3D[] GetCubeVertices()
    {
        // Define the 8 vertices of the cube
        Point3D[] vertices = new Point3D[8];
        vertices[0] = new Point3D(-CUBE_SIZE, -CUBE_SIZE, -CUBE_SIZE);
        vertices[1] = new Point3D(CUBE_SIZE, -CUBE_SIZE, -CUBE_SIZE);
        vertices[2] = new Point3D(CUBE_SIZE, CUBE_SIZE, -CUBE_SIZE);
        vertices[3] = new Point3D(-CUBE_SIZE, CUBE_SIZE, -CUBE_SIZE);
        vertices[4] = new Point3D(-CUBE_SIZE, -CUBE_SIZE, CUBE_SIZE);
        vertices[5] = new Point3D(CUBE_SIZE, -CUBE_SIZE, CUBE_SIZE);
        vertices[6] = new Point3D(CUBE_SIZE, CUBE_SIZE, CUBE_SIZE);
        vertices[7] = new Point3D(-CUBE_SIZE, CUBE_SIZE, CUBE_SIZE);

        // Rotate the vertices around the X axis
        for (int i = 0; i < vertices.Length; i++)
        {
            double y = vertices[i].Y * Math.Cos(cubeAngleX) - vertices[i].Z * Math.Sin(cubeAngleX);
            double z = vertices[i].Y * Math.Sin(cubeAngleX) + vertices[i].Z * Math.Cos(cubeAngleX);
            vertices[i].Y = y;
            vertices[i].Z = z;
        }

        // Rotate the vertices around the Y axis
        for (int i = 0; i < vertices.Length; i++)
        {
            double x = vertices[i].X * Math.Cos(cubeAngleY) + vertices[i].Z * Math.Sin(cubeAngleY);
            double z = -vertices[i].X * Math.Sin(cubeAngleY) + vertices[i].Z * Math.Cos(cubeAngleY);
            vertices[i].X = x;
            vertices[i].Z = z;
        }

        return vertices;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Point3D[] vertices = GetCubeVertices();

        // Project the vertices onto the 2D screen plane
        Point[] points = new Point[8];
        for (int i = 0; i < vertices.Length; i++)
        {
            points[i] = new Point((int)(WIDTH / 2 + vertices[i].X), (int)(HEIGHT / 2 + vertices[i].Y));
        }

        // Draw the cube
        e.Graphics.DrawLines(Pens.White, new Point[] { points[0], points[1], points[2], points[3], points[0] });
        e.Graphics.DrawLines(Pens.White, new Point[] { points[4], points[5], points[6], points[7], points[4] });
        e.Graphics.DrawLine(Pens.White, points[0], points[4]);
        e.Graphics.DrawLine(Pens.White, points[1], points[5]);
        e.Graphics.DrawLine(Pens.White, points[2], points[6]);
        e.Graphics.DrawLine(Pens.White, points[3], points[7]);
    }

    private class Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}

public class Program
{
    public static void Main()
    {
        Application.Run(new Cube());
    }
}
```

The code uses a `Timer` to update the rotation angles of the cube and redraw the screen at a fixed interval (60 frames per second). The `GetCubeVertices` method computes the 8 vertices of the cube based on the current rotation angles and then projects them onto the 2D screen plane using a simple perspective projection.

The `OnPaint` method draws the cube using GDI+. The cube is represented as a set of lines connecting the vertices. The `Point3D` class is a simple convenience class to store the X, Y, and Z coordinates of a point in 3D space.