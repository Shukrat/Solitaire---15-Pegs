using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Homework_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox.Text = "";            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Stopwatch sc = new Stopwatch();
            sc.Start();
            RunSequence start = new RunSequence(this);
            for (int i = 0; i < 15; i++)
            {
                start.Solved = false;
                while (start.Solved == false)
                {
                    start.RunPuzzleZero(i);
                }
            }
            sc.Stop();
            textBox.AppendText("Elapsed Time: " + sc.ElapsedMilliseconds + " ms.");
        }

        public void WriteToText(string input)
        {
            textBox.AppendText(input + Environment.NewLine);
        }
    }
}
