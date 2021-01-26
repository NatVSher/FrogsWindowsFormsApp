using System;
using System.Windows.Forms;

namespace FrogsWindowsFormsApp
{
    public partial class MainForm : Form
    {
        public int score = 0;
        PictureBox[] leftPictureBoxes;
        
        public MainForm()
        {
            InitializeComponent();
            leftPictureBoxes = new PictureBox[] 
            {
                leftPictureBox1, 
                leftPictureBox2, 
                leftPictureBox3, 
                leftPictureBox4
            };
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            Swap((PictureBox)sender);
           
        }

        private void Swap(PictureBox clikedPicture)
        {
            var distance = Math.Abs(clikedPicture.Location.X - emptyPictureBox.Location.X) / emptyPictureBox.Size.Width;
            if (distance>2)
            {
                MessageBox.Show("Так нельзя!");
            }
            else
            {
                var location = clikedPicture.Location;
                clikedPicture.Location = emptyPictureBox.Location;
                emptyPictureBox.Location = location;
                score++;
                scoreLabel.Text = "Количество ходов - " + score;
                CheckWin();
            }
        }

        private void CheckWin()
        {
            int widthPictureBox = emptyPictureBox.Size.Width;
            int countLeftToRight = 0;
            int fullShift = 4;
            foreach (PictureBox pictureBox in leftPictureBoxes)
            {
                if (pictureBox.Location.X >= widthPictureBox*5)
                {
                    countLeftToRight++;
                }
            }
            if (countLeftToRight == fullShift && emptyPictureBox.Location.X == widthPictureBox*4)
            {
                var winForm = new WinForm(score);
                winForm.ShowDialog();
            }
            
        }

        private void правилаИгрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Цель игры расположить лягушек, которые смотрит влево в левую часть, " +
                "а остальных в правую часть за минимальное количество перепрыгиваний" + 
                "Прыгать можно на листок если он находится рядом или через 1 лягушку");
        }

        private void начатьСначалаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
