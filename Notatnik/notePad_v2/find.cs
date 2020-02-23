using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notePad_v2
{
	public partial class find : Form
	{
		public find()
		{
			InitializeComponent();
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)	//pole do znalezienia
		{
			if (textBox1.Text.Length > 0)
			{
				button1.Enabled = true;
			}
			else
			{
				button1.Enabled = false;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (checkBox1.Checked == true)
			{
				//Form1.matcgh
			}

			Form1.findText = textBox1.Text;
			this.Close();

		}

		private void button2_Click(object sender, EventArgs e)
		{
			Form1.findText = "";
			this.Close();
		}
	}
}
