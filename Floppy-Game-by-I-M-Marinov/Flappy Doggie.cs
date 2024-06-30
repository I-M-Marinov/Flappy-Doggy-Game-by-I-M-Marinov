using System.Media;
using NAudio.Wave;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Floppy_Game_by_I_M_Marinov.Methods;

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
            this.KeyPreview = true;
            ScoreManipulation.LoadNamesFromFile(); 
            gameOverLabel.Visible = false;
            retryButton.Visible = false;
            levelNumber.Visible = false;
            quitButton.Visible = false;
            saveScoresLabel.Visible = false;
            nameLabel.Visible = false;
            scoresTextBox.Visible = false;
            submitScoresButton.Visible = false;
            resetAllScoresButton.Visible = false;
            statusTextLabel.Visible = false;
            statusTextLabel.Text = "";

            /* save the initial positions of the doggy and obstacles */

            initialObstacleBottomX = obstacleBottom.Left;
            initialObstacleTopX = obstacleTop.Left;
            initialObstacleBottom2X = obstacleBottom2.Left;
            initialObstacleTop2X = obstacleTop2.Left;
            initialDoggieY = doggie.Top;
            Sounds.InitializeBackgroundMusic();

        }
        public Label StatusTextLabel
        {
            get { return statusTextLabel; }
        }
        public Label SaveScoresLabel
        {
            get { return saveScoresLabel; }
        }
        public Label NameLabel
        {
            get { return nameLabel; }
        }
        public TextBox ScoresTextBox
        {
            get { return scoresTextBox; }
        }
        public Button SubmitScoresButton
        {
            get { return submitScoresButton; }
        }
        public Button ResetAllScoresButton
        {
            get { return resetAllScoresButton; }
        }


        // public variables
        int obstacleSpeed = 3; // movement speed of the obstacles
        int level = 1;
        int gravity = 3; // movement of doggy 
        int score = 0; // scores 
        private bool _speedIncreasedAlready = false;
        int lastCheckedScore = 0;
        readonly DateTime date = DateTime.Now;


        private void StartGame()
        {
            timer.Start();
        }

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
                Sounds.HitAnObstacleSound();
                gameOver();
            }

            if (score % 20 == 0 && score > 0 && !_speedIncreasedAlready)
            {
                IncreaseGameSpeed(score);
            }
            else if (score % 20 != 0)
            {
                _speedIncreasedAlready = false;
            }
        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                Sounds.PlayUpAndDownSounds();
                gravity = 3;
            }
        }

        private void onKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                Sounds.PlayUpAndDownSounds();
                gravity = -3;
            }
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
            ShowAllObstacles();
            doggie.Top = initialDoggieY;
            obstacleBottom.Left = initialObstacleBottomX;
            obstacleTop.Left = initialObstacleTopX;
            obstacleBottom2.Left = initialObstacleBottom2X;
            obstacleTop2.Left = initialObstacleTop2X;
            gameOverLabel.Visible = false;
            retryButton.Visible = false; // Hide the retry button before restarting the game
            levelNumber.Visible = true;
            quitButton.Visible = false;
            ScoreManipulation.HighScoresHide();
            statusTextLabel.Text = "";
            timer.Start();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show($"Are you sure you want to quit ?", "Are you leaving ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Environment.Exit(500);
            }
        }

        private void gameOver()
        {
            timer.Stop();
            gameOverLabel.Text = "Game Over !";
            gameOverLabel.Visible = true;
            retryButton.Visible = true;
            quitButton.Visible = true;
            HideAllObstacles();
            ScoreManipulation.HighScoresShow();

        }

        private void submitScoresButton_Click(object sender, EventArgs e)
        {

            string playerName = scoresTextBox.Text;
            int highestScore = ScoreManipulation.GetHighestScoreForUser(playerName);
            if (playerName == "")
            {
                statusTextLabel.Text = "You need to write a name in to save your score! ";
            }
            /* if the list of usernames contains the username and the current score is bigger than the highest score recorded in the TXT file and if the highest score in the file is not 0 */
            else if (ScoreManipulation.usernameList.Contains(playerName) && score > highestScore && highestScore != 0)
            {
                ScoreManipulation.usernameList.Remove(playerName); // remove the last score saved for that username from the private LIST
                ScoreManipulation.RemoveScoreFromFile(playerName); // remove the score from the TXT file
                ScoreManipulation.usernameList.Add(playerName); // add the new score to the list
                ScoreManipulation.SaveTheScore(playerName, score, level, date); // add the new score to the TXT file 
                scoresTextBox.Text = "";
                statusTextLabel.Text = $"{playerName}'s has a new high score --> {score}.";

            }
            else if (score < highestScore)
            {
                statusTextLabel.Text = $"{playerName}'s highest score is {highestScore}. Try again !";
            }
            else
            {
                ScoreManipulation.SaveTheScore(playerName, score, level, date);
                scoresTextBox.Text = "";
                statusTextLabel.Text = $"{playerName} your score has been saved successfully !";
                ScoreManipulation.usernameList.Add(playerName);
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


        private void resetAllScores_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Are you sure you want to delete all saved scores ?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                ScoreManipulation.DeleteScores();
            }
        }

        private void HideAllObstacles()
        {
            obstacleBottom.Visible = false;
            obstacleTop.Visible = false;
            obstacleBottom2.Visible = false;
            obstacleTop2.Visible = false;
        }

        private void ShowAllObstacles()
        {
            obstacleBottom.Visible = true;
            obstacleTop.Visible = true;
            obstacleBottom2.Visible = true;
            obstacleTop2.Visible = true;
        }
        
    }
}
