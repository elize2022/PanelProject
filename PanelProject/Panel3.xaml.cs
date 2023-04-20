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
using System.Windows.Shapes;

namespace PanelProject
{
    public partial class Panel3 : Window
    {
        //состояния (On или Off)
        private Boolean isOnSwitch1;
        private Switch[] switches2_9 = new Switch[8];
        private Boolean[] isOnRectangle5_10 = new Boolean[6];
        private Boolean isOnRectangle1;
        private Boolean isOnRectangle2;

        //стили
        private Style rectangleLampGreenOff = (Style)Application.Current.Resources["RectangleLampGreenOff"];
        private Style rectangleLampGreenOn = (Style)Application.Current.Resources["RectangleLampGreenOn"];
        private Style roundLampOff = (Style)Application.Current.Resources["RoundLampOff"];
        private Style roundLampOn = (Style)Application.Current.Resources["RoundLampOn"];
        private Style roundLampWithRingOn = (Style)Application.Current.Resources["RoundLampWithRingOn"];
        private Style roundLampWithRingOff = (Style)Application.Current.Resources["RoundLampWithRingOff"];
        private Style roundGreenLampOn = (Style)Application.Current.Resources["RoundGreenLampOn"];
        private Style roundGreenLampOff = (Style)Application.Current.Resources["RoundGreenLampOffGreen"];
        private Style rectangleLampGreenOnOffDiff = (Style)Application.Current.Resources["RectangleLampGreenOnOffDiff"];
        private Style rectangleLampGreenOffDiff = (Style)Application.Current.Resources["RectangleLampGreenOffDiff"];
        private Style rectangleLampGreenOnOnDiff = (Style)Application.Current.Resources["RectangleLampGreenOnOnDiff"];


        public Panel3()
        {
            InitializeComponent();
            isOnSwitch1 = false;
            isOnRectangle1 = false;
            isOnRectangle2 = false;
            for (int i = 0; i < 6; i++)
            {
                isOnRectangle5_10[i] = false;
            }
            switches2_9[0] = new Switch(ref img2, ref lamp23, true);
            switches2_9[1] = new Switch(ref img3, ref lamp24, true);
            switches2_9[2] = new Switch(ref img4, ref lamp25, true);
            switches2_9[3] = new Switch(ref img5, ref lamp21, true);
            switches2_9[4] = new Switch(ref img6, ref lamp22, true);
            switches2_9[5] = new Switch(ref img7, ref lamp26, true);
            switches2_9[6] = new Switch(ref img8, ref lamp20, true);
            Ellipse el = new Ellipse();
            switches2_9[7] = new Switch(ref img9, ref el, true);
            disableRectangles(); // отключение rectangle5-10
        }

        private void switch1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Uri uriSource;
                if (isOnSwitch1)
                {
                    uriSource = new Uri(@"/PanelProject;component/images/switchDown.png", UriKind.Relative);
                }
                else
                {
                    uriSource = new Uri(@"/PanelProject;component/images/switchUp.png", UriKind.Relative);
                }
                img1.Source = new BitmapImage(uriSource);
                isOnSwitch1 = !isOnSwitch1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rectangleDiff_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int index = int.Parse(btn.Name[btn.Name.Length - 1].ToString()) - 5;
                if (btn.Name[btn.Name.Length - 2] == '1')
                    index = 5;
                if (isOnRectangle5_10[index])
                {
                    btn.Style = rectangleLampGreenOnOffDiff;
                }
                else
                {
                    btn.Style = rectangleLampGreenOnOnDiff;
                }
                isOnRectangle5_10[index] = !isOnRectangle5_10[index];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void turnOnSwitches()
        {
            foreach (Switch sw in switches2_9)
                sw.checkStateAndTurnOnLamp();
        }

        private void turnOffSwitches()
        {
            lamp20.Style = roundGreenLampOff;
            lamp21.Style = roundGreenLampOff;
            lamp22.Style = roundGreenLampOff;
            lamp23.Style = roundGreenLampOff;
            lamp24.Style = roundGreenLampOff;
            lamp25.Style = roundGreenLampOff;
            lamp26.Style = roundGreenLampOff;
        }

