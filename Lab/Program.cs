namespace Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SmartHomeHub hub = new SmartHomeHub();
            SmartLight light = new SmartLight("Living Room Light", "Philips", 10, 80, "Warm White");
            SmartAirConditioner ac = new SmartAirConditioner("Bedroom Air Conditioner", "Samsung", 25, 60, "cool");

            hub.AddDevice(light);
            hub.AddDevice(ac);
            hub.TurnAllOn();
            hub.RunAutomation(30);
            light.SetBrightness(50, "Cool White");
            ac.CurrentMode = "fanonly";
            hub.RunAutomation(120);
            hub.DisplayAllReport();
        }
    }
}
