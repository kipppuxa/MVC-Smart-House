using Smart_House_MVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart_House_MVC.Models.Devices
{
    public class WiFi : Device, ISwitchable
    {
        public WiFi(bool state)
            : base(state)
        {

        }

        public void SetOn()
        {
            State = true;
        }

        public void SetOff()
        {
            State = false;
        }
    }
}