using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.Windows;

namespace PanelProject
{
    class Rectangle
    {
        private static Style rectangleLampGreenOff = (Style)Application.Current.Resources["RectangleLampGreenOff"];
        private static Style rectangleLampGreenOn = (Style)Application.Current.Resources["RectangleLampGreenOn"];

        private static Style rectangleLampGreenOnOffDiff = (Style)Application.Current.Resources["RectangleLampGreenOnOffDiff"];
        private static Style rectangleLampGreenOffDiff = (Style)Application.Current.Resources["RectangleLampGreenOffDiff"];
        private static Style rectangleLampGreenOnOnDiff = (Style)Application.Current.Resources["RectangleLampGreenOnOnDiff"];

        public Boolean isOn;
        public Boolean isSimple;
        public Button btn;

        public Rectangle(Button btn, Boolean isSimple)
        {
            this.isOn = false;
            this.isSimple = isSimple;
            this.btn = btn;
        }

        public void changeState(Boolean conditionTurnOn, Boolean isTurnOffItself)
        {
            if (isSimple)
            {
                if (!isOn && conditionTurnOn) //включаем
                {
                    btn.Style = rectangleLampGreenOn;
                    isOn = true;

                }
                else if(isOn && isTurnOffItself)
                {
                    btn.Style = rectangleLampGreenOff;
                    isOn = false;
                }
            }
            else
            {
                if (isOn)
                {
                    btn.Style = rectangleLampGreenOnOffDiff;
                }
                else
                {
                    btn.Style = rectangleLampGreenOnOnDiff;
                }
                isOn = !isOn;
            }
            
        }

        public void turnOff()
        {
            if (isSimple)
            {
                btn.Style = rectangleLampGreenOff;
            }
            else
            {
                btn.Style = rectangleLampGreenOnOffDiff;      
            }
            isOn = false;
        }

        public void disable()
        {
            if (isSimple)
            {
                btn.Style = rectangleLampGreenOff;
                
            }
            else
            {
                btn.Style = rectangleLampGreenOffDiff;
            }
            btn.IsEnabled = false;
            isOn = false;
        }

        public void enable()
        {
            if (isSimple)
            {
                btn.Style = rectangleLampGreenOn;
                isOn = true;
            }
            else
            {
                btn.Style = rectangleLampGreenOnOffDiff;
            }
            btn.IsEnabled = true;
            
        }
    }
}
