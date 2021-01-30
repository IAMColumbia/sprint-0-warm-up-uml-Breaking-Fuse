namespace Sprint_0_Warm_Up
{
    public class Engine
    {
        public bool IsStarted { get; set; }

        public Engine()
        {
            IsStarted = false;
        }

        public string About()
        {
            if (IsStarted == true) return $"{this} is started.";
            else
            {
                return $"{this} is not started.";
            }
        }

        public void Start()
        {
            IsStarted = true;
        }

        public void Stop()
        {
            IsStarted = false;
        }

    }
}