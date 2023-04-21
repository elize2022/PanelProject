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
    class Switch
    {
        private static Style roundGreenLampOff = (Style)Application.Current.Resources["RoundGreenLampOff"];
        private static Style roundGreenLampOn = (Style)Application.Current.Resources["RoundGreenLampOn"];

        private static BitmapImage bitmapImageBrownDown = new BitmapImage(
            new Uri(@"/PanelProject;component/images/switchDownBrown.png", UriKind.Relative)
            );
        private static BitmapImage bitmapImageBrownUp = new BitmapImage(
            new Uri(@"/PanelProject;component/images/switchUpBrown.png", UriKind.Relative)
            );
        private static BitmapImage bitmapImageDown = new BitmapImage(
            new Uri(@"/PanelProject;component/images/switchDown.png", UriKind.Relative)
            );
        private static BitmapImage bitmapImageUp = new BitmapImage(
            new Uri(@"/PanelProject;component/images/switchUp.png", UriKind.Relative)
            );

        public Boolean isOn;
        public Image img;
        public Ellipse lamp;
        public Boolean isBrown;

        public Switch(ref Image img, ref Ellipse lamp, Boolean isBrown)
        {
            if (isBrown)
                isOn = true;
            else
                isOn = false;
            this.img = img;
            this.lamp = lamp;
            this.isBrown = isBrown;
        }

        public static void setColorLampOff(Style style)
        {
            roundGreenLampOff = style;
        }

        public void changeState(Boolean isOnMod)
        {
            try
            {
                if (isBrown)
                {
                    if (isOn)
                    {
                        img.Source = bitmapImageBrownDown;
                        if (lamp != null)
                            lamp.Style = roundGreenLampOff;
                    }
                    else
                    {
                        img.Source = bitmapImageBrownUp;
                        if (isOnMod && lamp != null)
                            lamp.Style = roundGreenLampOn;
                    }
                }
                else
                {
                    if (isOn)
                        img.Source = bitmapImageDown;
                    else
                        img.Source = bitmapImageUp;
                }
                isOn = !isOn;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void checkStateAndTurnOnLamp()
        {
            if (lamp != null)
            {
                if (isOn)
                    lamp.Style = roundGreenLampOn;
                else
                    lamp.Style = roundGreenLampOff;
            }
        }

        public void turnOffLamp()
        {
            if (lamp != null)
                lamp.Style = roundGreenLampOff;
        }
    }
}
