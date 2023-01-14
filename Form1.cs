using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OperatorsAndOperands;
using Figures;

namespace OperatorsAndOperands
{
    public partial class Form1 : Form
    {
        private Stack<Operator> operators = new Stack<Operator>();
        private Stack<Operand> operands = new Stack<Operand>();
        private List<string> history = new List<string>();

        int history_index = -1;
        public Form1()
        {
            InitializeComponent();
            Init.bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            Init.pen = new Pen(Color.Black, 3);
            Init.pictureBox = pictureBox1;
            StringHandler.comboBox1 = comboBox1;
        }

        private void textBoxInputString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StringHandler.Handle(textBoxInputString.Text);
                history.Add(textBoxInputString.Text.Replace(" ", ""));
                history_index = history.Count - 1;
            }
            if (e.KeyCode == Keys.Up)
            {
                history_index -= 1;
                if (history_index < 0)
                {
                    history_index = history.Count - 1;
                }
                textBoxInputString.Text = history[history_index];
            }
        }
    }
}
