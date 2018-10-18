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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace alytalosovellus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


   /*   Koodista tuli erittäin sekava silla alussa nimesin asioita aivan liian vaikeasti. Tässä vaiheessa nimien muuttaminen olisi
    *   turhan työläs operaatio ja saattaisin itsekkin mennä enemmän sekaisin siitä, mikä oli mikä.
    *   ToDo:
    *   Sauna/Ok
    *   Valot/Ok
    *   Himmennin/Ok
    *   Liukuri/Ok
    *   Termostaatti/Ok
    */
    
     
    
    
    public partial class MainWindow : Window
    {
        public Sauna Sauna1 = new Sauna();
        public Lights olohuone = new Lights();
        public Lights keittio = new Lights();
        public bool huone;
        public Termostaatti termostaatti = new Termostaatti();
        public MainWindow()
        {
          InitializeComponent();          
          Dimmstate();//Toimii
          LightsON();//Toimii
          LiukuArvo();//Toimii osittain
          termostaatti.Temperature = 20;
          termoUpdate();          
        }

        private void termoUpdate() //Termostaatin lukeman päivitys tekstikenttään
        {
            txtbxtermoold.Text = termostaatti.Temperature.ToString()+" Astetta";
        }

        private void ValittuHuone()//Valitun huoneen päivitys teksitkenttään
        {
           if (huone == false)
            {
                txtBhuonevalittu.Text = "Olohuone valittuna.";
            }
           if (huone == true)
            {
                txtBhuonevalittu.Text = "Keittiö valittuna";
            }
        }

        public void LightsON() //True false näkymä valoille        
        {
            txtblolohuone.Text = olohuone.Valot.ToString();
            txtblkeittio.Text = keittio.Valot.ToString();
        }

        public void Dimmstate()                                         //Koitin tehdä tämän käyttämällä while-silmukoita if-lausekkeiden sijaan ja
        {                                                               //tuloksena oli että sovellus kääntyi virheittä, mutta käyttöliittymä ei auennut
            int dimval1;
            int dimval2;                                                //eikä VStudion pysäytys nappulaa painaessa prosessi sammunut. prosessi piti käydä 
            dimval1 = int.Parse(olohuone.Dimmer);
            dimval2 = int.Parse(keittio.Dimmer);                        //sulkemassa tehtävienhallinnan kautta manuaalisesti. Visual studio ei kuitenkaan
            dimval1 = int.Parse(olohuone.Dimmer);                       //herjannut virheistä.
            
            if (dimval1 >0)
            { olohuone.ValotPäälle(); }
            else
            {
                olohuone.ValotPois();
            }
            if (dimval2 > 0)
            {
                keittio.ValotPäälle();
            }
            else
            {
                keittio.ValotPois();
            }
            LightsON();
                                  
            if (dimval1  < 1)
            {
                lightStrenght.Text = ("Valot Pois");
            }
            if (dimval1 > 1 && dimval1 < 34 )
            {
                lightStrenght.Text = ("Hämärä");
            }
            if (dimval1 > 34 && dimval1 < 66)
            {
                lightStrenght.Text = ("Puolikirkas");
            }
            if (dimval1 > 66 && dimval1 <101)
            {
                lightStrenght.Text = ("Kirkas");
            }
            if (dimval2 < 1)
            {
                txtBxKeittio.Text = ("Valot Pois");
            }
            if (dimval2 > 1 && dimval1 < 34)
            {
                txtBxKeittio.Text = ("Hämärä");
            }
            if (dimval2 > 34 && dimval1 < 66)
            {
                txtBxKeittio.Text = ("Puolikirkas");
            }
            if (dimval2 > 66 && dimval1 < 101)
            {
                txtBxKeittio.Text = ("Kirkas");
            }
            lightState.Text = "Dimmer olohuone :" + olohuone.Dimmer + " %" + "\nDimmer Keittiö :" + keittio.Dimmer + " %";
        }
       
        private void Button_Click(object sender, RoutedEventArgs e) //sauna päälle
        {
            string saunaON = " Sauna on Päällä.";            
            saunaState.Background = Brushes.LightGreen;
            Sauna1.SaunaPäälle();
            saunaState.Text = Sauna1.Switch.ToString() + saunaON;
        }

        private void saunaStop_Click(object sender, RoutedEventArgs e)//Sauna pois
        {
            Sauna1.SaunaPois();
            saunaState.Background = Brushes.White;
            saunaState.Clear();
        }
        //Valojen toiminta
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (huone == false)
            {
                olohuone.ValotPois();
                olohuone.Dimmer = "0";
                LightsON();
                Dimmstate();
            }
            if (huone == true)
            {
                keittio.ValotPois();
                keittio.Dimmer = "0";
                LightsON();
                Dimmstate();
            }                     
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (huone == false)
            {
                olohuone.ValotPäälle();
                olohuone.Dimmer = "33";
                LightsON();
                Dimmstate();
            }
            if (huone == true)
            {
                keittio.ValotPäälle();
                keittio.Dimmer = "33";
                LightsON();
                Dimmstate();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (huone == false)
            {
              olohuone.ValotPäälle();
                olohuone.Dimmer = "66";
                LightsON();
                Dimmstate();
            }
            if (huone == true)
            {
                keittio.ValotPäälle();
                keittio.Dimmer = "66";
                LightsON();
                Dimmstate();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (huone == false)
            {
                olohuone.ValotPäälle();
                olohuone.Dimmer = "100";
                LightsON();
                Dimmstate();
            }
            if (huone == true)
            {
               keittio.ValotPäälle();
                keittio.Dimmer = "100";
                LightsON();
                Dimmstate();
            }
        }

        private void LightControl_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) //Liukuri
        {
            LiukuArvo();
        }
        public void LiukuArvo() //Liukurin toiminta
        {
            int valoOh = 0;
            int valoK = 0;
            if (huone == false)
            {
                valoOh = Convert.ToInt32(lightControl.Value);
                olohuone.Dimmer = valoOh.ToString();                
                Dimmstate();
            }
            if (huone == true)
            {
                valoK = Convert.ToInt32(lightControl.Value);
                keittio.Dimmer = valoK.ToString();
                Dimmstate();
            }

        }

        private void btnHuone_Click(object sender, RoutedEventArgs e)//Huoneen valitsin
        {
            if (huone == false)
            {
                huone = true;
            }
            
            else             {
                huone = false;
            }
            ValittuHuone();
        }

        private void btntermo_Click(object sender, RoutedEventArgs e) //Termostaatin toiminta
        {
            int i;
            try
            {                
                i = int.Parse(txtboxtermonew.Text);
                
                if (i >1 && i < 38)
                {
                    termostaatti.Temperature = i;
                    termoUpdate();
                }
                else
                {
                    MessageBox.Show("Syötit liian suuren, tai pienen luvun.");
                }

            }
            catch
            {
                MessageBox.Show("Syötä vain numeroita!");
            }
            
        }
       
    }


}
