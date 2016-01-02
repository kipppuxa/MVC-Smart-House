using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart_House_MVC.Models.Devices
{
    public abstract class Device
    {
        public bool State { get; set; }

        public Device(bool state)
        {
            State = state;
        }

        public Device()
        {

        }
    }
}