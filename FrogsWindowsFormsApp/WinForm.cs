using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrogsWindowsFormsApp
{
    public partial class WinForm : Form
    {
        int score;
        public WinForm(int score)
        {
            InitializeComponent();
            this.score = score;
        }

        private void WinForm_Load(object sender, EventArgs e)
        {
            resultLabel.Text = "Ваше количество ходов - " + score;
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            Application.Restart();            
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
