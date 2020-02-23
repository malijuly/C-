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
	public partial class About : Form
	{
		public About()
		{
			InitializeComponent();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("https://www.facebook.com/magdalena.lipiec.9");
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}
	}
}
