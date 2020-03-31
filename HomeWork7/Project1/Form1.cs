using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        int n = 10;
        double leng = 100;
        double th=-Math.PI / 2;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        private Pen pen=new Pen(Color.Red, 1);

        public Form1()
        {
            InitializeComponent();
            SetDefaultText();
            SetDefaultTrackBar();
        }

        private void SetDefaultText()
        {
            textBox_n.Text = "10";
            textBox_leng.Text = "100";
            textBox_th1.Text = "30";
            textBox_th2.Text = "20";
        }

        private void SetDefaultTrackBar()
        {
            trackBar_per1.Maximum = 10;
            trackBar_per1.Minimum = 0;
            trackBar_per1.Value = 6;
            trackBar_per2.Maximum = 10;
            trackBar_per2.Minimum = 0;
            trackBar_per2.Value = 7;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(int.TryParse(textBox_n.Text, out n)==false)
                n=10;
            if(double.TryParse(textBox_leng.Text, out leng)==false)
                leng=100;
            per1 = trackBar_per1.Value/10.0;
            per2 = trackBar_per2.Value/10.0;
            if(double.TryParse(textBox_th1.Text, out double _th1))
                _th1=30;
            if(double.TryParse(textBox_th2.Text, out double _th2))
                _th2=20;
            th1 = _th1 * Math.PI / 180;
            th2= _th2 * Math.PI / 180;
            if (graphics == null) graphics = this.panel1.CreateGraphics();
            DrawCayleyTree(n, 200, 310, leng, th);
        }
        
        void DrawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            DrawLine(x0, y0, x1, y1);
            DrawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            DrawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }

        void DrawLine(double x0,double y0,double x1,double y1)
        {
                graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog ColorForm = new ColorDialog();
            if (ColorForm.ShowDialog() == DialogResult.OK)
            {
                 pen.Color=ColorForm.Color;
            }
        }

        private void textBox_n_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_n.Text))
            {
                textBox_n.Text = "10";
            }
        }

        private void textBox_leng_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_leng.Text))
            {
                textBox_n.Text = "100";
            }
        }

        private void textBox_th1_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_th1.Text))
            {
                textBox_n.Text = "30";
            }
        }

        private void textBox_th2_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_th2.Text))
            {
                textBox_n.Text = "20";
            }
        }
    }
}
