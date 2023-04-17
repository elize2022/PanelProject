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
using System.Reflection;

namespace PanelProject
{
    /// <summary>
    /// Interaction logic for Panel1.xaml
    /// </summary>
    public partial class Panel1 : Window
    {
        //состояния (On или Off)
        private Boolean isOnSwitch1;
        private Switch[] switches2_9 = new Switch[8];
        private Boolean isOnRectangle1;
        private Boolean isOnRectangle2;
        private Boolean isOnRectangle3;
        private Boolean isOnLamp5;
        private Boolean isOnLamp7;
        private Boolean isOnLamp9;
        private Boolean[] isOnRectangle5_10 = new Boolean[6];

        //стили
        private Style rectangleLampGreenOff = (Style)Application.Current.Resources["RectangleLampGreenOff"];
        private Style rectangleLampGreenOn = (Style)Application.Current.Resources["RectangleLampGreenOn"];
        private Style roundLampOff = (Style)Application.Current.Resources["RoundLampOff"];
        private Style roundLampOn = (Style)Application.Current.Resources["RoundLampOn"];
        private Style roundLampWithRingOn = (Style)Application.Current.Resources["RoundLampWithRingOn"];
        private Style roundLampWithRingOff = (Style)Application.Current.Resources["RoundLampWithRingOff"];
        private Style roundGreenLampOff = (Style)Application.Current.Resources["RoundGreenLampOff"];
        private Style roundGreenLampOn = (Style)Application.Current.Resources["RoundGreenLampOn"];
        private Style rectangleLampGreenOnOffDiff = (Style)Application.Current.Resources["RectangleLampGreenOnOffDiff"];
        private Style rectangleLampGreenOffDiff = (Style)Application.Current.Resources["RectangleLampGreenOffDiff"];
        private Style rectangleLampGreenOnOnDiff = (Style)Application.Current.Resources["RectangleLampGreenOnOnDiff"];


        public Panel1()
        {
            InitializeComponent();
            isOnSwitch1 = false;
            isOnRectangle1 = false;
            isOnRectangle2 = false;
            isOnRectangle3 = false;
            isOnLamp5 = false;
            isOnLamp7 = false;
            isOnLamp9 = false;
            for (int i = 0; i < 6; i++)
            {
                isOnRectangle5_10[i] = false;
            }
            switches2_9[0] = new Switch(ref img2, ref lamp23);
            switches2_9[1] = new Switch(ref img3, ref lamp24);
            switches2_9[2] = new Switch(ref img4, ref lamp25);
            switches2_9[3] = new Switch(ref img5, ref lamp21);
            switches2_9[4] = new Switch(ref img6, ref lamp22);
            switches2_9[5] = new Switch(ref img7, ref lamp26);
            switches2_9[6] = new Switch(ref img8, ref lamp20);
            Ellipse el = new Ellipse();
            switches2_9[7] = new Switch(ref img9, ref el);
            modThreePCHOff(); // отключение rectangle5-10
            turnOffPanel1();
        }

        private void switch1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Uri uriSource;
                if (isOnSwitch1)
                {
                    uriSource = new Uri(@"/PanelProject;component/images/switchDown.png", UriKind.Relative);
                    turnOffPanel1();
                }
                else
                {
                    uriSource = new Uri(@"/PanelProject;component/images/switchUp.png", UriKind.Relative);
                    if(isOnRectangle3)
                        turnOnPanel1();
                }
                img1.Source = new BitmapImage(uriSource);
                isOnSwitch1 = !isOnSwitch1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rectangle3_Click(object sender, RoutedEventArgs e)
        {
            if (!isOnRectangle3) //включаем
            {
                rectangle1.Style = rectangleLampGreenOff;
                isOnRectangle1 = false;
                rectangle2.Style = rectangleLampGreenOff;
                isOnRectangle2 = false;
                rectangle3.Style = rectangleLampGreenOn;
                lamp13.Style = roundGreenLampOn;
                lamp11.Style = roundLampOff;
                lamp12.Style = roundLampOff;
                if (isOnSwitch1)
                {
                    turnOnPanel1();
                }
            }
            isOnRectangle3 = !isOnRectangle3;
        }

