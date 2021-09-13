using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        private int time;
        private int numOne;
        private int numTwo;
        private string op;
        private int score;
        private int total;
        Random randomizer = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            time = 60;
            label1.Text = label1.Text = (time / 60) + ":0" + (time % 60);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(time == 0)
            {
                end();
                timer1.Stop();
                return;
            }
            time--;
            if(time %60 < 10)
                label1.Text = (time / 60) + ":0" + (time % 60);
            else
                label1.Text = (time / 60) + ":" + (time % 60);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                timer1.Start();
            }
            if (op == "sum")
            {
                if(textBox1.Text.Contains((numOne+numTwo) + ""))
                {
                    score++;
                }
                total++;
            } else if (op == "diff")
            {
                if (textBox1.Text.Contains((numOne-numTwo) + "")){
                    score++;
                }
                total++;
            } else if (op == "prod")
            {
                if (textBox1.Text.Contains((numOne*numTwo) + "")){
                    score++;
                }
                total++;
            } else if (op == "solu")
            {
                if (textBox1.Text.Contains((numOne/numTwo) + "")){
                    score++;
                }
                total++;
            }
            generateQuestion();
            if (op == "sum")
            {
                label2.Text = numOne + " + " + numTwo;
            }
            else if (op == "diff")
            {
                label2.Text = numOne + " - " + numTwo;
            }
            else if (op == "prod")
            {
                label2.Text = numOne + " * " + numTwo;
            }
            else if (op == "solu")
            {
                label2.Text = numOne + " / " + numTwo;
            }
            textBox1.Text = "";
        }

        private void generateQuestion()
        {
            int temp = (int)(randomizer.Next(4));
            if(temp == 0)
            {
                op = "sum";
                numOne = (int)(randomizer.Next(31));
                numTwo = (int)(randomizer.Next(31));
            }
            else if(temp == 1)
            {
                op = "diff";
                numOne = (int)(randomizer.Next(31));
                numTwo = (int)(randomizer.Next(31));
            } 
            else if(temp == 2)
            {
                op = "prod";
                numOne = (int)(randomizer.Next(13));
                numTwo = (int)(randomizer.Next(13));
            } 
            else if(temp == 3)
            {
                op = "solu";
                numOne = (int)(randomizer.Next(10) + 1);
                List<int> factors = new List<int>();
                for(int i = 1; i <= numOne; i++)
                {
                    if(numOne % i == 0)
                    {
                        factors.Add(i);
                    }
                }
                Console.WriteLine(factors);
                numTwo = factors[(int)randomizer.Next(factors.Count)];
            }
        }

        private void end()
        {
            label2.Text = "Your Score: " + score + "/" + total;
        }
    }
}
