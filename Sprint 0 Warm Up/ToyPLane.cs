using System;
using static System.Console;


namespace Sprint_0_Warm_Up
{
    public class ToyPlane : Airplane
    {
        private bool isWoundUp;

        public ToyPlane()
        {
            MaxAltitude = 50;
            isWoundUp = false;
        }

        public override string About()
        {
            return base.About() + GetWindUpString();
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

        public string GetWindUpString()
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

        public void UnWind()
        {
            isWoundUp = false;
        }

        public override void FlyUp()
        {
            CurrentAltitude += 5;
        }

        public override void FlyUp(int HowManyFeet)
        {
            CurrentAltitude += 5 + HowManyFeet;
        }
    }
}
