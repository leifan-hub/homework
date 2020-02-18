using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        double num1=0, num2=-1,result=0;
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("+");
            comboBox1.Items.Add("-");
            comboBox1.Items.Add("*");
            comboBox1.Items.Add("/");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double cleanNum = 0;

            if (!double.TryParse(textBox1.Text, out cleanNum)|| !double.TryParse(textBox2.Text, out cleanNum))
                { 
                    MessageBox.Show("This is not valid input. Please enter an integer value");
                }
                else
                {
                    num1 = double.Parse(textBox1.Text);
                    num2 = double.Parse(textBox2.Text);
                }

            switch (comboBox1.SelectedItem.ToString())

            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        MessageBox.Show("This number can not be zero, please type another number");
                    }
                    else
                        result = num1 / num2;
                    break;
                default:
                    break;
            }
            if (num2 == 0)
                label1.Text = "result";
            else
               label1.Text = result.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
