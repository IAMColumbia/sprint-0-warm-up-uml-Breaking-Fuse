using System;
using static System.Console;


namespace Sprint_0_Warm_Up
{
    class ToyPlane : Airplane
    {
        private bool isWoundUp;

        public ToyPlane()
        {
            MaxAltitude = 50;
            isWoundUp = false;
        }

        public override string About()
        {
            return base.About() + getWindUpString();
        }

        public override string TakeOff()
        {
            if (!Engine.IsStarted) return $"{this} isn't wound up yet.";
            else
            {
                IsFlying = true;
                return $"{this} is flying.";
            }
        }

        private string getWindUpString()
        {
            if (isWoundUp) return $"{this} is wound up.";
            else
            {
                return $"{this} is not wound up.";
            }
        }

        public override void StartEngine()
        {
            if (isWoundUp) base.StartEngine();
            else
            {
                WriteLine($"{Engine} is not wound up yet.");
            }

        }

        public void WindUp()
        {
            isWoundUp = true;
        }

        private void UnWind()
        {
            isWoundUp = false;
        }

    }
}
