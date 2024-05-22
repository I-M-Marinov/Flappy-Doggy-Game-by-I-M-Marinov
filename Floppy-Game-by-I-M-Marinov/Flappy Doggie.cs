namespace Floppy_Game_by_I_M_Marinov
{

    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            gameOverLabel.Visible = false;
            this.KeyPreview = true;

        }

        // public variables
        int obstacleSpeed = 3; // movement speed of the obstacles
        int gravity = 3; // movement of doggie 
        int score = 0; // scores ... ofc
        bool speedIncreasedOnce = false; // flag to ensure speed increases only once

        private void timer_Tick(object sender, EventArgs e)
        {
            doggie.Top += gravity;

            MoveObstacle(obstacleBottom);
            MoveObstacle(obstacleTop);
            MoveObstacle(obstacleBottom2);
            MoveObstacle(obstacleTop2);

            scoreText.Text = score.ToString();

            CheckAndResetObstacle(obstacleBottom);
            CheckAndResetObstacle(obstacleTop);
            CheckAndResetObstacle(obstacleBottom2);
            CheckAndResetObstacle(obstacleTop2);

            if (CheckCollision())
            {
                gameOver();
            }

            if (score > 10 && !speedIncreasedOnce)
            {
                obstacleSpeed += 1;
                speedIncreasedOnce = true;
            }
        }

        private void MoveObstacle(PictureBox obstacle)
        {
            obstacle.Left -= obstacleSpeed;
        }

        private bool IsOffScreen(PictureBox obstacle)
        {
            return obstacle.Left < -obstacle.Width;
        }

        private void ResetObstaclePosition(PictureBox obstacle)
        {
            obstacle.Left = 950;
        }

        private void CheckAndResetObstacle(PictureBox obstacle)
        {
            if (IsOffScreen(obstacle))
            {
                ResetObstaclePosition(obstacle);
                score++;
            }
        }

        private bool CheckCollision()
        {
            return doggie.Bounds.IntersectsWith(obstacleBottom.Bounds) || doggie.Bounds.IntersectsWith(obstacleBottom2.Bounds)
                || doggie.Bounds.IntersectsWith(obstacleTop.Bounds) || doggie.Bounds.IntersectsWith(obstacleTop2.Bounds) || doggie.Bounds.IntersectsWith(grass.Bounds) || doggie.Top < -15;
        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gravity = 3;
            }
        }

        private void onKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                gravity = -3;
            }
        }

        private void gameOver()
        {
            timer.Stop();
            gameOverLabel.Text = "Game Over !";
            gameOverLabel.Visible = true;
        }

        private void StartGame()
        {
            timer.Start();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartGame();
            startButton.Visible = false;
            Focus(); // Ensure the form has focus to capture key events
        }

    }
}
