Here's an example of a simple Rubik's Cube game in C# using WinForms and GDI+:

```
using System;
using System.Drawing;
using System.Windows.Forms;

public class RubiksCube : Form
{
    private const int WIDTH = 640;
    private const int HEIGHT = 480;
    private const int BLOCK_SIZE = 50;
    private const int CUBE_SIZE = 3;
    private const int ANGLE = 30;

    private Timer timer;
    private RubikBlock[,,] blocks;
    private Random rand;

    public RubiksCube()
    {
        ClientSize = new Size(WIDTH, HEIGHT);
        BackColor = Color.Black;

        // Set up initial game state
        blocks = new RubikBlock[CUBE_SIZE, CUBE_SIZE, CUBE_SIZE];
        for (int i = 0; i < CUBE_SIZE; i++)
        {
            for (int j = 0; j < CUBE_SIZE; j++)
            {
                for (int k = 0; k < CUBE_SIZE; k++)
                {
                    Color[] colors = new Color[6];
                    colors[0] = Color.White;
                    colors[1] = Color.Yellow;
                    colors[2] = Color.Red;
                    colors[3] = Color.Orange;
                    colors[4] = Color.Blue;
                    colors[5] = Color.Green;
                    blocks[i, j, k] = new RubikBlock(i, j, k, BLOCK_SIZE, colors);
                }
            }
        }
        rand = new Random();

        // Set up timer
        timer = new Timer();
        timer.Interval = 16; // 60 fps
        timer.Tick += new EventHandler(OnTimerTick);
        timer.Start();
    }

    private void OnTimerTick(object sender, EventArgs e)
    {
        // Randomly rotate a layer of the cube
        int direction = rand.Next(2) * 2 - 1;
        int layer = rand.Next(CUBE_SIZE);
        for (int i = 0; i < CUBE_SIZE; i++)
        {
            for (int j = 0; j < CUBE_SIZE; j++)
            {
                if (layer == 0)
                {
                    RotateBlock(i, j, direction * ANGLE);
                }
                else if (layer == 1)
                {
                    RotateBlock(i, direction * ANGLE, j);
                }
                else if (layer == 2)
                {
                    RotateBlock(direction * ANGLE, i, j);
                }
            }
        }

        // Redraw the screen
        Invalidate();
    }

    private void RotateBlock(float angleX, float angleY, float angleZ)
    {
        // Rotate the entire cube around the specified axis angles
        for (int i = 0; i < CUBE_SIZE; i++)
        {
            for (int j = 0; j < CUBE_SIZE; j++)
            {
                for (int k = 0; k < CUBE_SIZE; k++)
                {
                    blocks[i, j, k].Rotate(angleX, angleY, angleZ);
                }
            }
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Set up camera and projection matrix
        Matrix4 camera = Matrix4.LookAt(new Vector3(0, 0, 5), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
        Matrix4 projection = Matrix4.Perspective(60, (float)WIDTH / HEIGHT, 0.1f, 100.0f);

        // Draw the cube blocks
        foreach (RubikBlock block in blocks)
        {
            block.Draw(e.Graphics, camera, projection);
        }
    }

    private class RubikBlock
    {
        private float x, y, z;
        private float size;
        private Color[] colors;
        private Vector3[] vertices;
        private Vector3[] transformedVertices;

        public RubikBlock(float x, float y, float z, float size, Color[] colors)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.size = size;
            this.colors = colors;

            // Define the 8 vertices of the block
            vertices = new Vector3[]
            {
                new Vector3(-size / 2, -size / 2, size / 2),
                new Vector3(size / 2, -size / 2, size / 2),
                new Vector3(size / 2, size / 2, size / 2),
                new Vector3(-size / 2, size / 2, size / 2),
                new Vector3(-size / 2, -size / 2, -size / 2),
                new Vector3(size / 2, -size / 2, -size / 2),
                new Vector3(size / 2, size / 2, -size / 2),
                new Vector3(-size / 2, size / 2, -size / 2),
            };

            // Initialize the transformed vertices (same as vertices by default)
            transformedVertices = new Vector3[8];
            for (int i = 0; i < 8; i++)
            {
                transformedVertices[i] = vertices[i];
            }
        }

        public void Rotate(float angleX, float angleY, float angleZ)
        {
            // Rotate the block around the X, Y, and Z axes
            Matrix4 rotationX = Matrix4.RotateX(angleX);
            Matrix4 rotationY = Matrix4.RotateY(angleY);
            Matrix4 rotationZ = Matrix4.RotateZ(angleZ);
            Matrix4 rotation = rotationX * rotationY * rotationZ;

            // Update the transformed vertices
            for (int i = 0; i < 8; i++)
            {
                transformedVertices[i] = rotation * vertices[i] + new Vector3(x, y, z);
            }
        }

        public void Draw(Graphics g, Matrix4 camera, Matrix4 projection)
        {
            // Compute the transformed vertices in camera and projection space
            Vector3[] transformedVerticesCamera = new Vector3[8];
            Vector3[] transformedVerticesProjection = new Vector3[8];
            for (int i = 0; i < 8; i++)
            {
                transformedVerticesCamera[i] = camera * transformedVertices[i];
                transformedVerticesProjection[i] = projection * transformedVerticesCamera[i];
            }

            // Compute the screen coordinates and depth of each vertex
            Point[] points = new Point[8];
            float[] depths = new float[8];
            for (int i = 0; i < 8; i++)
            {
                points[i] = new Point((int)(WIDTH / 2 + transformedVerticesProjection[i].X), (int)(HEIGHT / 2 - transformedVerticesProjection[i].Y));
                depths[i] = transformedVerticesProjection[i].Z;
            }

            // Compute the average depth of the block
            float depth = 0.0f;
            for (int i = 0; i < 8; i++)
            {
                depth += depths[i];
            }
            depth /= 8;

            // Compute the colors of each face of the block
            Color[] faceColors = new Color[6];
            faceColors[0] = colors[0]; // up
            faceColors[1] = colors[1]; // down
            faceColors[2] = colors[2]; // front
            faceColors[3] = colors[3]; // back
            faceColors[4] = colors[4]; // left
            faceColors[5] = colors[5]; // right

            // Sort the vertices by depth in ascending order
            Array.Sort(depths, points);

            // Draw the faces of the block in sorted order
            for (int i = 0; i < 6; i++)
            {
                int index1 = i * 4;
                int index2 = i * 4 + 1;
                int index3 = i * 4 + 2;
                int index4 = i * 4 + 3;

                Color color = faceColors[i];

                Point[] face = new Point[] { points[index1], points[index2], points[index3], points[index4] };
                g.FillPolygon(new SolidBrush(color), face);
                g.DrawPolygon(Pens.Black, face);
            }
        }
    }

    private struct Vector3
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector3 operator *(Matrix4 m, Vector3 v)
        {
            float x = m.M11 * v.X + m.M21 * v.Y + m.M31 * v.Z + m.M41;
            float y = m.M12 * v.X + m.M22 * v.Y + m.M32 * v.Z + m.M42;
            float z = m.M13 * v.X + m.M23 * v.Y + m.M33 * v.Z + m.M43;
            return new Vector3(x, y, z);
        }
    }

    private struct Matrix4
    {
        public float M11, M12, M13, M14;
        public float M21, M22, M23, M24;
        public float M31, M32, M33, M34;
        public float M41, M42, M43, M44;

        public static Matrix4 LookAt(Vector3 eye, Vector3 target, Vector3 up)
        {
            Vector3 zAxis = (target - eye).Normalized();
            Vector3 xAxis = up.Cross(zAxis).Normalized();
            Vector3 yAxis = zAxis.Cross(xAxis).Normalized();

            Matrix4 view = new Matrix4();
            view.M11 = xAxis.X;
            view.M12 = yAxis.X;
            view.M13 = zAxis.X;
            view.M14 = 0.0f;
            view.M21 = xAxis.Y;
            view.M22 = yAxis.Y;
            view.M23 = zAxis.Y;
            view.M24 = 0.0f;
            view.M31 = xAxis.Z;
            view.M32 = yAxis.Z;
            view.M33 = zAxis.Z;
            view.M34 = 0.0f;
            view.M41 = -xAxis.Dot(eye);
            view.M42 = -yAxis.Dot(eye);
            view.M43 = -zAxis.Dot(eye);
            view.M44 = 1.0f;
            return view;
        }

        public static Matrix4 Perspective(float fovY, float aspect, float near, float far)
        {
            float f = 1.0f / (float)Math.Tan(fovY / 2.0f);
            float m22 = (far + near) / (near - far);
            float m32 = (2.0f * far * near) / (near - far);

            Matrix4 projection = new Matrix4();
            projection.M11 = f / aspect;
            projection.M22 = f;
            projection.M33 = m22;
            projection.M34 = -1.0f;
            projection.M43 = m32;
            projection.M44 = 0.0f;
            return projection;
        }

        public static Matrix4 RotateX(float angle)
        {
            float sin = (float)Math.Sin(angle);
            float cos = (float)Math.Cos(angle);
            Matrix4 matrix = new Matrix4();
            matrix.M11 = 1.0f;
            matrix.M22 = cos;
            matrix.M23 = -sin;
            matrix.M32 = sin;
            matrix.M33 = cos;
            matrix.M44 = 1.0f;
            return matrix;
        }

        public static Matrix4 RotateY(float angle)
        {
            float sin = (float)Math.Sin(angle);
            float cos = (float)Math.Cos(angle);
            Matrix4 matrix = new Matrix4();
            matrix.M11 = cos;
            matrix.M13 = sin;
            matrix.M22 = 1.0f;
            matrix.M31 = -sin;
            matrix.M33 = cos;
            matrix.M44 = 1.0f;
            return matrix;
        }

        public static Matrix4 RotateZ(float angle)
        {
            float sin = (float)Math.Sin(angle);
            float cos = (float)Math.Cos(angle);
            Matrix4 matrix = new Matrix4();
            matrix.M11 = cos;
            matrix.M12 = -sin;
            matrix.M21 = sin;
            matrix.M22 = cos;
            matrix.M33 = 1.0f;
            matrix.M44 = 1.0f;
            return matrix;
        }

        public static Matrix4 operator *(Matrix4 a, Matrix4 b)
        {
            Matrix4 matrix = new Matrix4();
            matrix.M11 = a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41;
            matrix.M12 = a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42;
            matrix.M13 = a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43;
            matrix.M14 = a.M11 * b.M14 + a.M12 * b.M24 + a.M13 * b.M34 + a.M14 * b.M44;
            matrix.M21 = a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41;
            matrix.M22 = a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42;
            matrix.M23 = a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43;
            matrix.M24 = a.M21 * b.M14 + a.M22 * b.M24 + a.M23 * b.M34 + a.M24 * b.M44;
            matrix.M31 = a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41;
            matrix.M32 = a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42;
            matrix.M33 = a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33 + a.M34 * b.M43;
            matrix.M34 = a.M31 * b.M14 + a.M32 * b.M24 + a.M33 * b.M34 + a.M34 * b.M44;
            matrix.M41 = a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41;
            matrix.M42 = a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42;
            matrix.M43 = a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33 + a.M44 * b.M43;
            matrix.M44 = a.M41 * b.M14 + a.M42 * b.M24 + a.M43 * b.M34 + a.M44 * b.M44;
            return matrix;
        }
    }
}

public class Program
{
    public static void Main()
    {
        Application.Run(new RubiksCube());
    }
}
```

The code uses a `Timer` to randomly rotate a layer of the Rubik's Cube and redraw the screen at a fixed interval (60 frames per second). The code defines several classes to represent the Rubik's Cube blocks, including their position, size, colors, and current orientation. The game logic includes rotating the blocks around the X, Y, and Z axes to simulate a complete Rubik's Cube rotation.

The `OnPaint` method draws the Rubik's Cube blocks using GDI+. The block rotation is computed using a rotation matrix, and the resulting transformed vertices are projected onto the 2D screen using a perspective projection matrix. The 3D-to-2D transformation is performed using a custom `Vector3` and `Matrix4` class for convenience.