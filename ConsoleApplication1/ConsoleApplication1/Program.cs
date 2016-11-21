using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Common.Exceptions;


namespace ConsoleApplication1
{
    class Program
    {
        static RegistryManager registryManager;
        static string connectionString = "HostName=LAHEIJIOT.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=+e9VPCkFZnADxLpmKDY0X2TyO0oPG5G7XO0+exfh/fE=";


        static void Main(string[] args)
        {
            registryManager = RegistryManager.CreateFromConnectionString(connectionString);
            AddDeviceAsync().Wait();
            Console.ReadLine();
        }

        private static async Task AddDeviceAsync()
        {
            string deviceId = "MWLSoftDevice1";
            Device device;
            try
            {
                device = await registryManager.AddDeviceAsync(new Device(deviceId));
            }
            catch (DeviceAlreadyExistsException)
            {
                device = await registryManager.GetDeviceAsync(deviceId);
            }
            Console.WriteLine("Generated device key: {0}", device.Authentication.SymmetricKey.PrimaryKey);
        }
    }
}
