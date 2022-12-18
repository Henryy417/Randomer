using System;
using System.Windows.Forms;

namespace Randomer
{
    public partial class Form2 : Form
    {
        public static string[] text;
        public static string oringinalText = "";
        public static bool edited = true;

        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            text = textBox1.Text.Split("\r\n");
            label3.Text = text.Length.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (MainForm.edited)
            {
                string[] ori = MainForm.items;
                foreach (string item in ori)
                {
                    textBox1.AppendText(item);
                    if (Array.IndexOf(ori, item) != ori.Length - 1)
                    {
                        textBox1.AppendText("\r\n");
                    }
                }
            }
            oringinalText = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("You didn't type anything!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto end;
            }
            if (oringinalText == textBox1.Text)
            {
                text = textBox1.Text.Split("\r\n");
                edited = false;
            }
            if (Convert.ToInt32(label3.Text) > 200000000)
            {
                MessageBox.Show("Total items cannot be larger than 200000000!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                text = textBox1.Text.Split("\r\n");
                DialogResult = DialogResult.OK;
            }
        end:;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            text = textBox1.Text.Split("\r\n");
        }
    }
}
