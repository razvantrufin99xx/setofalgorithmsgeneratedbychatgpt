Sure, here is a simple Snake game in C# using WinForms:

```
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

public class SnakeGame : Form
{
    private const int WIDTH = 400;
    private const int HEIGHT = 400;
    private const int CELL_SIZE = 10;

    private Timer timer;
    private List<Point> snake;
    private Point food;
    private Random rand;
    private int direction;

    public SnakeGame()
    {
        ClientSize = new Size(WIDTH, HEIGHT);
        KeyPreview = true;
        rand = new Random();

        // Set up initial game state
        snake = new List<Point>()
        {
            new Point(WIDTH / 2, HEIGHT / 2),
            new Point(WIDTH / 2, HEIGHT / 2 + CELL_SIZE),
            new Point(WIDTH / 2, HEIGHT / 2 + CELL_SIZE * 2),
        };
        food = GenerateFood();
        direction = -1;

        // Set up timer
        timer = new Timer();
        timer.Interval = 100; // 10 fps
        timer.Tick += new EventHandler(OnTimerTick);
        timer.Start();
    }

    private void OnTimerTick(object sender, EventArgs e)
    {
        // Move the snake in the current direction
        Point head = snake[0];
        switch (direction)
        {
            case 0:
                head.Y -= CELL_SIZE;
                break;
            case 1:
                head.X += CELL_SIZE;
                break;
            case 2:
                head.Y += CELL_SIZE;
                break;
            case 3:
                head.X -= CELL_SIZE;
                break;
        }

        // Check for out-of-bounds or self-collision
        if (head.X < 0 || head.X >= WIDTH || head.Y < 0 || head.Y >= HEIGHT || snake.Contains(head))
        {
            MessageBox.Show("Game over!");
            Application.Exit();
        }

        // Move the rest of the snake
        for (int i = snake.Count - 1; i > 0; i--)
        {
            snake[i] = snake[i - 1];
        }
        snake[0] = head;

        // Check for food collision
        if (head == food)
        {
            // Add a new segment to the snake
            snake.Add(snake[snake.Count - 1]);

            // Generate a new food location
            food = GenerateFood();
        }

        // Redraw the screen
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.FillRectangle(Brushes.Black, 0, 0, WIDTH, HEIGHT);

        // Draw the snake
        foreach (Point p in snake)
        {
            e.Graphics.FillRectangle(Brushes.White, p.X, p.Y, CELL_SIZE, CELL_SIZE);
        }

        // Draw the food
        e.Graphics.FillEllipse(Brushes.Red, food.X, food.Y, CELL_SIZE, CELL_SIZE);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        // Set the new direction based on the arrow key pressed
        switch (e.KeyCode)
        {
            case Keys.Up:
                if (direction != 2)
                {
                    direction = 0;
                }
                break;
            case Keys.Right:
                if (direction != 3)
                {
                    direction = 1;
                }
                break;
            case Keys.Down:
                if (direction != 0)
                {
                    direction = 2;
                }
                break;
            case Keys.Left:
                if (direction != 1)
                {
                    direction = 3;
                }
                break;
        }
    }

    private Point GenerateFood()
    {
        // Generate a random location for the food that is not occupied by the snake
        Point food;
        bool occupied;
        do
        {
            int x = rand.Next(0, WIDTH / CELL_SIZE) * CELL_SIZE;
            int y = rand.Next(0, HEIGHT / CELL_SIZE) * CELL_SIZE;
            food = new Point(x, y);
            occupied = snake.Contains(food);
        } while (occupied);

        return food;
    }
}

public class Program
{
    public static void Main()
    {
        Application.Run(new SnakeGame());
    }
}
```

The code uses a `Timer` to update the game state and redraw the screen at a fixed interval (10 frames per second). The `OnTimerTick` method handles the main game logic, including moving the snake, checking for collisions with the walls and food, and generating new food when eaten.

The `OnPaint` method draws the game elements using GDI+. The surface of the form is filled with black, and then the snake and food are drawn as white rectangles or red ellipses, respectively. The form handles keyboard input to change the snake's direction.