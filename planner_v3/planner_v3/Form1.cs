using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace planner_v3
{
    public partial class Form1 : Form
    {
        DateTime thisDay = DateTime.Today;
        List<RichTextBox> listka = new List<RichTextBox>();

        public RichTextBox RichTextBox { get; private set; }

        public Form1()
        {
            InitializeComponent();
           
            label1.Text = thisDay.ToString("d");

          

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_prev_Click(object sender, EventArgs e)
        {
            thisDay = thisDay.AddDays(-1);
            label1.Text = thisDay.ToString("d");
            richTextBox1.Text = "";
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            
            thisDay = thisDay.AddDays(1);
            label1.Text = thisDay.ToString("d");
            richTextBox1.Text = "";
           
        
        }

        private void btn_today_Click(object sender, EventArgs e)
        {
            DateTime thisDay = DateTime.Today;
            label1.Text = thisDay.ToString("d");

        }
    }
}
