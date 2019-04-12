using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW7Sudoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int[] arr = new int[81];
            Random rand = new Random();

            for (int i = 0; i < 81; i++)
            {
                arr[i] = rand.Next(1, 10);
                textBox1.Text += arr[i] + "\t";
                if ((i + 1) % 9 == 0)
                    textBox1.Text += "\n";
            }
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {

        }

        private void CheckButton_Click(object sender, EventArgs e)
        {

        }

        private void SolveButton_Click(object sender, EventArgs e)
        {

        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
