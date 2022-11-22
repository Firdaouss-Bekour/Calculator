using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Double result = 0;
        String operation = "";
            bool enter_value = false;
        String firstnum , secondnum;

        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textDisplay_TextChanged(object sender, EventArgs e)
        {

        }

        private void numbers_Only(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if ((textDisplay.Text == "0") || (enter_value))
                textDisplay.Text = "";
            enter_value = false;

            if(b.Text == ".")
            {
                if (!textDisplay.Text.Contains("."))
                    textDisplay.Text = textDisplay.Text + b.Text;
            }
            else
            {
                textDisplay.Text = textDisplay.Text + b.Text;
            }
       
        }

        private void operators_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (result != 0)
            {

                enter_value = true;
                operation = b.Text;
                lblShowOperator.Text = result + "   " + operation;
            }
            else
            {
                operation = b.Text;
                result = Double.Parse(textDisplay.Text);
                textDisplay.Text = "";
                lblShowOperator.Text = result + "   " + operation;
            }
            firstnum = lblShowOperator.Text;

        }

        private void buttonEquals(object sender, EventArgs e)
        {
            secondnum = textDisplay.Text;
            lblShowOperator.Text = "";
            switch(operation)
            {
                case "+":
                    textDisplay.Text = (result + Double.Parse(textDisplay.Text)).ToString();
                    break;
                case "-":
                    textDisplay.Text = (result - Double.Parse(textDisplay.Text)).ToString();
                    break;
                case "*":
                    textDisplay.Text = (result * Double.Parse(textDisplay.Text)).ToString();
                    break;
                case "/":
                    textDisplay.Text = (result / Double.Parse(textDisplay.Text)).ToString();
                    break;
                default:
                    break;

            }
            result = Double.Parse(textDisplay.Text);
            operation = "";

            //*************************************
            btnCleanHistory.Visible = true;
            rtb.AppendText(firstnum + "  "+secondnum + " = "+ "\n");
            rtb.AppendText("\n\t" + textDisplay.Text + "\n\n");

        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            textDisplay.Text = "0";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textDisplay.Text = "0";
            result = 0;
        }

        private void btnClear(object sender, EventArgs e)
        {
            rtb.Clear();
            if(lblHistory.Text=="")
            {
                lblHistory.Text = "there is no history yet";
            }
            btnCleanHistory.Visible = false;
            rtb.ScrollBars = 0;
        }

        private void rtbDisplay(object sender, EventArgs e)
        {

        }

        private void lblhistory(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            if(textDisplay.Text.Length >0)
            {
                textDisplay.Text = textDisplay.Text.Remove(textDisplay.Text.Length - 1, 1);
            }

            if(textDisplay.Text =="")
            {
                textDisplay.Text = "0";
            }
        }
    }
}
