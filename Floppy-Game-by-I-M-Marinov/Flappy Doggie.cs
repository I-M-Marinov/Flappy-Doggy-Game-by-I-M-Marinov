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

        private readonly DateTime _date = DateTime.Now;
        private readonly ScoreManipulation _scoreManipulation;
        private readonly Sounds _soundEffects;
        private readonly GameEngine _gameEngine;


        public Form1()
        {
            InitializeComponent();

            _gameEngine = new GameEngine(this);
            _soundEffects = new Sounds();
            _scoreManipulation = new ScoreManipulation(this);
            _soundEffects.InitializeBackgroundMusic();
            _scoreManipulation.LoadNamesFromFile();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.KeyPreview = true;
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

        }
        public Label StatusTextLabel
        {
            get { return statusTextLabel; }
            set { statusTextLabel = value; }
        }
        public Label SaveScoresLabel
        {
            get { return saveScoresLabel; }
            set { saveScoresLabel = value; }
        }
        public Label NameLabel
        {
            get { return nameLabel; }
            set { nameLabel = value; }
        }
        public TextBox ScoresTextBox
        {
            get { return scoresTextBox; }
            set { scoresTextBox = value; }
        }
        public Button SubmitScoresButton
        {
            get { return submitScoresButton; }
            set { submitScoresButton = value; }
        }
        public Button ResetAllScoresButton
        {
            get { return resetAllScoresButton; }
            set { resetAllScoresButton = value; }
        }

        public PictureBox Doggie
        {
            get { return doggie; }
            set { doggie = value; }
        }
        public PictureBox ObstacleTop
        {
            get { return obstacleTop; }
            set { obstacleTop = value; }
        }
        public PictureBox ObstacleTop2
        {
            get { return obstacleTop2; }
            set { obstacleTop2 = value; }
        }
        public PictureBox ObstacleBottom
        {
            get { return obstacleBottom; }
            set { obstacleBottom = value; }
        }
        public PictureBox ObstacleBottom2
        {
            get { return obstacleBottom2; }
            set { obstacleBottom2 = value; }
        }
        public PictureBox Grass
        {
            get { return grass; }
            set { grass = value; }
        }




        private void StartGame()
        {
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            doggie.Top += _gameEngine.gravity;

            _gameEngine.MoveObstacle(obstacleBottom);
            _gameEngine.MoveObstacle(obstacleTop);
            _gameEngine.MoveObstacle(obstacleBottom2);
            _gameEngine.MoveObstacle(obstacleTop2);

            scoreText.Text = _gameEngine.score.ToString();
            levelNumber.Text = _gameEngine.level.ToString();

            _gameEngine.CheckAndResetObstacle(obstacleBottom);
            _gameEngine.CheckAndResetObstacle(obstacleTop);
            _gameEngine.CheckAndResetObstacle(obstacleBottom2);
            _gameEngine.CheckAndResetObstacle(obstacleTop2);

            if (_gameEngine.CheckCollision())
            {
                _soundEffects.HitAnObstacleSound();
                gameOver();
            }

            if (_gameEngine.score % 20 == 0 && _gameEngine.score > 0 && !_gameEngine._speedIncreasedAlready)
            {
                _gameEngine.IncreaseGameSpeed(_gameEngine.score);
                _soundEffects.UpOneLevelSound();
            }
            else if (_gameEngine.score % 20 != 0)
            {
                _gameEngine._speedIncreasedAlready = false;
            }
        }
        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                _soundEffects.PlayUpAndDownSounds();
                _gameEngine.gravity = 3;
            }
        }
        private void onKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                _soundEffects.PlayUpAndDownSounds();
                _gameEngine.gravity = -3;
            }
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            _soundEffects.ButtonClickSound();
            StartGame();
            startButton.Visible = false;
            levelNumber.Visible = true;
            Focus(); // Ensure the form has focus to capture key events
        }
        private void retryButton_Click(object sender, EventArgs e)
        {
            _soundEffects.ButtonClickSound();
            retryGame();
        }
        private void retryGame()
        {
            _gameEngine.score = 0;
            _gameEngine.gravity = 3;
            _gameEngine.obstacleSpeed = 3;
            /* call the doggy and obstacles's initial positions */
            _gameEngine.ShowAllObstacles();
            doggie.Top = initialDoggieY;
            obstacleBottom.Left = initialObstacleBottomX;
            obstacleTop.Left = initialObstacleTopX;
            obstacleBottom2.Left = initialObstacleBottom2X;
            obstacleTop2.Left = initialObstacleTop2X;
            gameOverLabel.Visible = false; // Hide the game over label 
            retryButton.Visible = false; // Hide the retry button before restarting the game
            levelNumber.Visible = true; // Show the level number
            quitButton.Visible = false; // Hide the quit button
            _scoreManipulation.HighScoresHide();
            statusTextLabel.Text = "";
            timer.Start();
        }
        private void quitButton_Click(object sender, EventArgs e)
        {
            _soundEffects.ButtonClickSound();

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
            _gameEngine.HideAllObstacles();
            _scoreManipulation.HighScoresShow();

        }
        private void submitScoresButton_Click(object sender, EventArgs e)
        {
            _soundEffects.ButtonClickSound();

            string playerName = scoresTextBox.Text;
            int highestScore = _scoreManipulation.GetHighestScoreForUser(playerName);
            if (playerName == "")
            {
                statusTextLabel.Text = "You need to write a name in to save your score! ";
            }
            /* if the list of usernames contains the username and the current score is bigger than the highest score recorded in the TXT file and if the highest score in the file is not 0 */
            else if (_scoreManipulation.UsernameList.Contains(playerName) && _gameEngine.score > highestScore && highestScore != 0)
            {
                _scoreManipulation.UsernameList.Remove(playerName); // remove the last score saved for that username from the private LIST
                _scoreManipulation.RemoveScoreFromFile(playerName); // remove the score from the TXT file
                _scoreManipulation.UsernameList.Add(playerName); // add the new score to the list
                _scoreManipulation.SaveTheScore(playerName, _gameEngine.score, _gameEngine.level, _date); // add the new score to the TXT file 
                scoresTextBox.Text = "";
                statusTextLabel.Text = $"{playerName}'s has a new high score --> {_gameEngine.score}.";

            }
            else if (_gameEngine.score < highestScore)
            {
                statusTextLabel.Text = $"{playerName}'s highest score is {highestScore}. Try again !";
            }
            else
            {
                _scoreManipulation.SaveTheScore(playerName, _gameEngine.score, _gameEngine.level, _date);
                scoresTextBox.Text = "";
                statusTextLabel.Text = $"{playerName} your score has been saved successfully !";
                _scoreManipulation.UsernameList.Add(playerName);
            }
        }
        private void resetAllScores_Click(object sender, EventArgs e)
        {
            _soundEffects.ButtonClickSound();

            DialogResult result = MessageBox.Show($"Are you sure you want to delete all saved scores ?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                _scoreManipulation.DeleteScores();
            }
        }

    }
}
