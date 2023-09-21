using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace tankGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        float angle = 0, tank0Speed = 1;
        int pxTank0 = 210, pyTank0 = 150, dstTank0 = 50;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TranslateTransform(pxTank0, pyTank0, MatrixOrder.Append);
            g.DrawEllipse(Pens.White, -dstTank0 + 3, -dstTank0 + 3, 100, 100);
            g.ResetTransform();

            g.FillEllipse(Brushes.Yellow, pxTank0 + 5, pyTank0 - 10, 20, 20);

            int x = (int)(pxTank0 + dstTank0 * Math.Sin(angle * Math.PI / 182.5f));
            int y = (int)(pxTank0 + dstTank0 * Math.Cos(angle * Math.PI / 182.5f));
            g.FillEllipse(Brushes.Aqua, (int)x, (int)y, 10, 10);
            angle -= tank0Speed; 
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
