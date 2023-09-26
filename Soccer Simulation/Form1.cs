using Timer = System.Windows.Forms.Timer;

namespace Soccer_Simulation
{
    public partial class Form1 : Form
    {
        private Game game;
        private Timer timer;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
            InitializeTimer();
        }

        private void InitializeGame()
        {
            game = new Game();
            // Initialize teams, agents, and ball.
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Draw the green background.
            g.Clear(Color.Green);

            // Draw goals.
            g.FillRectangle(Brushes.Red, 0, 232, 10, 50); // Red goal on the left.
            g.FillRectangle(Brushes.Blue, 853 - 10, 232, 10, 50); // Blue goal on the right.


            foreach (var team in game.Teams)
            {
                foreach (var agent in team.Agents)
                {
                    // Draw the agent as a circle.
                    Brush brush = agent.Team.Name == "Team 1" ? Brushes.Red : Brushes.Blue;
                    g.FillEllipse(brush, agent.X - agent.Width / 2, agent.Y - agent.Height / 2, agent.Width, agent.Height);

                    // Draw the direction line.
                    Pen pen = new Pen(Color.Yellow, 2); // Yellow line to represent the direction.
                    float lineLength = agent.Width / 2; // Length of the direction line.
                    g.DrawLine(pen, agent.X, agent.Y, agent.X + agent.Direction.X * lineLength, agent.Y + agent.Direction.Y * lineLength);
                }
            }

            // Draw the ball.
            g.FillEllipse(Brushes.White, game.Ball.X - game.Ball.Width / 2, game.Ball.Y - game.Ball.Height / 2, game.Ball.Width, game.Ball.Height);
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 100; // Set the timer interval (in milliseconds).
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            game.Update(); // Update the game state.
            this.Invalidate(); // Redraw the form.
        }

      
    }
}