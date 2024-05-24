namespace Floppy_Game_by_I_M_Marinov
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            obstacleBottom = new PictureBox();
            doggie = new PictureBox();
            grass = new PictureBox();
            obstacleTop = new PictureBox();
            scoreLabel = new Label();
            timer = new System.Windows.Forms.Timer(components);
            scoreText = new Label();
            obstacleBottom2 = new PictureBox();
            gameOverLabel = new Label();
            obstacleTop2 = new PictureBox();
            startButton = new Button();
            retryButton = new Button();
            ((System.ComponentModel.ISupportInitialize)obstacleBottom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)doggie).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)obstacleTop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)obstacleBottom2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)obstacleTop2).BeginInit();
            SuspendLayout();
            // 
            // obstacleBottom
            // 
            obstacleBottom.Image = (Image)resources.GetObject("obstacleBottom.Image");
            obstacleBottom.Location = new Point(369, 304);
            obstacleBottom.Name = "obstacleBottom";
            obstacleBottom.Size = new Size(140, 238);
            obstacleBottom.TabIndex = 1;
            obstacleBottom.TabStop = false;
            // 
            // doggie
            // 
            doggie.BackgroundImageLayout = ImageLayout.None;
            doggie.Image = (Image)resources.GetObject("doggie.Image");
            doggie.Location = new Point(27, 121);
            doggie.Name = "doggie";
            doggie.Size = new Size(95, 64);
            doggie.SizeMode = PictureBoxSizeMode.StretchImage;
            doggie.TabIndex = 2;
            doggie.TabStop = false;
            // 
            // grass
            // 
            grass.BackgroundImageLayout = ImageLayout.Stretch;
            grass.Image = (Image)resources.GetObject("grass.Image");
            grass.Location = new Point(-7, 495);
            grass.Name = "grass";
            grass.Size = new Size(1404, 61);
            grass.SizeMode = PictureBoxSizeMode.StretchImage;
            grass.TabIndex = 3;
            grass.TabStop = false;
            // 
            // obstacleTop
            // 
            obstacleTop.Image = (Image)resources.GetObject("obstacleTop.Image");
            obstacleTop.Location = new Point(591, -220);
            obstacleTop.Name = "obstacleTop";
            obstacleTop.Size = new Size(141, 371);
            obstacleTop.TabIndex = 4;
            obstacleTop.TabStop = false;
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.BackColor = Color.PaleGreen;
            scoreLabel.Font = new Font("Little Dinosaur", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            scoreLabel.Location = new Point(12, 15);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(133, 36);
            scoreLabel.TabIndex = 5;
            scoreLabel.Text = "Score:";
            scoreLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            timer.Interval = 10;
            timer.Tick += timer_Tick;
            // 
            // scoreText
            // 
            scoreText.AutoSize = true;
            scoreText.Font = new Font("Little Dinosaur", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            scoreText.Location = new Point(151, 15);
            scoreText.Name = "scoreText";
            scoreText.Size = new Size(0, 36);
            scoreText.TabIndex = 6;
            // 
            // obstacleBottom2
            // 
            obstacleBottom2.Image = (Image)resources.GetObject("obstacleBottom2.Image");
            obstacleBottom2.Location = new Point(724, 366);
            obstacleBottom2.Name = "obstacleBottom2";
            obstacleBottom2.Size = new Size(138, 367);
            obstacleBottom2.TabIndex = 7;
            obstacleBottom2.TabStop = false;
            // 
            // gameOverLabel
            // 
            gameOverLabel.AutoSize = true;
            gameOverLabel.BackColor = Color.Crimson;
            gameOverLabel.FlatStyle = FlatStyle.System;
            gameOverLabel.Font = new Font("Little Dinosaur", 48F, FontStyle.Regular, GraphicsUnit.Point);
            gameOverLabel.Location = new Point(369, 196);
            gameOverLabel.Name = "gameOverLabel";
            gameOverLabel.Size = new Size(527, 66);
            gameOverLabel.TabIndex = 8;
            gameOverLabel.Text = "gameOverLabel";
            gameOverLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // obstacleTop2
            // 
            obstacleTop2.Image = (Image)resources.GetObject("obstacleTop2.Image");
            obstacleTop2.Location = new Point(964, -156);
            obstacleTop2.Name = "obstacleTop2";
            obstacleTop2.Size = new Size(141, 371);
            obstacleTop2.TabIndex = 9;
            obstacleTop2.TabStop = false;
            // 
            // startButton
            // 
            startButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            startButton.BackColor = Color.SpringGreen;
            startButton.Font = new Font("Little Dinosaur", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            startButton.Location = new Point(12, 216);
            startButton.Name = "startButton";
            startButton.Size = new Size(146, 49);
            startButton.TabIndex = 10;
            startButton.Tag = "startButton";
            startButton.Text = "Start Game";
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += startButton_Click;
            // 
            // retryButton
            // 
            retryButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            retryButton.BackColor = Color.Gold;
            retryButton.Font = new Font("Little Dinosaur", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            retryButton.ForeColor = Color.Black;
            retryButton.Location = new Point(503, 265);
            retryButton.Name = "retryButton";
            retryButton.Size = new Size(146, 49);
            retryButton.TabIndex = 11;
            retryButton.Tag = "retryButton";
            retryButton.Text = "Retry";
            retryButton.UseVisualStyleBackColor = false;
            retryButton.Click += retryButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1140, 555);
            Controls.Add(retryButton);
            Controls.Add(startButton);
            Controls.Add(doggie);
            Controls.Add(scoreText);
            Controls.Add(gameOverLabel);
            Controls.Add(grass);
            Controls.Add(scoreLabel);
            Controls.Add(obstacleTop2);
            Controls.Add(obstacleTop);
            Controls.Add(obstacleBottom2);
            Controls.Add(obstacleBottom);
            Name = "Form1";
            Text = "Flappy Doggy";
            KeyDown += onKeyDown;
            KeyUp += onKeyUp;
            ((System.ComponentModel.ISupportInitialize)obstacleBottom).EndInit();
            ((System.ComponentModel.ISupportInitialize)doggie).EndInit();
            ((System.ComponentModel.ISupportInitialize)grass).EndInit();
            ((System.ComponentModel.ISupportInitialize)obstacleTop).EndInit();
            ((System.ComponentModel.ISupportInitialize)obstacleBottom2).EndInit();
            ((System.ComponentModel.ISupportInitialize)obstacleTop2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox obstacleBottom;
        private PictureBox doggie;
        private PictureBox grass;
        private PictureBox obstacleTop;
        private Label scoreLabel;
        private System.Windows.Forms.Timer timer;
        private Label scoreText;
        private PictureBox obstacleBottom2;
        private Label gameOverLabel;
        private PictureBox obstacleTop2;
        private Button startButton;
        private Button retryButton;
    }
}
