using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace PanelProject
{
    class ButtonPanel
    {
        public Boolean isOn;
        public Button btn;
        
        public ButtonPanel(Button btn)
        {
            this.isOn = false;
            this.btn = btn;
        }

        public void changeState()
        {
            this.isOn = !this.isOn;
        }

        public void disable()
        {
            this.btn.IsEnabled = false;
        }
        public void enable()
        {
            this.btn.IsEnabled = true;
        }

        public void turnOff()
        {
            this.isOn = false;
        }
    }
}
