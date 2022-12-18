using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace Randomer
{
    public partial class Form3 : Form
    {
        public int oringinalItems,nowItems;
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Font = new Font(FontFamily.GenericSansSerif,MainForm.textSize);
            label1.ForeColor = MainForm.fontColor;
            this.BackColor = MainForm.backColor;
            oringinalItems = MainForm.totalItems.Count;
        }

        public ArrayList arr = MainForm.totalItems;

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Space:
                    Pick();
                    break;
                case Keys.F1:
                    Fullscreen();
                    break;
                case Keys.Escape:
                    ExitFS();
                    break;
                case Keys.Enter:
                    this.Close();
                    break;
                case Keys.F2:
                    if(!textBox1.Visible)
                    {
                        textBox1.Visible = true;
                    }
                    else
                    {
                        textBox1.Visible = false;
                    }
                    break;
            }
        }
        private void Pick()
        {
            if(!MainForm.ifInfinite)
            {
                if(arr.Count != 0)
                {
                    Random ran = new Random();
                    int index = ran.Next(0,arr.Count);
                    string target = arr[index].ToString();
                    arr.RemoveAt(index);
                    label1.Text = target;
                    textBox1.AppendText(target + " picked, " + "[" + arr.Count + "/" + oringinalItems + "] left" + "\r\n");
                }
                else
                {
                    label1.Text = "Ended! Press ENTER to leave.";

                }
            }
            else if (MainForm.ifInfinite)
            {
                    Random ran = new Random();
                    int index = ran.Next(0, arr.Count);
                    string target = arr[index].ToString();
                    label1.Text = target;
                textBox1.AppendText(target + "picked" + "\n[" + arr.Count + "/" + oringinalItems + "] left");
            }
        }
        private void Fullscreen()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }
        private void ExitFS()
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            arr.Clear();
        }
    }
}
