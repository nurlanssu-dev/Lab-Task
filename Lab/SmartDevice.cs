namespace Lab
{
    public class SmartDevice
    {
        public string DeviceName { get; init; }
        public readonly string Brand;
        public double PowerRatingWatts { get; set; }
        public bool IsOn { get; set; }
        public double TotalEnergyConsumedKWh { get; set; }

        public SmartDevice(string deviceName, string brand, double powerRatingWatts)
        {
            DeviceName = deviceName;
            Brand = brand;
            PowerRatingWatts = powerRatingWatts;

            if (!string.IsNullOrWhiteSpace(deviceName))
            {
                DeviceName = deviceName;
            }

            if (!string.IsNullOrWhiteSpace(brand))
            {
                Brand = brand;
            }

            if (powerRatingWatts > 0)
            {
                PowerRatingWatts = powerRatingWatts;
            }

            IsOn = false;
            TotalEnergyConsumedKWh = 0.0;
        }
        public void TurnOn()
        {
            IsOn = true;
        }
        public void TurnOff()
        {
            IsOn = false;
        }
        public virtual void Operate(int minutes)
        {
            if (minutes <= 0)
            {
                Console.WriteLine("Minutes o dan boyuk olmalidir.");
                return;
            }

            if (!IsOn)
            {
                Console.WriteLine("cihaz sonuludur");
                return;
            }

            double consumedEnergy = (PowerRatingWatts * minutes) / (1000 * 60);

            TotalEnergyConsumedKWh += consumedEnergy;

            Console.WriteLine($"{minutes} minutes operated.");
        }
        public virtual void GetDeviceInfo()
        {
            Console.WriteLine("Type: Smart Device");
            Console.WriteLine($"Device Name: {DeviceName}");
            Console.WriteLine($"Brand: {Brand}");
            Console.WriteLine($"Power Rating (Watts): {PowerRatingWatts}");
            Console.WriteLine($"Is On: {IsOn}");
            Console.WriteLine($"Total Energy Consumed (kWh): {TotalEnergyConsumedKWh}");
        }
    }
}
