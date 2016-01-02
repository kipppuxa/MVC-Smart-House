using Smart_House_MVC.Models.Devices;
using Smart_House_MVC.Models.Enums;
using Smart_House_MVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smart_House_MVC.Controllers
{
    public class DeviceController : Controller
    {
        IDictionary<int, Device> deviceCollection = new Dictionary<int, Device>();
        private int id;

        public ActionResult Index()
        {

            if (Session["S"] == null)
            {
                deviceCollection.Add(1, new Lamp(false, BrightnessLevel.Low));
                deviceCollection.Add(2, new Heater(false, HeatLevel.Low));
                deviceCollection.Add(3, new WiFi(false));
                deviceCollection.Add(4, new TV(false, ChannelNumber.BBC, new StereoSystem(false, 0)));

                Session["S"] = deviceCollection;
                Session["NextId"] = 5;
            }
            else
            {
                deviceCollection = (Dictionary<int, Device>)Session["S"];
            }

            return View(deviceCollection);
        }

        public ActionResult AddDevice(string submitButton)
        {
            Device newDevice;

            switch (submitButton)
            {
                default:
                    newDevice = new Lamp(false, BrightnessLevel.Low);
                    break;
                case "Add Heater":
                    newDevice = new Heater(false, HeatLevel.Low);
                    break;
                case "Add Wi-Fi":
                    newDevice = new WiFi(false);
                    break;
                case "Add TV":
                    newDevice = new TV(false, ChannelNumber.BBC, new StereoSystem(false, 0));
                    break;
            }

            id = (int)Session["NextId"];
            id++;
            Session["NextId"] = id;

            deviceCollection = (Dictionary<int, Device>)Session["S"];

            deviceCollection.Add(id, newDevice);

            Session["S"] = deviceCollection;

            return RedirectToAction("Index");
        }

        public ActionResult DelDevice(int id)
        {
            deviceCollection = (Dictionary<int, Device>)Session["S"];

            deviceCollection.Remove(id);

            Session["S"] = deviceCollection;

            return RedirectToAction("Index");
        }

        public ActionResult SwitchOnOff(int id)
        {
            deviceCollection = (Dictionary<int, Device>)Session["S"];

            if (deviceCollection[id].State)
            {
                ((ISwitchable)deviceCollection[id]).SetOff();
            }
            else
            {
                ((ISwitchable)deviceCollection[id]).SetOn();
            }

            Session["S"] = deviceCollection;

            return RedirectToAction("Index");
        }

        public ActionResult SwitchStatePlus(int id)
        {
            deviceCollection = (Dictionary<int, Device>)Session["S"];

            if (deviceCollection[id].State)
            {
                if (deviceCollection[id] is IBrightable)
                {
                    ((IBrightable)deviceCollection[id]).NextBright();
                }
                else if (deviceCollection[id] is IHeatable)
                {
                    ((IHeatable)deviceCollection[id]).NextHeat();
                }
                else if (deviceCollection[id] is IChannelable)
                {
                    ((IChannelable)deviceCollection[id]).NextChannel();
                }
            }

            Session["S"] = deviceCollection;

            return RedirectToAction("Index");
        }

        public ActionResult SwitchStateMinus(int id)
        {
            deviceCollection = (Dictionary<int, Device>)Session["S"];

            if (deviceCollection[id].State)
            {
                if (deviceCollection[id] is IBrightable)
                {
                    ((IBrightable)deviceCollection[id]).PrevBright();
                }
                else if (deviceCollection[id] is IHeatable)
                {
                    ((IHeatable)deviceCollection[id]).PrevHeat();
                }
                else if (deviceCollection[id] is IChannelable)
                {
                    ((IChannelable)deviceCollection[id]).PrevChannel();
                }
            }

            Session["S"] = deviceCollection;

            return RedirectToAction("Index");
        }

        public ActionResult SwitchPlusSound(int id)
        {
            deviceCollection = (Dictionary<int, Device>)Session["S"];

            if (deviceCollection[id].State)
            {
                ((IStereoVolumable)deviceCollection[id]).StereoVolumeUp();
                ((IStereoVolumable)deviceCollection[id]).CheckStereoVolume();
            }

            Session["S"] = deviceCollection;

            return RedirectToAction("Index");
        }

        public ActionResult SwitchMinusSound(int id)
        {
            deviceCollection = (Dictionary<int, Device>)Session["S"];

            if (deviceCollection[id].State)
            {
                ((IStereoVolumable)deviceCollection[id]).StereoVolumeDown();
                ((IStereoVolumable)deviceCollection[id]).CheckStereoVolume();
            }

            Session["S"] = deviceCollection;

            return RedirectToAction("Index");
        }
    }
}