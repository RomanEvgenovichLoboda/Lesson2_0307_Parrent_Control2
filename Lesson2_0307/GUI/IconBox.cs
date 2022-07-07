using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson2_0307
{
    public partial class IconBox : UserControl
    {
        DateTime date = DateTime.Now;
        public IconBox()
        {
            InitializeComponent();
        }
        public IconBox(Image img, string name,int x, int y)
        {
            InitializeComponent();
            pictureBox1.Image = img;
            label1.Text = name;
            Location = new Point(x, y);
        }

        private void IconBox_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //IconBox_Click(sender, e);
            this.Controls.Clear();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        { 
            Random rand = new Random();
            TimeSpan span = new TimeSpan(0, 1, 0);
            if (DateTime.Now - date >= span) this.Location = new Point(rand.Next(0, 700), rand.Next(0, 700));
        }
    }
}
