using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Randomer
{

    public partial class MainForm : Form
    {

        public static bool numberOrNot = true;
        public static int ranSmall = 0;
        public static int ranBig = 0;
        public static bool ifInfinite = false;
        public static int timesCanBePick = 0;
        public static int textSize = 0;
        public static Color fontColor, backColor;
        public static string[] items;
        public static ArrayList totalItems = new ArrayList();
        ArrayList a = new ArrayList(); //This is for adding "totalItems" adding itself.


        public static bool edited = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fontColor = Color.FromName("Black");
            backColor = Color.FromName("White");
            pictureBox1.BackColor = Color.FromName("Black");
            pictureBox2.BackColor = Color.FromName("White");
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void File_Opening(object sender, CancelEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!radioButton2.Checked)
            {
                editItems.Enabled = false;
            }
            else
            {
                editItems.Enabled = true;
            }
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!radioButton1.Checked)
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
            }
            else
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;


            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                numericUpDown3.Enabled = false;
            }
            else
            {
                numericUpDown3.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
                fontColor = colorDialog1.Color;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.BackColor = colorDialog1.Color;
                backColor = colorDialog1.Color;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }



        private void editItems_Click(object sender, EventArgs e)
        {

            Form2 f2 = new Form2();

            DialogResult result = f2.ShowDialog();
            if (result == DialogResult.OK)
            {
                items = Form2.text;
                edited = Form2.edited;
                f2.Close();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            MessageBox.Show("Randomer (Version 1.0) \nCopyright (C) 2021 Henry Chan\nThis program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program.If not, see \n< https://www.gnu.org/licenses/>. \nRandomer (Version 0.1 or any later version) and every source code/file/folder and applications in this directory or subdirectory of this folder is licensed under GNU GPL Version3 or any later version.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {
            totalItems.Clear();
            a.Clear();
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    if (fontColor == backColor)
                    {
                        DialogResult r = MessageBox.Show("The font color has been set the same with background color, do you want to change it?", "Color warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (r == DialogResult.Yes)
                        {
                            goto end;
                        }
                    }
                    if (radioButton1.Checked)
                    {
                        numberOrNot = true;
                    }
                    else
                    {
                        numberOrNot = false;
                    }
                    ranSmall = Convert.ToInt32(numericUpDown1.Value);
                    ranBig = Convert.ToInt32(numericUpDown2.Value);
                    if (ranBig <= ranSmall && numberOrNot)
                    {
                        MessageBox.Show("The \"From\" number cannot be greater than or equals to the \"to\" number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto end;
                    }
                    if (!checkBox1.Checked)
                    {
                        timesCanBePick = Convert.ToInt32(numericUpDown3.Value);
                        ifInfinite = false;
                    }
                    else
                    {
                        ifInfinite = true;
                    }
                    textSize = Convert.ToInt32(numericUpDown4.Value * 8 * 2);
                    ranSmall = Convert.ToInt32(numericUpDown1.Value);
                    ranBig = Convert.ToInt32(numericUpDown2.Value);
                    textSize = Convert.ToInt32(numericUpDown4.Value * 8 * 2);
                    if (numberOrNot)
                    {
                        for (int i = ranSmall; i <= ranBig; i++)
                        {
                            totalItems.Add(i.ToString());
                            a.Add(i.ToString());
                        }

                    }
                    else
                    {
                        try
                        {
                            totalItems.AddRange(items);
                            a.AddRange(items);
                        }
                        catch (ArgumentNullException)
                        {
                            MessageBox.Show("Item list is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            goto end;
                        }

                    }

                    if (!ifInfinite)
                    {
                        for (int i = 1; i < timesCanBePick; i++)
                        {
                            totalItems.AddRange(a);
                        }
                    }
                    Form3 f = new Form3();
                    f.ShowDialog();
                end:;
                    break;
            }
        }
    }
}
