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
    public partial class Panel2 : Window
    {
        //состояния (On или Off)
        private Boolean isOnSwitch1;
        private Switch[] switches2_9 = new Switch[8];
        private Boolean isOnRectangle3;
        private Boolean isOnButton1;
        private Boolean isOnButton3;
        private Boolean isOnButton5;
        private Boolean[] isOnRectangle5_10 = new Boolean[6];

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


        public Panel2()
        {
            InitializeComponent();
            isOnSwitch1 = false;
            isOnRectangle3 = false;
            isOnButton1 = false;
            isOnButton3 = false;
            isOnButton5 = false;
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
                    if (isOnRectangle3)
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
            if (!isOnRectangle3 && switches2_9[6].isOn) //включаем
            {
                rectangle3.Style = rectangleLampGreenOn;
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
            button3.IsEnabled = false;
            button5.IsEnabled = false;
            button7.IsEnabled = false;
        }

        private void turnOnPanel1()
        {
            button1.IsEnabled = true;
            button3.IsEnabled = true;
            button5.IsEnabled = true;
            button7.IsEnabled = true;
        }

        private void pressButton2()
        {
            if (!isOnButton1 && !isOnButton3 && !isOnButton5 && switches2_9[6].isOn)
            {
                if (switches2_9[7].isOn)
                    mod50On();
                else
                    lamp30.Style = roundGreenLampOn;
                button3.IsEnabled = false;
                button5.IsEnabled = false;
                isOnButton1 = !isOnButton1;
            }

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            pressButton2();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            pressButton4();
        }

        private void pressButton4()
        {
            if (!isOnButton3 && !isOnButton1 && !isOnButton5 && switches2_9[6].isOn)
            {
                modOnePCHOn();
                button1.IsEnabled = false;
                button5.IsEnabled = false;
                isOnButton3 = !isOnButton3;
            }

        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            pressButton6();
        }

        private void pressButton6()
        {
            if (!isOnButton5 && !isOnButton1 && !isOnButton3 && switches2_9[6].isOn)
            {
                modThreePCHOn();
                button1.IsEnabled = false;
                button3.IsEnabled = false;
                isOnButton5 = !isOnButton5;
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

        private void mod50On()
        {
            button11.Style = roundLampWithRingOn;
            button12.Style = roundLampWithRingOn;
            button13.Style = roundLampWithRingOn;
            lamp27.Style = roundGreenLampOn;
            lamp30.Style = roundGreenLampOn;
        }

        private void mod50Off()
        {
            button11.Style = roundLampWithRingOff;
            button12.Style = roundLampWithRingOff;
            button13.Style = roundLampWithRingOff;
            lamp27.Style = roundGreenLampOff;
            lamp30.Style = roundGreenLampOff;
        }

        private void modOnePCHOn()
        {
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
            rectangle3.Style = rectangleLampGreenOff;
            isOnRectangle3 = false;
            turnOffPanel1();
            if (isOnButton1)
            {
                mod50Off();
            }
            else if (isOnButton3)
            {
                modOnePCHOff();
            }
            else if (isOnButton5)
            {
                modThreePCHOff();
            }
            isOnButton1 = isOnButton3 = isOnButton5 = false;
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            if (isOnButton1)
            {
                mod50Off();
            }
            else if (isOnButton3)
            {
                modOnePCHOff();
            }
            else
            {
                modThreePCHOff();
            }
            isOnButton1 = isOnButton3 = isOnButton5 = false;
            button1.IsEnabled = button3.IsEnabled = button5.IsEnabled = true;
        }


        private void switch_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = int.Parse(btn.Name[btn.Name.Length - 1].ToString()) - 2;
            Switch sw = switches2_9[index];

            if (index == 6) // тумблер НБ21
            {
                sw.changeState((isOnButton3 || isOnButton5) && !switches2_9[6].isOn);
                if (!sw.isOn && (isOnButton1 || isOnButton3 || isOnButton5 || isOnRectangle3))
                {
                    if (isOnButton1)
                        mod50Off();
                    else if (isOnButton3)
                        modOnePCHOff();
                    else if (isOnButton5)
                        modThreePCHOff();
                    isOnButton1 = isOnButton3 = isOnButton5 = false;
                    rectangle3.Style = rectangleLampGreenOff;
                    isOnRectangle3 = false;
                }
            }
            else if (index == 7)
            {
                sw.changeState(false);
                if (sw.isOn && isOnButton1)
                    mod50On();
                else if (!sw.isOn && isOnButton1)
                {
                    mod50Off();
                    lamp30.Style = roundGreenLampOn;
                }
            }
            else
                sw.changeState((isOnButton3 || isOnButton5) && switches2_9[6].isOn);

        }
    }
}
