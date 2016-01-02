using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart_House_MVC.Models.Interfaces
{
    public interface ISwitchable
    {
        void SetOn();

        void SetOff();

        bool State { get; set; }
    }
}