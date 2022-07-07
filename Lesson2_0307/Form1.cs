using Microsoft.Win32;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            using(RegistryKey reg_key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop"))
                this.BackgroundImage = Image.FromFile(reg_key.GetValue("WallPaper").ToString());
            this.BackgroundImageLayout = ImageLayout.Stretch;
           


        }
        private void Get_Icons()
        {
            int x = 0, y = 0;
            using (RegistryKey reg_key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
            //using (RegistryKey reg_key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
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

                            //Button button = new Button();
                            //button.Location = new Point(x, y);
                            //button.Size = new Size(30, 30);
                            //button.BackgroundImage = img;
                            //button.BackgroundImageLayout = ImageLayout.Stretch;
                            //button.Text = icon_name;
                            ////button.ImageAlign = ContentAlignment.TopCenter;
                            //button.TextAlign = ContentAlignment.BottomCenter;
                            ////button.TextImageRelation = TextImageRelation.ImageAboveText;
                            //Controls.Add(button);

                            PictureBox pict = new PictureBox();
                            pict.Location = new Point(x, y);
                            pict.Size = new Size(30, 30);
                            pict.Image = img;
                            pict.BackColor = System.Drawing.Color.Transparent;
                            Controls.Add(pict);

                            Label label = new Label();
                            label.Text = icon_name;
                            label.Location = new Point(x, y + 35);
                            label.Size = new Size(30, 10);
                            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                            label.BackColor = System.Drawing.Color.Transparent;
                            label.ForeColor = Color.White;
                            Controls.Add(label);

                            x += 50;
                            if (x >= 500) 
                            { 
                                y += 50;
                                x = 0;
                            }
                        }
                        catch (Exception ex)
                        {

                            //MessageBox.Show(ex.Message);
                            string new_icon_path = icon_path.Remove(icon_path.Length - 2);
                            try
                            {

                                Image img = Icon.ExtractAssociatedIcon(new_icon_path).ToBitmap();
                                PictureBox pict = new PictureBox();
                                pict.Location = new Point(x, y);
                                pict.Size = new Size(30, 30);
                                pict.Image = img;
                                pict.BackColor = System.Drawing.Color.Transparent;
                                Controls.Add(pict);

                                Label label = new Label();
                                label.Text = icon_name;
                                label.Location = new Point(x, y + 35);
                                label.Size = new Size(30, 10);
                                label.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                                label.BackColor = System.Drawing.Color.Transparent;
                                label.ForeColor = Color.White;
                                Controls.Add(label);

                                x += 50;
                                if (x >= 500) 
                                { 
                                    y += 50;
                                    x = 0;
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




        //private void Getinstalledsoftware()
        //{
        //    //Declare the string to hold the list:
        //    string Software = null;

        //    //The registry key:
        //    string SoftwareKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
        //    using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(SoftwareKey))
        //    {
        //        //Let's go through the registry keys and get the info we need:
        //        foreach (string skName in rk.GetSubKeyNames())
        //        {
        //            using (RegistryKey sk = rk.OpenSubKey(skName))
        //            {
        //                try
        //                {
        //                    //If the key has value, continue, if not, skip it:
        //                    if (!(sk.GetValue("DisplayName") == null))
        //                    {
        //                        //Is the install location known?
        //                        if (sk.GetValue("InstallLocation") == null)
        //                            Software += sk.GetValue("DisplayName") + " - Install path not known\n"; //Nope, not here.
        //                        else
        //                            Software += sk.GetValue("DisplayName") + " - " + sk.GetValue("InstallLocation") + "\n"; //Yes, here it is...
        //                    }
        //                    PictureBox pictureBox = new PictureBox();
        //                    Icon ico = Icon.ExtractAssociatedIcon(Software);





        //                }
        //                catch (Exception ex)
        //                {
        //                    //No, that exception is not getting away... :P
        //                }
        //            }
        //        }
        //    }

        //}

    }
}
