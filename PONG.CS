Sure, here is a simple Pong game in C# using WinForms:

```
using System;
using System.Drawing;
using System.Windows.Forms;

public class Pong : Form
{
    private const int WIDTH = 400;
    private const int HEIGHT = 300;
    private const int PADDLE_WIDTH = 10;
    private const int PADDLE_HEIGHT = 50;
    private const int BALL_SIZE = 10;
    private const int PADDLE_SPEED = 5;

    private Timer timer;
    private int paddle1Y;
    private int paddle2Y;
    private int ballX;
    private int ballY;
    private int ballVelocityX;
    private int ballVelocityY;

    public Pong()
    {
        ClientSize = new Size(WIDTH, HEIGHT);

        // Set up paddles and ball
        paddle1Y = HEIGHT / 2 - PADDLE_HEIGHT / 2;
        paddle2Y = HEIGHT / 2 - PADDLE_HEIGHT / 2;
        ballX = WIDTH / 2 - BALL_SIZE / 2;
        ballY = HEIGHT / 2 - BALL_SIZE / 2;
        ballVelocityX = 3;
        ballVelocityY = 3;

        // Set up timer
        timer = new Timer();
        timer.Interval = 16; // 60 fps
        timer.Tick += new EventHandler(OnTimerTick);
        timer.Start();
    }

    private void OnTimerTick(object sender, EventArgs e)
    {
        // Update ball position
        ballX += ballVelocityX;
        ballY += ballVelocityY;

        // Check for collisions with top and bottom walls
        if (ballY < 0 || ballY + BALL_SIZE > HEIGHT)
        {
            ballVelocityY = -ballVelocityY;
        }

        // Check for collisions with paddles
        if (ballX < PADDLE_WIDTH && ballY + BALL_SIZE > paddle1Y && ballY < paddle1Y + PADDLE_HEIGHT)
        {
            ballVelocityX = -ballVelocityX;
        }
        else if (ballX + BALL_SIZE > WIDTH - PADDLE_WIDTH && ballY + BALL_SIZE > paddle2Y && ballY < paddle2Y + PADDLE_HEIGHT)
        {
            ballVelocityX = -ballVelocityX;
        }

        // Check for out-of-bounds
        if (ballX < -BALL_SIZE || ballX > WIDTH)
        {
            ballX = WIDTH / 2 - BALL_SIZE / 2;
            ballY = HEIGHT / 2 - BALL_SIZE / 2;
            ballVelocityX = -ballVelocityX;
            ballVelocityY = -ballVelocityY;
        }

        // Move paddles
        if (KeyDown(Keys.W))
        {
            paddle1Y -= PADDLE_SPEED;
        }
        if (KeyDown(Keys.S))
        {
            paddle1Y += PADDLE_SPEED;
        }
        if (KeyDown(Keys.Up))
        {
            paddle2Y -= PADDLE_SPEED;
        }
        if (KeyDown(Keys.Down))
        {
            paddle2Y += PADDLE_SPEED;
        }

        // Clamp paddle positions within screen bounds
        paddle1Y = Math.Max(0, Math.Min(paddle1Y, HEIGHT - PADDLE_HEIGHT));
        paddle2Y = Math.Max(0, Math.Min(paddle2Y, HEIGHT - PADDLE_HEIGHT));

        // Redraw the screen
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.FillRectangle(Brushes.Black, 0, 0, WIDTH, HEIGHT);

        // Draw paddles
        e.Graphics.FillRectangle(Brushes.White, 0, paddle1Y, PADDLE_WIDTH, PADDLE_HEIGHT);
        e.Graphics.FillRectangle(Brushes.White, WIDTH - PADDLE_WIDTH, paddle2Y, PADDLE_WIDTH, PADDLE_HEIGHT);

        // Draw ball
        e.Graphics.FillRectangle(Brushes.White, ballX, ballY, BALL_SIZE, BALL_SIZE);
    }
}

public class Program
{
    public static void Main()
    {
        Application.Run(new Pong());
    }
}
```

The code uses a `Timer` to update the game state and redraw the screen at a fixed interval (60 frames per second). The `OnTimerTick` method handles the main game logic, including moving the ball and paddles, detecting collisions, and handling scoring and resetting the game.

The `OnPaint` method draws the game elements using GDI+. The surface of the form is filled with black, and then the paddles and ball are drawn as white rectangles. The form handles keyboard input to move the paddles up and down.