        private void modOn()
        {
            button8.Style = roundLampWithRingOn;
            button9.Style = roundLampWithRingOn;
            button10.Style = roundLampWithRingOn;
            lamp29.Style = roundGreenLampOn;
            turnOnSwitches();
            firstReadinessRectangles();
            enableRectangles();
        }

        private void modOff()
        {
            button8.Style = roundLampWithRingOff;
            button9.Style = roundLampWithRingOff;
            button10.Style = roundLampWithRingOff;
            lamp29.Style = roundGreenLampOff;
            turnOffSwitches();
            rectangle5.Style = rectangleLampGreenOffDiff;
            rectangle6.Style = rectangleLampGreenOffDiff;
            rectangle7.Style = rectangleLampGreenOffDiff;
            rectangle8.Style = rectangleLampGreenOffDiff;
            rectangle9.Style = rectangleLampGreenOffDiff;
            rectangle10.Style = rectangleLampGreenOffDiff;
            disableRectangles();
        }

        private void firstReadinessRectangles()
        {
            rectangle5.Style = rectangleLampGreenOnOffDiff;
            rectangle6.Style = rectangleLampGreenOnOffDiff;
            rectangle7.Style = rectangleLampGreenOnOffDiff;
            rectangle8.Style = rectangleLampGreenOnOffDiff;
            rectangle9.Style = rectangleLampGreenOnOffDiff;
            rectangle10.Style = rectangleLampGreenOnOffDiff;
        }

        private void enableRectangles()
        {
            rectangle5.IsEnabled = true;
            rectangle6.IsEnabled = true;
            rectangle7.IsEnabled = true;
            rectangle8.IsEnabled = true;
            rectangle9.IsEnabled = true;
            rectangle10.IsEnabled = true;
        }

        private void disableRectangles()
        {
            rectangle5.IsEnabled = false;
            rectangle6.IsEnabled = false;
            rectangle7.IsEnabled = false;
            rectangle8.IsEnabled = false;
            rectangle9.IsEnabled = false;
            rectangle10.IsEnabled = false;
        }

        private void turnOffRectangles()
        {

        }

        private void switch_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = int.Parse(btn.Name[btn.Name.Length - 1].ToString()) - 2;
            Switch sw = switches2_9[index];

            if (index == 6) // тумблер НБ21
            {
                sw.changeState((isOnRectangle1 || isOnRectangle2) && !switches2_9[6].isOn);
                if (!sw.isOn && (isOnRectangle1 || isOnRectangle2))
                {
                    modOff();
                    isOnRectangle1 = isOnRectangle2 = false;
                    rectangle1.Style = rectangleLampGreenOff;
                    rectangle2.Style = rectangleLampGreenOff;
                }
            }
            else
                sw.changeState((isOnRectangle1 || isOnRectangle2) && switches2_9[6].isOn);

        }

        private void rectangle1_Click(object sender, RoutedEventArgs e)
        {
            if (!isOnRectangle1 && switches2_9[6].isOn) //включаем
            {
                if (isOnRectangle2)
                    firstReadinessRectangles();
                else
                    modOn();
                rectangle1.Style = rectangleLampGreenOn;
                rectangle2.Style = rectangleLampGreenOff;
                isOnRectangle1 = true;
                isOnRectangle2 = false;
                
            }
        }

        private void rectangle2_Click(object sender, RoutedEventArgs e)
        {
            if (!isOnRectangle2 && switches2_9[6].isOn) //включаем
            {
                if (isOnRectangle1)
                    firstReadinessRectangles();
                else
                    modOn();
                rectangle2.Style = rectangleLampGreenOn;
                rectangle1.Style = rectangleLampGreenOff;
                isOnRectangle2 = true;
                isOnRectangle1 = false;
                modOn();
            }
        }
    }
}
