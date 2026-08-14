namespace Lab
{
    public class SmartHomeHub
    {
        public SmartDevice[] Devices { get; set; }
        public int DeviceCount { get; set; }


        public SmartHomeHub()
        {
            Devices = new SmartDevice[100];
            DeviceCount = 0;
        }
        public void AddDevice(SmartDevice device)
        {
            if (DeviceCount < Devices.Length)
            {
                Devices[DeviceCount++] = device;
                Console.WriteLine($"Cihaz {device.DeviceName} mərkəzə əlavə edildi.");
            }
            else
            {
                Console.WriteLine("Daha çox cihaz əlavə edə bilməzsiniz. Mərkəz doludur.");
            }
        }
        public void TurnAllOn()
        {
            for (int i = 0; i < DeviceCount; i++)
            {
                Devices[i].TurnOn();
            }
        }
        public void TurnAllOff()
        {
            for (int i = 0; i < DeviceCount; i++)
            {
                Devices[i].TurnOff();
            }
        }
        public void RunAutomation(int minutes)
        {
            foreach (SmartDevice device in Devices)
            {
                device.Operate(minutes);
            }
        }
        public void DisplayAllReport()
        {
            foreach (SmartDevice device in Devices)
            {
                device.GetDeviceInfo();
            }
        }

    }
}
