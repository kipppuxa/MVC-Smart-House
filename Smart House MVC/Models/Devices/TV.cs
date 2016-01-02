using Smart_House_MVC.Models.Enums;
using Smart_House_MVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart_House_MVC.Models.Devices
{
    public class TV : Device, ISwitchable, IChannelable, IStereoVolumable
    {
        private StereoSystem StereoSystem;
        public ChannelNumber Channel { get; set; }
        public int StereoVolume { get; set; }

        public TV(bool state, ChannelNumber channel, StereoSystem sSystem)
            : base(state)
        {
            Channel = channel;
            StereoSystem = sSystem;
        }
        public void SetOn()
        {
            State = true;
        }

        public void SetOff()
        {
            State = false;
        }

        public void NextChannel()
        {
            if ((int)Channel < System.Enum.GetValues(typeof(ChannelNumber)).Length)
            {
                Channel++;
            }
        }

        public void PrevChannel()
        {
            if ((int)Channel > 0)
            {
                Channel--;
            }
        }

        public void StereoVolumeUp()
        {
            StereoSystem.SetVolumeUp();
        }

        public void StereoVolumeDown()
        {
            StereoSystem.SetVolumeDown();
        }

        public void CheckStereoVolume()
        {
            StereoVolume = StereoSystem.Volume;
        }
    }
}