using Smart_House_MVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart_House_MVC.Models.Interfaces
{
    public interface IChannelable
    {
        void NextChannel();

        void PrevChannel();

        ChannelNumber Channel { get; set; }
    }
}