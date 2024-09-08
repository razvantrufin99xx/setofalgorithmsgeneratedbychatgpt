Sure, here is an example of a simple Alien Invader game in C# using WinForms:

```
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

public class AlienInvader : Form
{
    private const int WIDTH = 640;
    private const int HEIGHT = 480;
    private const int PLAYER_SIZE = 50;
    private const int ALIEN_SIZE = 30;
    private const int LASER_SIZE = 10;
    private const int PLAYER_SPEED = 5;
    private const int ALIEN_SPEED = 2;
    private const int LASER_SPEED = 10;
    private const int ALIEN_COLS = 8;
    private const int ALIEN_ROWS = 4;
    private const int ALIEN_SPACING = 10;

    private Timer timer;
    private List<Alien> aliens;
    private List<Laser> lasers;
    private Player player;
    private int score;
    private Random rand;

    public AlienInvader()
    {
        ClientSize = new Size(WIDTH, HEIGHT);
        KeyPreview = true;
        BackColor = Color.Black;
        DoubleBuffered = true;
        rand = new Random();

        // Set up initial game state
        aliens = new List<Alien>();
        lasers = new List<Laser>();
        score = 0;
        GenerateAliens();
        player = new Player(WIDTH / 2 - PLAYER_SIZE / 2, HEIGHT - PLAYER_SIZE - 20);

        // Set up timer
        timer = new Timer();
        timer.Interval = 16; // 60 fps
        timer.Tick += new EventHandler(OnTimerTick);
        timer.Start();
    }

    private void OnTimerTick(object sender, EventArgs e)
    {
        // Move the player
        if (KeyDown(Keys.Left))
        {
            player.X -= PLAYER_SPEED;
        }
        if (KeyDown(Keys.Right))
        {
            player.X += PLAYER_SPEED;
        }
        player.X = Math.Max(0, Math.Min(player.X, WIDTH - PLAYER_SIZE));

        // Move the aliens
        foreach (Alien alien in aliens)
        {
            alien.X += alien.VelocityX * ALIEN_SPEED;
            if (alien.X < 0 || alien.X > WIDTH - ALIEN_SIZE)
            {
                alien.VelocityX = -alien.VelocityX;
                alien.Y += ALIEN_SIZE + ALIEN_SPACING;
            }
        }

        // Move the lasers and check for collisions
        for (int i = lasers.Count - 1; i >= 0; i--)
        {
            Laser laser = lasers[i];
            laser.Y -= LASER_SPEED;
            if (laser.Y < 0)
            {
                lasers.RemoveAt(i);
            }
            else
            {
                bool hit = false;
                if (laser.IsPlayerLaser)
                {
                    // Check for player laser hits on aliens
                    foreach (Alien alien in aliens)
                    {
                        if (alien.Contains(laser.X, laser.Y))
                        {
                            aliens.Remove(alien);
                            lasers.RemoveAt(i);
                            score += 10;
                            hit = true;
                            break;
                        }
                    }
                }
                else
                {
                    // Check for alien laser hit on player
                    if (player.Contains(laser.X, laser.Y))
                    {
                        MessageBox.Show("Game over!");
                        Application.Exit();
                    }
                }

                if (!hit)
                {
                    // Draw the laser
                    using (Pen pen = new Pen(laser.IsPlayerLaser ? Brushes.Blue : Brushes.Red, LASER_SIZE))
                    {
                        Graphics.DrawLine(pen, laser.X, laser.Y, laser.X, laser.Y + LASER_SIZE);
                    }
                }
            }
        }

        // Generate new alien laser
        if (aliens.Count > 0 && rand.Next(100) < 2)
        {
            Alien alien = aliens[rand.Next(aliens.Count)];
            lasers.Add(new Laser(alien.X + ALIEN_SIZE / 2, alien.Y + ALIEN_SIZE, false));
        }

        // Generate new alien wave
        if (aliens.Count == 0)
        {
            score += 100;
            GenerateAliens();
        }

        // Redraw the screen
        Invalidate();
    }

    private void GenerateAliens()
    {
        // Generate a new wave of aliens
        for (int i = 0; i < ALIEN_ROWS; i++)
        {
            for (int j = 0; j < ALIEN_COLS; j++)
            {
                aliens.Add(new Alien(j * (ALIEN_SIZE + ALIEN_SPACING), i * (ALIEN_SIZE + ALIEN_SPACING)));
            }
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Draw the score
        using (Font font = new Font(FontFamily.GenericSansSerif, 16))
        {
            e.Graphics.DrawString("Score: " + score, font, Brushes.White, 10, 10);
        }

        // Draw the player
        e.Graphics.FillRectangle(Brushes.Yellow, player.X, player.Y, PLAYER_SIZE, PLAYER_SIZE);

        // Draw the aliens
        foreach (Alien alien in aliens)
        {
            e.Graphics.FillRectangle(Brushes.Green, alien.X, alien.Y, ALIEN_SIZE, ALIEN_SIZE);
        }

        // Draw the lasers
        foreach (Laser laser in lasers)
        {
            // lasers are drawn in the timer event handler above
        }
    }

    private class Player
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Player(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Contains(int x, int y)
        {
            return x >= X && x < X + PLAYER_SIZE && y >= Y && y < Y + PLAYER_SIZE;
        }
    }

    private class Alien
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int VelocityX { get; set; }

        public Alien(int x, int y)
        {
            X = x;
            Y = y;
            VelocityX = 1;
        }

        public bool Contains(int x, int y)
        {
            return x >= X && x < X + ALIEN_SIZE && y >= Y && y < Y + ALIEN_SIZE;
        }
    }

    private class Laser
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsPlayerLaser { get; set; }

        public Laser(int x, int y, bool isPlayerLaser)
        {
            X = x;
            Y = y;
            IsPlayerLaser = isPlayerLaser;
        }
    }
}

public class Program
{
    public static void Main()
    {
        Application.Run(new AlienInvader());
    }
}
```

The code uses a `Timer` to update the game state and redraw the screen at a fixed interval (60 frames per second). The code defines several classes to represent the game objects, including the player ship, the alien invaders, and the laser beams. The game logic includes moving the player and aliens, detecting collisions between lasers and game objects, and generating new alien waves.

The `OnPaint` method draws the game elements using GDI+. The player ship is represented as a yellow rectangle, the alien invaders are represented as green rectangles, and the laser beams are represented as blue (player lasers) or red (alien lasers) lines. The score is displayed at the top left corner of the screen.alien invaders