        private void turnOffPanel1()
        {
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;
            button4.IsEnabled = false;
            button5.IsEnabled = false;
            button6.IsEnabled = false;
            button7.IsEnabled = false;
        }

        private void turnOnPanel1()
        {
            button1.IsEnabled = true;
            button2.IsEnabled = true;
            button3.IsEnabled = true;
            button4.IsEnabled = true;
            button5.IsEnabled = true;
            button6.IsEnabled = true;
            button7.IsEnabled = true;
        }

        private void pressButton1()
        {
            if (!isOnLamp5 && !isOnLamp7 && !isOnLamp9)
            {
                mod50On();
                button3.IsEnabled = false;
                button5.IsEnabled = false;
            }
            isOnLamp5 = !isOnLamp5;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            pressButton1();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            pressButton3();
        }

        private void pressButton3()
        {
            if (!isOnLamp7 && !isOnLamp5 && !isOnLamp9)
            {
                modOnePCHOn();
                button1.IsEnabled = false;
                button5.IsEnabled = false;
            }
            isOnLamp7 = !isOnLamp7;
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            pressButton5();
        }

        private void pressButton5()
        {
            if (!isOnLamp9 && !isOnLamp5 && !isOnLamp7)
            {     
                modThreePCHOn();
                button1.IsEnabled = false;
                button3.IsEnabled = false;
            }
            isOnLamp9 = !isOnLamp9;
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void turnOnSwitches()
        {
            if (!switches2_9[6].isOn) // тумблер НБ21 внизу
                return;
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

        private void mod50On()
        {
            lamp5.Style = roundGreenLampOn;
            button11.Style = roundLampWithRingOn;
            button12.Style = roundLampWithRingOn;
            button13.Style = roundLampWithRingOn;
            lamp27.Style = roundGreenLampOn;
            lamp30.Style = roundGreenLampOn;
            
        }

        private void mod50Off()
        {
            lamp5.Style = roundLampOff;
            button11.Style = roundLampWithRingOff;
            button12.Style = roundLampWithRingOff;
            button13.Style = roundLampWithRingOff;
            lamp27.Style = roundGreenLampOff;
            lamp30.Style = roundGreenLampOff;
        }

        private void modOnePCHOn()
        {
            lamp7.Style = roundGreenLampOn;
            button8.Style = roundLampWithRingOn;
            button9.Style = roundLampWithRingOn;
            button10.Style = roundLampWithRingOn;
            lamp28.Style = roundGreenLampOn;
            turnOnSwitches();
            rectangle5.IsEnabled = true;
            rectangle6.IsEnabled = false;
            rectangle7.IsEnabled = false;
            rectangle8.IsEnabled = false;
            rectangle9.IsEnabled = false;
            rectangle10.IsEnabled = false;
            rectangle5.Style = rectangleLampGreenOnOffDiff;
        }

        private void modOnePCHOff()
        {
            lamp7.Style = roundLampOff;
            button8.Style = roundLampWithRingOff;
            button9.Style = roundLampWithRingOff;
            button10.Style = roundLampWithRingOff;
            lamp28.Style = roundGreenLampOff;
            turnOffSwitches();
            rectangle5.IsEnabled = false;
            rectangle6.IsEnabled = false;
            rectangle7.IsEnabled = false;
            rectangle8.IsEnabled = false;
            rectangle9.IsEnabled = false;
            rectangle10.IsEnabled = false;
            rectangle5.Style = rectangleLampGreenOffDiff;
        }

        private void modThreePCHOn()
        {
            lamp9.Style = roundGreenLampOn;
            button8.Style = roundLampWithRingOn;
            button9.Style = roundLampWithRingOn;
            button10.Style = roundLampWithRingOn;
            lamp28.Style = roundGreenLampOn;
            turnOnSwitches();
            rectangle5.Style = rectangleLampGreenOnOffDiff;
            rectangle6.Style = rectangleLampGreenOnOffDiff;
            rectangle7.Style = rectangleLampGreenOnOffDiff;
            rectangle8.Style = rectangleLampGreenOnOffDiff;
            rectangle9.Style = rectangleLampGreenOnOffDiff;
            rectangle10.Style = rectangleLampGreenOnOffDiff;
            rectangle5.IsEnabled = true;
            rectangle6.IsEnabled = true;
            rectangle7.IsEnabled = true;
            rectangle8.IsEnabled = true;
            rectangle9.IsEnabled = true;
            rectangle10.IsEnabled = true;
        }

        private void modThreePCHOff()
        {
            lamp9.Style = roundLampOff;
            button8.Style = roundLampWithRingOff;
            button9.Style = roundLampWithRingOff;
            button10.Style = roundLampWithRingOff;
            lamp28.Style = roundGreenLampOff;
            turnOffSwitches();
            rectangle5.Style = rectangleLampGreenOffDiff;
            rectangle6.Style = rectangleLampGreenOffDiff;
            rectangle7.Style = rectangleLampGreenOffDiff;
            rectangle8.Style = rectangleLampGreenOffDiff;
            rectangle9.Style = rectangleLampGreenOffDiff;
            rectangle10.Style = rectangleLampGreenOffDiff;
            rectangle5.IsEnabled = false;
            rectangle6.IsEnabled = false;
            rectangle7.IsEnabled = false;
            rectangle8.IsEnabled = false;
            rectangle9.IsEnabled = false;
            rectangle10.IsEnabled = false;
        }

        private void rectangle4_Click(object sender, RoutedEventArgs e)
        {
            rectangle1.Style = rectangleLampGreenOff;
            rectangle2.Style = rectangleLampGreenOff;
            rectangle3.Style = rectangleLampGreenOff;
            isOnRectangle1 = false;
            isOnRectangle2 = false;
            isOnRectangle3 = false;
            lamp11.Style = roundLampOff;
            lamp12.Style = roundLampOff;
            lamp13.Style = roundLampOff;
        }

        private void rectangle1_Click(object sender, RoutedEventArgs e)
        {
            if (!isOnRectangle1)
            {
                rectangle1.Style = rectangleLampGreenOn;
                rectangle2.Style = rectangleLampGreenOff;
                isOnRectangle2 = false;
                rectangle3.Style = rectangleLampGreenOff;
                isOnRectangle3 = false;
                lamp11.Style = roundGreenLampOn;
                lamp12.Style = roundLampOff;
                lamp13.Style = roundLampOff;
            }
            isOnRectangle1 = !isOnRectangle1;
        }

        private void rectangle2_Click(object sender, RoutedEventArgs e)
        {
            if (!isOnRectangle2)
            {
                rectangle1.Style = rectangleLampGreenOff;
                isOnRectangle1 = false;
                rectangle2.Style = rectangleLampGreenOn;
                rectangle3.Style = rectangleLampGreenOff;
                isOnRectangle3 = false;
                lamp12.Style = roundGreenLampOn;
                lamp11.Style = roundLampOff;
                lamp13.Style = roundLampOff;
            }
            isOnRectangle2 = !isOnRectangle2;
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            if (isOnLamp5)
            {
                mod50Off();
            }
            else if (isOnLamp7)
            {
                modOnePCHOff();
            }
            else if (isOnLamp9)
            {
                modThreePCHOff();
            }
            isOnLamp5 = isOnLamp7 = isOnLamp9 = false;
            button1.IsEnabled = button3.IsEnabled = button5.IsEnabled = true;
        }


        private void switch_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = int.Parse(btn.Name[btn.Name.Length - 1].ToString()) - 2;
            Switch sw = switches2_9[index];

            sw.changeState((isOnLamp7 || isOnLamp9) && switches2_9[6].isOn);
            if (index == 6) // тумблер НБ21
            {
                if (sw.isOn && (isOnLamp7 || isOnLamp9))
                {
                    foreach (Switch s in switches2_9) // включить лампочки других тумблеров
                        s.checkStateAndTurnOnLamp();
                }
                if (!sw.isOn && (isOnLamp7 || isOnLamp9))
                {
                    foreach (Switch s in switches2_9) // выключить лампочки других тумблеров
                        s.turnOffLamp();
                }
            }
        }
    }
}
