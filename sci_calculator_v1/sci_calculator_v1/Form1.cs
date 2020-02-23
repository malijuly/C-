using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sci_calculator_v1
{
	public partial class Form1 : Form
	{
		//**********************************ZMIENNE GLOBALNE**********************************
		double result;  //wynik
		string artiOperator;
		double firstNumber;
		bool operatorClick = false;
        //zmienne do wykresu stre
        //double wartoscPoczatkowa = 0;
        //double wartoscKoncowa = 20;
        //
        //int a, b, c, d, e;
        //double[] osY = new double[3000];
        //double[] osX = new double[3000];

        //int m = 0;

        //wykres lepszy
        public double xStart = -15;   //wartosc poczatkowa 
        public double xStop = 15;     //wartosc koncowa
        public double co_ile = 0.5;       //odstep miedzy punktami

        //**********************************~ZMIENNE GLOBALNE**********************************
        public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)	//rozmiar okna Podstawowego
		{
			label1.Text = String.Empty;
			this.Width = 287;   //poczatkowa szerokosc apki
            scientificTextBox1.Width = 255; //szerokosc tekstboxu
            label1.Width = 255;             //szerokość labela
        }

		private void button1_Click(object sender, EventArgs e) //wypisywanie cyfr
		{
			if (scientificTextBox1.Text == "0" || operatorClick)
				scientificTextBox1.Clear();

			operatorClick = false;
			Button button = (Button)sender;

			if(button.Text == ",")	//liczby po przecinku
			{
				if(!scientificTextBox1.Text.Contains("."))
					scientificTextBox1.Text += button.Text;
			}
			else
			{
				scientificTextBox1.Text += button.Text;	
			}

			

			
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void button19_Click(object sender, EventArgs e)	//klawisz <x - kasowanie jeden cyfry do tylu
		{
			int index = scientificTextBox1.Text.Length;
			index--;
			scientificTextBox1.Text = scientificTextBox1.Text.Remove(index);

			if(scientificTextBox1.Text == string.Empty)
			{
				scientificTextBox1.Text = "0";
			}
		}

		private void button17_Click(object sender, EventArgs e)	//klawisz CE - kasowanie wszystkich liczb
		{
			scientificTextBox1.Text = "0";

		}

		private void button20_Click(object sender, EventArgs e)	//klawisz +-
		{
			result = double.Parse(scientificTextBox1.Text);
			result = result * -1;
			scientificTextBox1.Text = result.ToString();
		}

		private void button16_Click(object sender, EventArgs e)	//znak operacyjne
		{
			firstNumber = double.Parse(scientificTextBox1.Text);
			Button btn = (Button)sender;
			artiOperator = btn.Text;
			operatorClick = true;
			label8.Text = firstNumber.ToString() + artiOperator;

		}

		private void button12_Click(object sender, EventArgs e)	//znak rowna sie
		{
			switch (artiOperator)
			{
				case "+":
					scientificTextBox1.Text = (firstNumber + double.Parse(scientificTextBox1.Text)).ToString();
					break;

				case "-":
					scientificTextBox1.Text = (firstNumber - double.Parse(scientificTextBox1.Text)).ToString();
					break;

				case "*":
					scientificTextBox1.Text = (firstNumber * double.Parse(scientificTextBox1.Text)).ToString();
					break;

				case "/":
					scientificTextBox1.Text = (firstNumber / double.Parse(scientificTextBox1.Text)).ToString();
					break;

				case "EXP":
					double pow = double.Parse(scientificTextBox1.Text);
					double ans = Math.Exp(pow * Math.Log(firstNumber * 4));
					scientificTextBox1.Text = ans.ToString();
					break;

				case "MOD":
					scientificTextBox1.Text = (firstNumber % double.Parse(scientificTextBox1.Text)).ToString();
					break;
			}
		}

			private void scientificToolStripMenuItem_Click(object sender, EventArgs e)	
		{
            this.Width = 564;
            scientificTextBox1.Width = 516; //szerokosc tekstboxu
            label1.Width = 516;             //szerokosc labela
        }

		private void multiplyerToolStripMenuItem_Click(object sender, EventArgs e)  //rozmiar okna Multiply
		{
			this.Width = 883;
            scientificTextBox1.Width = 516; //szerokosc tekstboxu
            label1.Width = 516;             //szerokosc labela
        }

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)	//okno wyjscie
		{
			Application.Exit();
		}

		private void button22_Click(object sender, EventArgs e)	//przycisk PI
		{
			double val = Math.PI;
			scientificTextBox1.Text = val.ToString();
		}

		private void button27_Click(object sender, EventArgs e)	//przycisk LOG
		{
			double val = double.Parse(scientificTextBox1.Text);
			val = Math.Log10(val);
			scientificTextBox1.Text = val.ToString();
		}

		private void button24_Click(object sender, EventArgs e) //przycisk SQRT
		{
			double val = double.Parse(scientificTextBox1.Text);
			val = Math.Sqrt(val);
			scientificTextBox1.Text = val.ToString();
		}

		private void button21_Click(object sender, EventArgs e)	//przycisk x^2
		{
			double val = double.Parse(scientificTextBox1.Text);
			val = Math.Pow(val, 2);
			scientificTextBox1.Text = val.ToString();
		}

		private void button25_Click(object sender, EventArgs e)	//przycisk sinH
		{
			double val = double.Parse(scientificTextBox1.Text);
			val = Math.Sinh(val);
			scientificTextBox1.Text = val.ToString();
		}

		private void button23_Click(object sender, EventArgs e)	//przycisk SIN
		{
			double val = double.Parse(scientificTextBox1.Text);
			val = Math.Sin(val);
			scientificTextBox1.Text = val.ToString();
		}

		private void button29_Click(object sender, EventArgs e)	//przycisk DEC
		{
			try
			{
				int a = int.Parse(scientificTextBox1.Text);
				scientificTextBox1.Text = System.Convert.ToString(a, 10);
			}
			catch (Exception ex)
			{

				MessageBox.Show("ERROR" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void button34_Click(object sender, EventArgs e)	//przycisk x^3
		{
			double val = double.Parse(scientificTextBox1.Text);
			val = Math.Pow(val, 3);
			scientificTextBox1.Text = val.ToString();
		}

		private void button33_Click(object sender, EventArgs e)	//przycisk cosH
		{
			double val = double.Parse(scientificTextBox1.Text);
			val = Math.Cosh(val);
			scientificTextBox1.Text = val.ToString();
		}

		private void button30_Click(object sender, EventArgs e)	//przycisk COS
		{
			double val = double.Parse(scientificTextBox1.Text);
			val = Math.Cos(val);
			scientificTextBox1.Text = val.ToString();
		}
		
		private void button26_Click(object sender, EventArgs e)	//przycisk HEX
		{
			try
			{
				int a = int.Parse(scientificTextBox1.Text);
				scientificTextBox1.Text = System.Convert.ToString(a, 16);
			}
			catch (Exception ex)
			{

				MessageBox.Show("ERROR" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void button38_Click(object sender, EventArgs e)	//przycisk 1/x
		{
			double val = double.Parse(scientificTextBox1.Text);
			val = 1 / val;
			scientificTextBox1.Text = val.ToString();
		}

		private void button36_Click(object sender, EventArgs e)	//przycisk tanH
		{
			double val = double.Parse(scientificTextBox1.Text);
			val = Math.Tanh(val);
			scientificTextBox1.Text = val.ToString();
		}

		private void button40_Click(object sender, EventArgs e)	//przycisk TAN
		{
			double val = double.Parse(scientificTextBox1.Text);
			val = Math.Tan(val);
			scientificTextBox1.Text = val.ToString();
		}

		private void button37_Click(object sender, EventArgs e)	//przycisk BIN
		{
			try
			{
				int a = int.Parse(scientificTextBox1.Text);
				scientificTextBox1.Text = System.Convert.ToString(a, 2);
			}
			catch (Exception ex)
			{

				MessageBox.Show("ERROR" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void button39_Click(object sender, EventArgs e)	//przycisk ln X (case EXP)
		{
			double val = double.Parse(scientificTextBox1.Text);
			val = Math.Log(val);
			scientificTextBox1.Text = val.ToString();
		}

	

		private void button31_Click(object sender, EventArgs e)	//przycisk OCT
		{
			try
			{
				int a = int.Parse(scientificTextBox1.Text);
				scientificTextBox1.Text = System.Convert.ToString(a, 8);
			}
			catch (Exception ex)
			{

				MessageBox.Show("ERROR" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void button35_Click(object sender, EventArgs e)	//przycisk %
		{
			double val = double.Parse(scientificTextBox1.Text);
			val = val / 100;
			scientificTextBox1.Text = val.ToString();

		}

		private void multiplyTableButton_Click(object sender, EventArgs e)	//Multiply Button
		{
			float number = 0f;

			if(numberTableTextBox.Text.Trim() == string.Empty)
			{
				MessageBox.Show("Please enter any number", "Erros", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try
			{
				number = Convert.ToSingle(numberTableTextBox.Text);
			}
			catch
			{
				MessageBox.Show("Invalid number", "Erros", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			for (int i = 0; i <= 10; i++)
			{
				richTextBox1.Text += number + " * " + i + " = " + number * i + "\n";
			}
		}

		private void label8_Click(object sender, EventArgs e)
		{
		}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
		{

		}

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void resetTableButton_Click(object sender, EventArgs e) //RESER OD MULTIPLY
        {
            richTextBox1.Text = "";         //wyczysc pole pokazujace
            numberTableTextBox.Text = "";   //wyczyszc tekstbox
        }

        private void button42_Click(object sender, EventArgs e) //PRZYCISK NEW (wykres)
        {
            chart1.Series[0].Points.Clear();    //czysczenie wykresu
            textBox1.Text = ""; //czyszczenie tekstboxu
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about_calc okienko = new about_calc();
            okienko.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void basicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 287;   //poczatkowa szerokosc apki
            scientificTextBox1.Width = 255; //szerokosc tekstboxu
            label1.Width = 255;             //szerokość labela
        }

        private void btn_zoom_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[1].AxisX.ScaleView.Zoomable = true;

        }

        private void plotToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Width = 1375;
            scientificTextBox1.Width = 516; //szerokosc tekstboxu
            label1.Width = 516;             //szerokosc labela
        }

//***************************************************************RYSOOWANIE WYKRESU***************************************************************
        private void button41_Click(object sender, EventArgs e) //PRZYCISK OD RYSOWANIA WYKRESÓW
		{
            int ileKrokow = (int)((xStop - xStart) / co_ile);
            for (int i = 0; i < ileKrokow; i++)
            {
                double wartosc_x = xStart + i * co_ile;
                double result = obliczJedenPunkt(wartosc_x);


                chart1.Series[0].Points.AddXY(wartosc_x, result); //rysowanie wykresu
            }
        }



        double obliczJedenPunkt(double wartosc_punktu)
        {

            var strings = Regex.Split(textBox1.Text, "(?=[-+])");

            List<double> values_to_add = new List<double>();

            foreach (var item in strings)
            {
                if (item != "")
                {
                    var multiplications = item.Split('*');

                    List<double> values_to_multiplication = new List<double>();

                    foreach (var multi in multiplications)
                    {
                        if (multi.Contains('^'))
                        {
                            var bufor2 = multi.Split('^');

                            foreach (var powers in bufor2)
                            {

                                if (powers.Contains('x'))
                                {

                                }
                                else
                                {
                                    double temp = 0;
                                    double power = 0;
                                    double.TryParse(powers, out power);
                                    temp = Math.Pow(wartosc_punktu, power);

                                    values_to_multiplication.Add(temp);
                                }
                            }
                        }
                        else
                        {
                            if (multi.Contains('x'))
                            {
                                values_to_multiplication.Add(wartosc_punktu);
                            }
                            else
                            {
                                double temp = 0;
                                Double.TryParse(multi, out temp);
                                values_to_multiplication.Add(temp);
                            }


                        }


                        double multiplication_result = 1;

                        foreach (var multi_item in values_to_multiplication)
                        {
                            multiplication_result = multiplication_result * multi_item;
                        }

                        values_to_add.Add(multiplication_result);

                    }

                }

            }
            double wynik = 0;
            foreach (var item in values_to_add)
            {
                wynik = wynik + item;
            }

//******************************zwróć wynik******************************
            return wynik;

        }
//***************************************************************~RYSOOWANIE WYKRESU~***************************************************************


        private void chart1_Click_1(object sender, EventArgs e)

		{

		}
	}
}
