using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flappy_bird
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;
        bool gameOver = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Điểm của bạn :" + score; 

            if (pipeBottom.Left < - 150)
            {
                pipeBottom.Left = 500;
                score++;
            }    
            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 550;
                score++;
            }    

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -25
                )
            {
                endGame();
            }    
           

           if (score > 5)
            {
                pipeSpeed = 15;
            }    
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -15;

            }    
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;

            }
            if(e.KeyCode == Keys.R && gameOver)
            {
                RestarGame();
            }
        }
        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += "Trò chơi kết thúc! Nhấn R để chơi lại";
            gameOver = true;
        }
        private void RestarGame()
        {
            gameOver = false;
            flappyBird.Location = new Point(66, 54);
            pipeTop.Left = 800;
            pipeBottom.Left = 1000;

            score = 0;
            pipeSpeed = 8;
            scoreText.Text = "Điểm  :0";
            gameTimer.Start();
        }
    }
}
