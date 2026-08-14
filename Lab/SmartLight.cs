namespace Lab
{
    internal class SmartLight : SmartDevice
    {
        public int BrightnessPercent { get; set; }
        public string ColorMyProperty { get; set; }

        public SmartLight(string deviceName, string brand, double powerRatingWatts, int initialBrightness, string color) : base(deviceName, brand, powerRatingWatts)
        {

            ColorMyProperty = color;
            if (initialBrightness >= 0 && initialBrightness <= 100)
            {
                BrightnessPercent = initialBrightness;
            }
            else
            {
                BrightnessPercent = 50;
            }
        }
        public void SetBrightness(int brightness)
        {
            if (brightness >= 0 && brightness <= 100)
            {
                BrightnessPercent = brightness;
            }
            else
            {
                Console.WriteLine("Brightness 0 ve 100 arasinda olmalidir.");
            }
        }
        public void SetBrightness(int percent, string newColor)
        {
            if (percent >= 0 && percent <= 100)
            {
                BrightnessPercent = percent;
                ColorMyProperty = newColor;
            }
            else
            {
                Console.WriteLine("Brightness 0 ve 100 arasinda olmalidir.");
            }
        }
        public override void Operate(int minutes)
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
            Console.WriteLine($"SmartLight {DeviceName} is operating for {minutes} minutes at {BrightnessPercent}% brightness and color {ColorMyProperty}. Total energy consumed: {TotalEnergyConsumedKWh:F4} kWh.");
        }
        public override void GetDeviceInfo()
        {
            base.GetDeviceInfo();
            Console.WriteLine($"Brightness: {BrightnessPercent}");
            Console.WriteLine($"Color: {ColorMyProperty}");

        }
    }
}
