using System;
using static System.Console;

namespace Sprint_0_Warm_Up
{
    public abstract class AerialVehicle
    {
        //Altitude is measured in Feet(ft)
        public int CurrentAltitude { get; set; }
        public int MaxAltitude { get; set; }
        public bool IsFlying { get; set; }
        protected Engine Engine { get; set; }

        public AerialVehicle()
        {
            Engine = new Engine();
        }

        public virtual string About()
        {
            return $"This {this} has a Max Altitude of {MaxAltitude} ft.\n" +
                $"It's Current Altitude is {CurrentAltitude} ft.\n" +
                $"{GetEngineStartedString()}";
        }

        private string GetEngineStartedString()
        {
            return Engine.About();
        }

        public virtual string TakeOff()
        {
            if (!Engine.IsStarted) return $"{Engine} isn't started yet, so {this} can't take off.";
            else
            {
                IsFlying = true;
                return $"{this} is flying.";
            }
        }

        public virtual void StartEngine()
        {
            Engine.Start();
        }
        public void StopEngine()
        {
            Engine.Stop();
        }


        //Flying up Above MaxAltitude should result in CurrentAltitude of Max Altitude
        internal void FlyUp()
        {
            if (IsFlying)
            {
                CurrentAltitude += 1000;
                if (CurrentAltitude > MaxAltitude)
                {
                    WriteLine($"{this} can't fly any higher than {MaxAltitude} ft.");
                    CurrentAltitude = MaxAltitude;
                }
            }
            else
            {
                WriteLine($"{this} isn't flying yet.");
            }
        }

        internal void FlyUp(int HowManyFeet)
        {
            if (IsFlying)
            {
                CurrentAltitude += (1000 + HowManyFeet);
                if (CurrentAltitude > MaxAltitude) 
                {
                    WriteLine($"{this} can't fly any higher than {MaxAltitude} ft.");
                    CurrentAltitude = MaxAltitude;
                }
            }
            else
            {
                WriteLine($"{this} isn't flying yet.");
            }
        }


        //Flying down Below 0 ft should crash the vehicle. Flying down Current Altitude should land the vehicle

        internal void FlyDown(int HowManyFeet)
        {
            if (IsFlying)
            {
                CurrentAltitude -= HowManyFeet;
                if (CurrentAltitude == 0)
                {
                    IsFlying = false;
                    StopEngine();
                    WriteLine($"{this} has landed.");
                }
                else if (CurrentAltitude < 0)
                {
                    WriteLine($"{this} has Crashed!\nRecovering {this}...");
                    CurrentAltitude += HowManyFeet;
                }
            }
            else
            {
                WriteLine($"{this} isn't flying yet.");
            }
        }


    }
}