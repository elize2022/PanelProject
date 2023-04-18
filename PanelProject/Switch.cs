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

        public Boolean isOn;
        public Image img;
        public Ellipse lamp;

        public Switch(ref Image img, ref Ellipse lamp)
        {
            isOn = true;
            this.img = img;
            this.lamp = lamp;
        }

        public void changeState(Boolean isOnMod)
        {
            try
            {
                Uri uriSource;
                if (isOn)
                {
                    uriSource = new Uri(@"/PanelProject;component/images/switchDownBrown.png", UriKind.Relative);
                    lamp.Style = roundGreenLampOff;
                }
                else
                {
                    uriSource = new Uri(@"/PanelProject;component/images/switchUpBrown.png", UriKind.Relative);
                    if (isOnMod)
                        lamp.Style = roundGreenLampOn;
                }
                img.Source = new BitmapImage(uriSource);
                isOn = !isOn;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void checkStateAndTurnOnLamp()
        {
            if (isOn)
                lamp.Style = roundGreenLampOn;
            else
                lamp.Style = roundGreenLampOff;
        }

        public void turnOffLamp()
        {
            lamp.Style = roundGreenLampOff;
        }
    }
}
