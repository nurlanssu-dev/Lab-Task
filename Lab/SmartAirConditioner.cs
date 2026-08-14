namespace Lab
{
    internal class SmartAirConditioner : SmartDevice
    {
        public double TargetTemperature { get; set; }
        public string CurrentMode { get; set; }

        public SmartAirConditioner(string deviceName, string brand, double powerRatingWatts, double targetTemp, string mode) : base(deviceName, brand, powerRatingWatts)
        {
            CurrentMode = mode;
            if (targetTemp >= 16 && targetTemp <= 30)
            {
                TargetTemperature = targetTemp;
            }
            else
            {
                Console.WriteLine("Target temperature 16 ve 30 arasinda olmalidir.");
            }
        }

        public override void Operate(int minutes)
        {
            double multiplier = 1;

            switch (CurrentMode)
            {
                case "Cool":
                    multiplier = 1.2;
                    break;

                case "Heat":
                    multiplier = 1.5;
                    break;

                case "FanOnly":
                    multiplier = 0.3;
                    break;
            }

            double effectiveWatts = PowerRatingWatts * multiplier;
            double consumedKWh = (effectiveWatts * minutes) / (100 * 60);

            TotalEnergyConsumedKWh += consumedKWh;

            Console.WriteLine($"{minutes} dəqiqə işlədildi.");
            Console.WriteLine($"Mode: {CurrentMode}");
            Console.WriteLine($"Consumed Energy: {consumedKWh:F2} kWh");
        }
        public override void GetDeviceInfo()
        {
            base.GetDeviceInfo();
            Console.WriteLine($"Target Temperature: {TargetTemperature} °C");
            Console.WriteLine($"Current Mode: {CurrentMode}");
        }


    }
}
