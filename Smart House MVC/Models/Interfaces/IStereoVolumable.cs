﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart_House_MVC.Models.Interfaces
{
    public interface IStereoVolumable
    {
        void StereoVolumeUp();

        void StereoVolumeDown();

        void CheckStereoVolume();
    }
}