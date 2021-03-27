using System;
using System.Windows.Forms;

namespace GameOfLife
{
    /// <summary>
    /// This class handles the input to the form and calls the appropriate methods.
    /// </summary>
    public partial class mainForm : Form
    {
        private Game game;

        /// <summary>
        /// Constructs the <see cref="mainForm"/>.
        /// </summary>
        public mainForm()
        {
            InitializeComponent();
            game = new Game(50, 50);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            game.Step();
            Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gameTimer.Enabled)
            {
                gameTimer.Stop();
                startBtn.Text = "&Start";
            }
            else
            {
                gameTimer.Start();
                startBtn.Text = "&Stop";
            }
        }

        private void mainForm_Paint(object sender, PaintEventArgs e)
        {
            game.Draw(e.Graphics);
        }

        private void mainForm_MouseClick(object sender, MouseEventArgs e)
        {
            game.Click(e.X, e.Y);
            Invalidate();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            game = new Game(50, 50);
            Invalidate();
        }
    }
}
