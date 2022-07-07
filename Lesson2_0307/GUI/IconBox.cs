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
    }
}
