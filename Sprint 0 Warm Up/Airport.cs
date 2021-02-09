using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_0_Warm_Up
{
    public class Airport
    {
        private List<AerialVehicle> Vehicles;
        private int MaxVehicles;
        public string AirportCode { get; set; }

        Airport(string _Code)
        {
            AirportCode = _Code;
        }

        Airport(string _Code, int _MaxVehicles)
        {
            AirportCode = _Code;
            MaxVehicles = _MaxVehicles;
        }


        public void AllTakeOff()
        {
            foreach(AerialVehicle a in Vehicles)
            {
                a.StartEngine();
                a.TakeOff();
                a.FlyUp();
            }
        }

        public void Land(List<AerialVehicle> landing)
        {
            foreach(AerialVehicle a in landing)
            {
                a.FlyDown(a.CurrentAltitude);
            }
        }
        public void Land(AerialVehicle a)
        {
            a.FlyDown(a.CurrentAltitude);
        }

        public void TakeOff(AerialVehicle a)
        {
            a.StartEngine();
            a.TakeOff();
            a.FlyUp();
        }

    }
}
