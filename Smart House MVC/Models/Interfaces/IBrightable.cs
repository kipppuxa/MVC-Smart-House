using Smart_House_MVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart_House_MVC.Models.Interfaces
{
    public interface IBrightable
    {
        void NextBright();

        void PrevBright();

        BrightnessLevel Brightness { get; set; }

    }
}