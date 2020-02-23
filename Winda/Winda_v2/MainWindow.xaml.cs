using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Winda_v2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
//**************************ZMIENNE**************************
		DispatcherTimer timer = new DispatcherTimer();
		public double czas = 0;
		public int lewo = 0;
		int zmienna = 0;
        int blokadka = 0;
		private double? y;
        int aktPozycja = 0; //POZYCJA WINDY
		int otworzDrzwi = -100; //do otwarcia drzwi przy animacji - O ILE MA SIE RZESUNAC
//**************************~ZMIENNE~**************************

		public MainWindow()
		{
			InitializeComponent();
          
        }

//***********************************************************************PIETRO PIERWSZE***********************************************************************
		private void Pietro1_Click(object sender, RoutedEventArgs e)
		{
            if (blokadka == 0)
            {
                DoubleAnimation anim1 = new DoubleAnimation();
				anim1.Completed += P1_Completed;
				anim1.From = aktPozycja;
				anim1.To = 200;
				anim1.Duration = TimeSpan.FromMilliseconds(1000);
				anim1.AccelerationRatio = 0.01;

                TranslateTransform anim1_tr = new TranslateTransform(0, 100);
				anim1_tr.BeginAnimation(TranslateTransform.YProperty, anim1);

                kwadrat.RenderTransform = anim1_tr;	//ruch windy
                drzwi.RenderTransform = anim1_tr;	//ruch drzwi w dol
				blokadka = 1;	//ENDIF
			}
		}

		private void P1_Completed(object sender, EventArgs e)	//po skonczonej pierwszej symualci
		{
				DoubleAnimation anim1Com = new DoubleAnimation();
			anim1Com.Completed += P1c_Completed;
			anim1Com.From = 0;
			anim1Com.To = otworzDrzwi;
			anim1Com.Duration = TimeSpan.FromMilliseconds(1500);
			anim1Com.AccelerationRatio = 0.01;
			anim1Com.AutoReverse = true;


				TranslateTransform anim1Com_tr = new TranslateTransform(0, 200);
			anim1Com_tr.BeginAnimation(TranslateTransform.XProperty, anim1Com);

				drzwi.RenderTransform = anim1Com_tr;
			aktPozycja = 200;
			label1.Content = "PIĘTRO 1";
		}

        private void P1c_Completed(object sender, EventArgs e)  //blokadka od nacisniecia przycisku podcas animacji
		{
			blokadka = 0;
        }
//***********************************************************************~PIETRO PIERWSZE~*******************************************************************

//***********************************************************************PIETRO DRUGIE***********************************************************************
		private void Pietro2_Click(object sender, RoutedEventArgs e)
		{
            if (blokadka == 0)
            {
                DoubleAnimation anim2 = new DoubleAnimation();
				anim2.Completed += P2_Completed;
				anim2.From = aktPozycja;
				anim2.To = 100;
				anim2.Duration = TimeSpan.FromMilliseconds(1000);
				anim2.AccelerationRatio = 0.01;


                TranslateTransform anim2_tr = new TranslateTransform(0, 100);
				anim2_tr.BeginAnimation(TranslateTransform.YProperty, anim2);

                kwadrat.RenderTransform = anim2_tr;	//ruch windy
                drzwi.RenderTransform = anim2_tr;	//ruch drzwi w dol
				blokadka = 1;
			}   //ENDIF
		}

		private void P2_Completed(object sender, EventArgs e)
		{

			DoubleAnimation anim2Com = new DoubleAnimation();
			anim2Com.Completed += P2c_Completed;
			anim2Com.From = 0;
			anim2Com.To = otworzDrzwi;
			anim2Com.Duration = TimeSpan.FromMilliseconds(1500);
			anim2Com.AccelerationRatio = 0.01;
			anim2Com.AutoReverse = true;

			TranslateTransform anim2Com_tr = new TranslateTransform(0, 100);
			anim2Com_tr.BeginAnimation(TranslateTransform.XProperty, anim2Com);

			drzwi.RenderTransform = anim2Com_tr;
			aktPozycja = 100;
			label1.Content = "PIĘTRO 2";
		}

        private void P2c_Completed(object sender, EventArgs e)	//blokadka od nacisniecia przycisku podcas animacji
        {
			blokadka = 0;
        }
//***********************************************************************~PIETRO DRUGIE~**********************************************************************

//***********************************************************************PIETRO TRZECIE***********************************************************************
		private void Pietro3_Click(object sender, RoutedEventArgs e)
		{
            if (blokadka == 0)
            {
                DoubleAnimation anim3 = new DoubleAnimation();
				anim3.Completed += P3_Completed; ;
				anim3.From = aktPozycja;

				anim3.To = 0;
				anim3.Duration = TimeSpan.FromMilliseconds(1000);
				anim3.AccelerationRatio = 0.01;

                TranslateTransform anim3_tr = new TranslateTransform(0, 100);
				anim3_tr.BeginAnimation(TranslateTransform.YProperty, anim3);

                kwadrat.RenderTransform = anim3_tr;	//ruch windy
                drzwi.RenderTransform = anim3_tr;	//ruch drzwi w dol
				blokadka = 1;
			}	//ENDIF
			
		}

		private void P3_Completed(object sender, EventArgs e)
		{
			DoubleAnimation anim3Com = new DoubleAnimation();
			anim3Com.Completed += P3c_Completed;
			anim3Com.From = 0;
			anim3Com.To = otworzDrzwi;
			anim3Com.Duration = TimeSpan.FromMilliseconds(1500);
			anim3Com.AccelerationRatio = 0.01;
			anim3Com.AutoReverse = true;

			TranslateTransform anim3Com_tr = new TranslateTransform(0, 0);
			anim3Com_tr.BeginAnimation(TranslateTransform.XProperty, anim3Com);

			drzwi.RenderTransform = anim3Com_tr;
			aktPozycja = 0;
			label1.Content = "PIĘTRO 3";

			//aktualna pozycja
			kwadrat.RenderTransform.Changed += RenderTransform_Changed;

		}

		//aktualna pozycja
		private void RenderTransform_Changed(object sender, EventArgs e)
		{
            //label2.Content = kwadrat.RenderTransform.GetValue(TranslateTransform.YProperty);
            //label2.Content = ((double)(kwadrat.RenderTransform.GetValue(TranslateTransform.YProperty))).ToString("F");
            //if (X > 90)
            //{
             //   kwadrat.RenderTransform.BeginAnimation(TranslateTransform.YProperty, null);
               // w_tr = X;
                //x- aktualna pozycja
            //}

        }

		private void P3c_Completed(object sender, EventArgs e)  //blokadka od nacisniecia przycisku podcas animacji
		{
			blokadka = 0;
        }
//***********************************************************************~PIETRO TRZECIE~*********************************************************************

		

	}
}
