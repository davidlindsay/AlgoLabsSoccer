using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer_Simulation
{
    public class Game
    {
        public List<Team> Teams { get; set; } = new List<Team>();
        public Ball Ball { get; set; }

        public Game()
        {
            // Initialize ball.
            Ball = new Ball(50, 50); // You can set the initial position of the ball as per your requirement.

            // Initialize teams and agents.
            Team team1 = new Team("Team 1");
            team1.Agents.Add(new Agent(10, 10, team1)); // Initial position (10, 10) for an agent of Team 1.
            team1.Agents.Add(new Agent(10, 90, team1)); // Initial position (10, 90) for another agent of Team 1.

            Team team2 = new Team("Team 2");
            team2.Agents.Add(new Agent(90, 10, team2)); // Initial position (90, 10) for an agent of Team 2.
            team2.Agents.Add(new Agent(90, 90, team2)); // Initial position (90, 90) for another agent of Team 2.

            Teams.Add(team1);
            Teams.Add(team2);
        }

        public void Update()
        {
            // Move each agent based on AI logic.
            foreach (var team in Teams)
            {
                foreach (var agent in team.Agents)
                {
                    agent.Move(Ball);
                }
            }

            // Move the ball.
            Ball.Move();

            // Handle collisions.
            HandleCollisions();
        }

        private void HandleCollisions()
        {
            foreach (var team in Teams)
            {
                foreach (var agent in team.Agents)
                {
                    // Check collision between agent and ball.
                    if (IsColliding(agent, Ball))
                    {
                        // Handle collision. For example, reverse the ball's direction.
                        Ball.ReverseDirection();
                    }
                }
            }

            // Handle agent-agent collisions.
            foreach (var team1 in Teams)
            {
                foreach (var agent1 in team1.Agents)
                {
                    foreach (var team2 in Teams)
                    {
                        foreach (var agent2 in team2.Agents)
                        {
                            if (agent1 != agent2 && IsColliding(agent1, agent2))
                            {
                                // Handle collision. For example, stop the agents.
                                agent1.Stop();
                                agent2.Stop();
                            }
                        }
                    }
                }
            }
        }

        private bool IsColliding(Agent agent1, Agent agent2)
        {
            // Calculate the distance between the center of the two agents.
            double distance = Math.Sqrt(Math.Pow(agent1.X - agent2.X, 2) + Math.Pow(agent1.Y - agent2.Y, 2));

            // Check if the distance is less than or equal to the sum of the radii of the two agents.
            return distance <= (agent1.Width / 2 + agent2.Width / 2);
        }

        private bool IsColliding(Agent agent, Ball ball)
        {
            // Calculate the distance between the center of the agent and the ball.
            double distance = Math.Sqrt(Math.Pow(agent.X - ball.X, 2) + Math.Pow(agent.Y - ball.Y, 2));

            // Check if the distance is less than or equal to the sum of the radii of the agent and the ball.
            return distance <= (agent.Width / 2 + ball.Width / 2);
        }
    }
}
