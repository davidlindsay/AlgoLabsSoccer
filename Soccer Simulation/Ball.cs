using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer_Simulation
{
    public class Ball
    {
        // ... Other properties ...
        public int Width { get; } = 10;
        public int Height { get; } = 10;
        public int SpeedX { get; set; } = 1; // Horizontal speed of the ball.
        public int SpeedY { get; set; } = 1; // Vertical speed of the ball.

        // ... Other methods ...

        public int X { get; set; }
        public int Y { get; set; }

        public Ball(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move()
        {
            // Implement logic to move the ball.
            // Update the position of the ball based on its speed.
            X += SpeedX;
            Y += SpeedY;
        }

        public void ReverseDirection()
        {
            // Reverse the horizontal and vertical direction of the ball.
            SpeedX = -SpeedX;
            SpeedY = -SpeedY;
        }
    }
}
