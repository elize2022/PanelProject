using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace PanelProject
{
    public partial class Panel1 : Window
    {
        private Switch switch_1;
        private Switch[] switches2_9 = new Switch[8];
        private Rectangle rectangle_3;
        private ButtonPanel button_1;
        private ButtonPanel button_3;
        private ButtonPanel button_5;
        private Rectangle[] rectangles5_10 = new Rectangle[6];

        //стили
        private Style roundLampWithRingOn = (Style)Application.Current.Resources["RoundLampWithRingOn"];
        private Style roundLampWithRingOff = (Style)Application.Current.Resources["RoundLampWithRingOff"];
        private Style roundGreenLampOff = (Style)Application.Current.Resources["RoundGreenLampOff"];
        private Style roundGreenLampOn = (Style)Application.Current.Resources["RoundGreenLampOn"];


        public Panel1()
        {
            InitializeComponent();

            button_1 = new ButtonPanel(button1);
            button_3 = new ButtonPanel(button3);
            button_5 = new ButtonPanel(button5);

            rectangle_3 = new Rectangle(rectangle3, true);
            rectangles5_10[0] = new Rectangle(rectangle5, false);
            rectangles5_10[1] = new Rectangle(rectangle6, false);
            rectangles5_10[2] = new Rectangle(rectangle7, false);
            rectangles5_10[3] = new Rectangle(rectangle8, false);
            rectangles5_10[4] = new Rectangle(rectangle9, false);
            rectangles5_10[5] = new Rectangle(rectangle10, false);
            foreach (Rectangle rect in rectangles5_10)
                rect.disable();

            Ellipse el = null;
            switch_1 = new Switch(ref img1, ref el, false);
            switches2_9[0] = new Switch(ref img2, ref lamp23, true);
            switches2_9[1] = new Switch(ref img3, ref lamp24, true);
            switches2_9[2] = new Switch(ref img4, ref lamp25, true);
            switches2_9[3] = new Switch(ref img5, ref lamp21, true);
            switches2_9[4] = new Switch(ref img6, ref lamp22, true);
            switches2_9[5] = new Switch(ref img7, ref lamp26, true);
            switches2_9[6] = new Switch(ref img8, ref lamp20, true);
            switches2_9[7] = new Switch(ref img9, ref el, true);
            Switch.setColorLampOff(roundGreenLampOff);
            
            turnOffPanel1();
        }

        private void switch1_Click(object sender, RoutedEventArgs e)
        {
            switch_1.changeState(false);
            if (switch_1.isOn && rectangle_3.isOn)
                turnOnPanel1();
            else
                turnOffPanel1();
        }

        private void rectangle3_Click(object sender, RoutedEventArgs e)
        {
            rectangle_3.changeState(switches2_9[6].isOn, false);
            if (rectangle_3.isOn && switch_1.isOn)
                turnOnPanel1();
        }

        private void turnOffPanel1()
        {
            button_1.disable();
            button_3.disable();
            button_5.disable();
            button7.IsEnabled = false;
        }

        private void turnOnPanel1()
        {
            button_1.enable();
            button_3.enable();
            button_5.enable();
            button7.IsEnabled = true;
        }

        private void pressButton1()
        {
            if (!button_1.isOn && !button_3.isOn && !button_5.isOn && switches2_9[6].isOn)
            {
                if (switches2_9[7].isOn)
                    mod50On();
                else
                    lamp30.Style = roundGreenLampOn;
                button_3.disable();
                button_5.disable();
                button_1.changeState();
            }
            
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
            if (!button_1.isOn && !button_3.isOn && !button_5.isOn && switches2_9[6].isOn)
            {
                modOnePCHOn();
                button_1.disable();
                button_5.disable();
                button_3.changeState();
            }
            
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            pressButton5();
        }

        private void pressButton5()
        {
            if (!button_1.isOn && !button_3.isOn && !button_5.isOn && switches2_9[6].isOn)
            {     
                modThreePCHOn();
                button_1.disable();
                button_3.disable();
                button_5.changeState();
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
                rectangles5_10[index].changeState(true, true);
            }
            catch(Exception ex)
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

        private void mod50Off(Boolean isTurnOffAll)
        {
            button11.Style = roundLampWithRingOff;
            button12.Style = roundLampWithRingOff;
            button13.Style = roundLampWithRingOff;
            lamp27.Style = roundGreenLampOff;
            if (isTurnOffAll)
                lamp30.Style = roundGreenLampOff;
        }

        private void modOnAndThreeOn()
        {
            button8.Style = roundLampWithRingOn;
            button9.Style = roundLampWithRingOn;
            button10.Style = roundLampWithRingOn;
            lamp28.Style = roundGreenLampOn;
            turnOnSwitches();
            rectangles5_10[0].enable();
        }

        private void modOnAndThreeOff()
        {
            button8.Style = roundLampWithRingOff;
            button9.Style = roundLampWithRingOff;
            button10.Style = roundLampWithRingOff;
            lamp28.Style = roundGreenLampOff;
            turnOffSwitches();
            rectangles5_10[0].disable();
            rectangles5_10[1].disable();
            rectangles5_10[2].disable();
            rectangles5_10[3].disable();
            rectangles5_10[4].disable();
            rectangles5_10[5].disable();
        }

        private void modOnePCHOn()
        {
            modOnAndThreeOn();
            
            rectangles5_10[1].disable();
            rectangles5_10[2].disable();
            rectangles5_10[3].disable();
            rectangles5_10[4].disable();
            rectangles5_10[5].disable();
        }

        private void modThreePCHOn()
        {
            modOnAndThreeOn();
            rectangles5_10[1].enable();
            rectangles5_10[2].enable();
            rectangles5_10[3].enable();
            rectangles5_10[4].enable();
            rectangles5_10[5].enable();
        }

        private void rectangle4_Click(object sender, RoutedEventArgs e)
        {
            rectangle_3.turnOff();
            turnOffPanel1();
            if (button_1.isOn)
            {
                mod50Off(true);
            }
            else if (button_3.isOn || button_5.isOn)
            {
                modOnAndThreeOff();
            }
            button_1.turnOff();
            button_3.turnOff();
            button_5.turnOff();
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            if (button_1.isOn)
            {
                mod50Off(true);
            }
            else if (button_3.isOn || button_5.isOn)
            {
                modOnAndThreeOff();
            }
            button_1.turnOff();
            button_3.turnOff();
            button_5.turnOff();
            button_1.enable();
            button_3.enable();
            button_5.enable();
        }


        private void switch_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = int.Parse(btn.Name[btn.Name.Length - 1].ToString()) - 2;
            Switch sw = switches2_9[index];

            if (index == 6) // тумблер НБ21
            {
                sw.changeState((button_3.isOn || button_5.isOn) && !switches2_9[6].isOn);
                

                if (!sw.isOn && (button_1.isOn || button_3.isOn || button_5.isOn || rectangle_3.isOn))
                {
                    if (button_1.isOn)
                        mod50Off(true);
                    else if (button_3.isOn || button_5.isOn)
                        modOnAndThreeOff();
                    button_1.turnOff();
                    button_1.disable();
                    button_3.turnOff();
                    button_3.disable();
                    button_5.turnOff();
                    button_5.disable();
                    rectangle_3.turnOff();
                }
            }
            else if (index == 7) // тумблер 3-50ГЦ 220В
            {
                sw.changeState(false);
                if (sw.isOn && button_1.isOn)
                    mod50On();
                else if (!sw.isOn && button_1.isOn)
                {
                    mod50Off(false);
                }
            }
            else // любой другой
                sw.changeState((button_3.isOn || button_5.isOn) && switches2_9[6].isOn);

        }
    }
}
