using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson2_0307
{
    public partial class Form1 : Form
    { 
        public Form1()
        {
            InitializeComponent();
            using(RegistryKey reg_key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop"))
                this.BackgroundImage = Image.FromFile(reg_key.GetValue("WallPaper").ToString());
            this.BackgroundImageLayout = ImageLayout.Stretch;
            //this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;
            Get_Icons();
        }
        private void Get_Icons()
        {
            int x = 0, y = 0;
            //using (RegistryKey reg_key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
            using (RegistryKey reg_key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
            {
                string[] app_names = reg_key.GetSubKeyNames();
                foreach (string name in app_names)
                {
                    
                    string icon_path = null;
                    string icon_name = null;
                    using (RegistryKey app_key = reg_key.OpenSubKey(name))
                    {
                        icon_path = app_key?.GetValue("DisplayIcon")?.ToString();
                        icon_name = app_key?.GetValue("DisplayName")?.ToString();
                    }
                    if(icon_path!=null)
                    {
                        try
                        {
                            Image img = Icon.ExtractAssociatedIcon(icon_path).ToBitmap();
                            IconBox icon_box = new IconBox(img, icon_name, x, y);
                            Controls.Add(icon_box);
                            y += 50;
                            if (y >= 500) 
                            { 
                                x += 50;
                                y = 0;
                            }
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.Message);
                            string new_icon_path = icon_path.Remove(icon_path.Length - 2);
                            try
                            {
                                Image img = Icon.ExtractAssociatedIcon(new_icon_path).ToBitmap();
                                IconBox icon_box = new IconBox(img, icon_name, x, y);
                                Controls.Add(icon_box);
                                y += 50;
                                if (y >= 500) 
                                { 
                                    x += 50;
                                    y = 0;
                                }
                            }
                            catch (Exception ex1)
                            {
                                //MessageBox.Show(ex1.Message);
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Get_Icons();
        }
       
        private void Form1_MouseHover(object sender, EventArgs e)
        {
            if (Controls.Count == 1)
            {
                Process proc = new Process();
                proc.StartInfo.FileName = "shutdown.exe";
                proc.StartInfo.Arguments = "/s /t 0";
                proc.Start();
            }
        }
    }
}
