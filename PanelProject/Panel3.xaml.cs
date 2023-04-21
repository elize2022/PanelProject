﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace PanelProject
{
    public partial class Panel3 : Window
    {
        private Switch switch_1;
        private Switch[] switches2_9 = new Switch[8];
        private Rectangle rectangle_1;
        private Rectangle rectangle_2;
        private Rectangle[] rectangles5_10 = new Rectangle[6];

        //стили
        private Style roundLampWithRingOn = (Style)Application.Current.Resources["RoundLampWithRingOn"];
        private Style roundLampWithRingOff = (Style)Application.Current.Resources["RoundLampWithRingOff"];
        private Style roundGreenLampOn = (Style)Application.Current.Resources["RoundGreenLampOn"];
        private Style roundGreenLampOff = (Style)Application.Current.Resources["RoundGreenLampOffGreen"];


        public Panel3()
        {
            InitializeComponent();
            rectangle_1 = new Rectangle(rectangle1, true);
            rectangle_2 = new Rectangle(rectangle2, true);
            rectangles5_10[0] = new Rectangle(rectangle5, false);
            rectangles5_10[1] = new Rectangle(rectangle6, false);
            rectangles5_10[2] = new Rectangle(rectangle7, false);
            rectangles5_10[3] = new Rectangle(rectangle8, false);
            rectangles5_10[4] = new Rectangle(rectangle9, false);
            rectangles5_10[5] = new Rectangle(rectangle10, false);
            foreach (Rectangle rect in rectangles5_10)
                rect.disable();

            Ellipse el = new Ellipse();
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
        }

        private void switch1_Click(object sender, RoutedEventArgs e)
        {
            switch_1.changeState(false);
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
        }

        private void modOff()
        {
            button8.Style = roundLampWithRingOff;
            button9.Style = roundLampWithRingOff;
            button10.Style = roundLampWithRingOff;
            lamp29.Style = roundGreenLampOff;
            turnOffSwitches();
            foreach(Rectangle rec in rectangles5_10)
                rec.disable();
        }

        private void firstReadinessRectangles()
        {
            foreach (Rectangle rec in rectangles5_10)
            {
                rec.enable();
                rec.isOn = false;
            }
        }

        private void switch_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = int.Parse(btn.Name[btn.Name.Length - 1].ToString()) - 2;
            Switch sw = switches2_9[index];

            if (index == 6) // тумблер НБ21
            {
                sw.changeState((rectangle_1.isOn || rectangle_2.isOn) && !switches2_9[6].isOn);
                if (!sw.isOn && (rectangle_1.isOn || rectangle_2.isOn))
                {
                    modOff();
                    rectangle_1.turnOff();
                    rectangle_2.turnOff();
                }
            }
            else // любой другой
                sw.changeState((rectangle_1.isOn || rectangle_2.isOn) && switches2_9[6].isOn);

        }

        private void rectangle1_Click(object sender, RoutedEventArgs e)
        {
            if (!rectangle_1.isOn && switches2_9[6].isOn) //включаем
            {
                if (rectangle_2.isOn)
                    firstReadinessRectangles();
                else
                    modOn();
                rectangle_1.changeState(true, true);
                if (rectangle_2.isOn)
                    rectangle_2.changeState(true, true);
            }
        }

        private void rectangle2_Click(object sender, RoutedEventArgs e)
        {
            if (!rectangle_2.isOn && switches2_9[6].isOn) //включаем
            {
                if (rectangle_1.isOn)
                    firstReadinessRectangles();
                else
                    modOn();
                rectangle_2.changeState(true, true);
                if (rectangle_1.isOn)
                    rectangle_1.changeState(true, true);
            }
        }
    }
}
