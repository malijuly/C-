using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notePad_v2
{
	public partial class Form1 : Form
	{

//********************************************************ZMIENNE********************************************************
		string sciezka_pliku = "";
		public static string findText;
		int d;
		public static Boolean matchcase;
		public static string replaceText;
//***********************************************************************************************************************

		public Form1()
		{
			InitializeComponent();
		}

		//****************************************************************************************FILE******************************************************************************************
		private void openToolStripMenuItem_Click(object sender, EventArgs e)	//OPEN
		{
			openFileDialog1.ShowDialog();
			StreamReader sr = new StreamReader(openFileDialog1.FileName);
			richTextBox1.Text = sr.ReadToEnd();


		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)		//NEW
		{
			richTextBox1.Clear();
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)	//SAVE
		{
			if (sciezka_pliku == "")
			saveAsToolStripMenuItem_Click(sender, e);
			File.WriteAllText(sciezka_pliku, richTextBox1.Text);
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)	//SAVE AS	
		{
			if (System.Windows.Forms.DialogResult.OK == saveFileDialog1.ShowDialog())
			{
				sciezka_pliku = saveFileDialog1.FileName;
				File.WriteAllText(sciezka_pliku, richTextBox1.Text);
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)	//EXIT
		{
			Application.Exit();
		}
		//****************************************************************************************~FILE~****************************************************************************************

		//****************************************************************************************EDIT******************************************************************************************
		private void undoToolStripMenuItem_Click(object sender, EventArgs e)	//UNDO
		{
			richTextBox1.Undo();
		}

		private void cutToolStripMenuItem_Click(object sender, EventArgs e)		//CUT
		{
			richTextBox1.Cut();
		}

		private void copyToolStripMenuItem_Click(object sender, EventArgs e)	//COPY
		{
			richTextBox1.Copy();
		}

		private void pasteToolStripMenuItem_Click(object sender, EventArgs e)	//PASTE
		{
			richTextBox1.Paste();
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)	//DELETE
		{
			richTextBox1.SelectedText = "";
		}

		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{
			//************************PODSWIELENIE NARZEDZI DO EDYCJI************************
			if (richTextBox1.Text.Length > 0) 
			{
				//MAIN MENU
				undoToolStripMenuItem.Enabled = true;
				cutToolStripMenuItem.Enabled = true;
				copyToolStripMenuItem.Enabled = true;
				deleteToolStripMenuItem.Enabled = true;
				findToolStripMenuItem.Enabled = true;
				findNextToolStripMenuItem.Enabled = true;
				selectAllToolStripMenuItem.Enabled = true;
				//RIGHT CLICK MENU
				cToolStripMenuItem.Enabled = true;
				cutToolStripMenuItem1.Enabled = true;
				copyToolStripMenuItem1.Enabled = true;
				deleteToolStripMenuItem1.Enabled = true;
				selectAllToolStripMenuItem1.Enabled = true;
			}
			else
			{
				//MAIN MENU
				undoToolStripMenuItem.Enabled = false;
				cutToolStripMenuItem.Enabled = false;
				copyToolStripMenuItem.Enabled = false;
				deleteToolStripMenuItem.Enabled = false;
				findToolStripMenuItem.Enabled = false;
				findNextToolStripMenuItem.Enabled = false;
				selectAllToolStripMenuItem.Enabled = false;
				//RIGHT CLICK MENU
				cToolStripMenuItem.Enabled = false;
				cutToolStripMenuItem1.Enabled = false;
				copyToolStripMenuItem1.Enabled = false;
				deleteToolStripMenuItem1.Enabled = false;
				selectAllToolStripMenuItem1.Enabled = false;
			}
			//********************************************************************************
			toolStripStatusLabel3.Text = richTextBox1.Text.Length.ToString();     //NUMBER OF SIGNS
			toolStripStatusLabel5.Text = richTextBox1.Lines.Length.ToString();	  //NUMBER OF LINES

		}

		private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)	//SELECT ALL
		{
			richTextBox1.SelectAll();	
		}

		private void timeToolStripMenuItem_Click(object sender, EventArgs e)	   //DATE/TIME
		{
			richTextBox1.Text += DateTime.Now.ToString();	//+= zeby mozna bylo dodac kilka
		}

		private void findToolStripMenuItem_Click(object sender, EventArgs e)    	//FIND
		{
			find r = new find();
			r.ShowDialog();

			if (findText != "")
			{
				d = richTextBox1.Find(findText);
			}
		}

		private void findNextToolStripMenuItem_Click(object sender, EventArgs e)	//FIND NEXT	
		{
			if (findText != "")
			{
				d = richTextBox1.Find(findText, (d+1), richTextBox1.Text.Length, RichTextBoxFinds.MatchCase);
			}
			else
			{
				d = richTextBox1.Find(findText, (d + 1), richTextBox1.Text.Length, RichTextBoxFinds.None);
			}
		}

		private void changeToolStripMenuItem_Click(object sender, EventArgs e)	//REPLACE
		{
			Replace r = new Replace();
			r.ShowDialog();
			richTextBox1.Find(findText);
			richTextBox1.SelectedText = replaceText;
		}
//****************************************************************************************~EDIT~****************************************************************************************

//****************************************************************************************FORMAT****************************************************************************************
		private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)		   //WORD WRAP	
		{
			if (richTextBox1.WordWrap == true)
			{
				richTextBox1.WordWrap = false;
			}
			else
			{
				richTextBox1.WordWrap = true;
			}

		}

		private void fontToolStripMenuItem_Click(object sender, EventArgs e)				//FONT
		{
			fontDialog1.ShowDialog();
			richTextBox1.Font = fontDialog1.Font;
		}

		private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)		//BACKGROUND COLOR
		{
			colorDialog1.ShowDialog();
			richTextBox1.BackColor = colorDialog1.Color;
		}

		private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)			//FONT COLOR
		{
			colorDialog1.ShowDialog();
			richTextBox1.ForeColor = colorDialog1.Color;
		}
		//****************************************************************************************~FORMAT~**************************************************************************************

		//****************************************************************************************HELP******************************************************************************************
		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			About okienko  = new About();
				okienko.ShowDialog();
		}
		//****************************************************************************************~HELP~****************************************************************************************

		//****************************************************************************************CLICKK RIGHT**********************************************************************************
		private void cutToolStripMenuItem1_Click(object sender, EventArgs e)	//CUT
		{
			richTextBox1.Cut();
		}

		private void cToolStripMenuItem_Click(object sender, EventArgs e)	//UNDO
		{
			richTextBox1.Undo();
		}

		private void copyToolStripMenuItem1_Click(object sender, EventArgs e)	//COPY
		{
			richTextBox1.Copy();
		}

		private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)	//PASTE
		{
			richTextBox1.Paste();
		}

		private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)	//DELETE
		{
			richTextBox1.SelectedText = "";
		}

		private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)	//SELECT ALL
		{
			richTextBox1.SelectAll();
		}
		//****************************************************************************************~CLICKK RIGHT~********************************************************************************

		private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{	 
		}

		private void toolStripStatusLabsel3_Click(object sender, EventArgs e)
		{
		}

		private void label2_Click(object sender, EventArgs e)
		{
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
		}

		private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{
		
		}

		private void toolStripStatusLabel2_Click(object sender, EventArgs e)
		{
			
		
		}

		private void label2_Click_1(object sender, EventArgs e)	
		{
			
		}

		private void toolStripLabel1_Click(object sender, EventArgs e)  
		{
			
		}

		private void toolStripStatusLabel2_Click_1(object sender, EventArgs e)
		{

		}

		private void toolStripStatusLabel3_Click(object sender, EventArgs e)  
		{
			
			
		}

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}