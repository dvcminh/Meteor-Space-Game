using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Bida
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 50;
            timer1.Start();

            timer2.Interval = 50;
            timer2.Start();
        }
        Point p = new Point(0, 0);
        List<cRectangle> cc = new List<cRectangle>();


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach(var shape in cc)
            {
                shape.draw(e.Graphics);
            }            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var shape in cc)
            {
                shape.y += 5;
            }
            this.Invalidate();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random Random = new Random();

            p.X = Random.Next(1000);
            p.Y = 50;
            cRectangle rect = new cRectangle(p.X, p.Y, 50, 50);

            cc.Add(rect);

            this.Invalidate();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Image image = Image.FromFile("D:\\Môn học\\Năm 2\\HK 1\\Lập trình trực quan\\BT lớp\\18-11-2022\\Bida\\Bida\\Resources\\spiked ship 3.PNG");
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(10, 10, 20, 20);

            g.DrawImage(image, rect);

            int x = pictureBox1.Location.X;
            int y = pictureBox1.Location.Y;

            if (e.KeyCode == Keys.D) x += 10;
            else if (e.KeyCode == Keys.A) x -= 10;
            else if (e.KeyCode == Keys.W) y -= 10;
            else if (e.KeyCode == Keys.S) y += 10;
            else if (e.KeyCode == Keys.Space)
            {
                /*
                Image image = Image.FromFile("D:\\Môn học\\Năm 2\\HK 1\\Lập trình trực quan\\BT lớp\\18-11-2022\\Bida\\Bida\\Resources\\meteor_PNG22.png");
                Rectangle rect = new Rectangle(x, y+10, image.Width, image.Height);
                g.DrawImage(image, rect);*/
            }

            pictureBox1.Location = new Point(x, y);
        }

        
    }
    public class cRectangle
    {
        public int x;
        public int y;
        public int a;
        public int b;

        public cRectangle(int x, int y, int a, int b)
        {
            this.x = x;
            this.y = y;
            this.a = a;
            this.b = b; 
        }

        public void draw(Graphics g)
        {
            Rectangle rect = new Rectangle(this.x,this.y,this.a,this.b);
            Image image = Image.FromFile("D:\\Môn học\\Năm 2\\HK 1\\Lập trình trực quan\\BT lớp\\18-11-2022\\Bida\\Bida\\Resources\\laserBullet.png");
            g.DrawImage(image, rect);
        }     
    }

    public class SpaceShip
    {
        int x;
        int y;
    }
}
