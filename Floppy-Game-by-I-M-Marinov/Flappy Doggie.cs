using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Floppy_Game_by_I_M_Marinov
{

    public partial class Form1 : Form
    {
        private int initialObstacleBottomX;
        private int initialObstacleTopX;
        private int initialObstacleBottom2X;
        private int initialObstacleTop2X;
        private int initialDoggieY;


        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            gameOverLabel.Visible = false;
            retryButton.Visible = false;
            this.KeyPreview = true;
            levelNumber.Visible = false;
            quitButton.Visible = false;

            /* save the initial positions of the doggie and obstacles */
            initialObstacleBottomX = obstacleBottom.Left;
            initialObstacleTopX = obstacleTop.Left;
            initialObstacleBottom2X = obstacleBottom2.Left;
            initialObstacleTop2X = obstacleTop2.Left;
            initialDoggieY = doggie.Top;

        }

        // public variables
        int obstacleSpeed = 3; // movement speed of the obstacles
        int level = 1;
        int gravity = 3; // movement of doggie 
        int score = 0; // scores ... ofc
        private bool speedIncreasedAlready = false;
        int lastCheckedScore = 0;


        private void timer_Tick(object sender, EventArgs e)
        {
            doggie.Top += gravity;

            MoveObstacle(obstacleBottom);
            MoveObstacle(obstacleTop);
            MoveObstacle(obstacleBottom2);
            MoveObstacle(obstacleTop2);

            scoreText.Text = score.ToString();
            levelNumber.Text = level.ToString();

            CheckAndResetObstacle(obstacleBottom);
            CheckAndResetObstacle(obstacleTop);
            CheckAndResetObstacle(obstacleBottom2);
            CheckAndResetObstacle(obstacleTop2);

            if (CheckCollision())
            {
                gameOver();
            }

            if (score % 20 == 0 && score > 0 && !speedIncreasedAlready)
            {
                IncreaseGameSpeed(score);
            }
            else if (score % 20 != 0)
            {
                speedIncreasedAlready = false;
            }
        }

        private void IncreaseGameSpeed(int score)
        {
            if (score % 20 == 0 && score > lastCheckedScore)
            {
                obstacleSpeed += 1;
                lastCheckedScore = score;
                level++;
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
            retryButton.Visible = true;
            quitButton.Visible = true;
        }

        private void StartGame()
        {
            timer.Start();
        }


        private void startButton_Click(object sender, EventArgs e)
        {
            StartGame();
            startButton.Visible = false;
            levelNumber.Visible = true;
            Focus(); // Ensure the form has focus to capture key events
        }

        private void retryButton_Click(object sender, EventArgs e)
        {
            retryGame();
        }

        private void retryGame()
        {
            score = 0;
            gravity = 3;
            obstacleSpeed = 3;
            /* call the doggy and obstacles's initial positions */
            doggie.Top = initialDoggieY;
            obstacleBottom.Left = initialObstacleBottomX;
            obstacleTop.Left = initialObstacleTopX;
            obstacleBottom2.Left = initialObstacleBottom2X;
            obstacleTop2.Left = initialObstacleTop2X;
            gameOverLabel.Visible = false;
            retryButton.Visible = false; // Hide the retry button before restarting the game
            levelNumber.Visible = true;
            quitButton.Visible = false;
            timer.Start();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(500);
        }
    }
}
