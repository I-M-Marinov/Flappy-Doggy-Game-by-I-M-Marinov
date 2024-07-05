using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Floppy_Game_by_I_M_Marinov.Methods
{
    public class GameEngine
    {
        public int obstacleSpeed = 3; // movement speed of the obstacles
        public int lastCheckedScore = 0;
        public int level = 1;
        public int gravity = 3; // movement of doggy 
        public int score = 0; // scores 
        public bool _speedIncreasedAlready = false;



        private readonly Form1 _form1;

        public GameEngine(Form1 form)
        {
            _form1 = form;
        }


        public void IncreaseGameSpeed(int score)
        {
            if (score % 20 == 0 && score > lastCheckedScore)
            {
                obstacleSpeed += 1;
                lastCheckedScore = score;
                level++;
            }
        }

        public void MoveObstacle(PictureBox obstacle)
        {
            obstacle.Left -= obstacleSpeed;
        }

        public bool IsOffScreen(PictureBox obstacle)
        {
            return obstacle.Left < -obstacle.Width;
        }

        public void ResetObstaclePosition(PictureBox obstacle)
        {
            obstacle.Left = 950;
        }

        public void CheckAndResetObstacle(PictureBox obstacle)
        {
            if (IsOffScreen(obstacle))
            {
                ResetObstaclePosition(obstacle);
                score++;
            }
        }

        public bool CheckCollision()
        {
            return _form1.Doggie.Bounds.IntersectsWith(_form1.ObstacleBottom.Bounds) || _form1.Doggie.Bounds.IntersectsWith(_form1.ObstacleBottom2.Bounds)
                                                                             || _form1.Doggie.Bounds.IntersectsWith(_form1.ObstacleTop.Bounds) || _form1.Doggie.Bounds.IntersectsWith(_form1.ObstacleTop2.Bounds) || _form1.Doggie.Bounds.IntersectsWith(_form1.Grass.Bounds) || _form1.Doggie.Top < -15;
        }

        public void HideAllObstacles()
        {
            _form1.ObstacleBottom.Visible = false;
            _form1.ObstacleTop.Visible = false;
            _form1.ObstacleBottom2.Visible = false;
            _form1.ObstacleTop2.Visible = false;
        }

        public void ShowAllObstacles()
        {
            _form1.ObstacleBottom.Visible = true;
            _form1.ObstacleTop.Visible = true;
            _form1.ObstacleBottom2.Visible = true;
            _form1.ObstacleTop2.Visible = true;
        }
    }
}
