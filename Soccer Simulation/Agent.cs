using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer_Simulation
{
    public class Agent
    {
        // ... Other properties ...
        public int Width { get; } = 20;
        public int Height { get; } = 20;

        public int Speed { get; set; } = 1; // You can adjust the speed as per your requirement.
        public PointF Direction { get; set; } = new PointF(1, 0); // Default direction pointing to the right.

        // ... Other methods ...

        public int X { get; set; }
        public int Y { get; set; }
        public Team Team { get; set; }

        public Agent(int x, int y, Team team, PointF direction)
        {
            X = x;
            Y = y;
            Team = team;
            Direction = direction;
        }

        public void Move(Ball ball)
        {
            // Simple AI logic: Move towards the ball.
            // Move the agent in the direction it is facing.
            this.X += (int)Direction.X;
            this.Y += (int)Direction.Y;
        }

        public void Stop()
        {
            // Set the speed to 0 to stop the agent.
            Speed = 0;
        }

        public void Resume()
        {
            // Reset the speed to resume the agent's movement.
            Speed = 1; // Reset to the original speed value.
        }
    }
}
