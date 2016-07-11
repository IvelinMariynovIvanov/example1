using StartUp.Hardwares;
using StartUp.Softwares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp.System
{
    public static class MySystem
    {
        public static Dictionary<string, Hardware> hardwares = new Dictionary<string, Hardware>();

        public static void RegisterHardware(Hardware hardware)
        {
            hardwares.Add(hardware.Name, hardware);
        }

        public static void RegisterSoftware(string hardwareComponentName, Software software)
        {
            if (hardwares.ContainsKey(hardwareComponentName))
            {
                if(hardwares[hardwareComponentName].RemainingCapacity >= software.CapacityConsumption &&
                    hardwares[hardwareComponentName].RemainingMemory >= software.MemoryConsumption)
                {
                    hardwares[hardwareComponentName].RemainingCapacity -= software.CapacityConsumption;
                    hardwares[hardwareComponentName].RemainingMemory -= software.MemoryConsumption;
                    hardwares[hardwareComponentName].InstallSoftware(software);
                }
            }
        }

        public static void ReleaseSoftowareComponent(string hardwareComponentName, string softwareComponentName)
        {
            if (hardwares.ContainsKey(hardwareComponentName))
            {
                if (hardwares[hardwareComponentName].containingSoftware.ContainsKey(softwareComponentName))
                {
                    hardwares[hardwareComponentName].RemainingCapacity += hardwares[hardwareComponentName].containingSoftware[softwareComponentName].CapacityConsumption;
                    hardwares[hardwareComponentName].RemainingMemory += hardwares[hardwareComponentName].containingSoftware[softwareComponentName].MemoryConsumption;
                    hardwares[hardwareComponentName].containingSoftware.Remove(softwareComponentName);
                }
            }
        }

        public static void Analyze()
        {
            int hardwareComponents = 0;
            int softwareComponents = 0;

            int totalOperationalMemoryInUse = 0;
            int maxOperationalMemory = 0;

            int totalCapacitytaken = 0;
            int maxCapacity = 0;

            foreach (var hardware in hardwares)
            {
                Hardware currentHardware = hardware.Value;
                hardwareComponents++;

                totalOperationalMemoryInUse += currentHardware.MaxMemory - currentHardware.RemainingMemory;
                maxOperationalMemory += currentHardware.MaxMemory;

                totalCapacitytaken += currentHardware.MaxCapacity - currentHardware.RemainingCapacity;
                maxCapacity += currentHardware.MaxCapacity;

                softwareComponents += currentHardware.containingSoftware.Count;
            }
            Console.WriteLine($"System Analysis");
            Console.WriteLine($"Hardware Components: {hardwareComponents}");
            Console.WriteLine($"Software Components: {softwareComponents}");
            Console.WriteLine($"Total Operational Memory: {totalOperationalMemoryInUse} / {maxOperationalMemory}");
            Console.WriteLine($"Total Capacity Taken: {totalCapacitytaken} / {maxCapacity}");
        }

        public static void SystemSplit()
        {
            string hardwareComponentName = string.Empty;
            string hardwareType = string.Empty;

            int expressSoftwareCount = 0;
            int lightSoftwareCount = 0;
            int hardwareMemoryUsed = 0;
            int hardwareMaxMemory = 0;
            int hardwareCapacityUsed = 0;
            int hardwareMaxCapacity = 0;

            foreach (var hardware in hardwares.OrderByDescending(x => x.Value.Type))
            {
                Hardware currentHardware = hardware.Value;

                List<string> softwareComponentsList = new List<string>();

                hardwareComponentName = currentHardware.Name;
                hardwareType = currentHardware.Type;
                expressSoftwareCount = currentHardware.containingSoftware.Where(x => x.Value.Type == "ExpressSoftware").Count();
                lightSoftwareCount = currentHardware.containingSoftware.Where(x => x.Value.Type == "LightSoftware").Count();
                hardwareMemoryUsed = currentHardware.MaxMemory - currentHardware.RemainingMemory;
                hardwareMaxMemory = currentHardware.MaxMemory;
                hardwareCapacityUsed = currentHardware.MaxCapacity - currentHardware.RemainingCapacity;
                hardwareMaxCapacity = currentHardware.MaxCapacity;

                Console.WriteLine($"Hardware Component - {hardwareComponentName}");
                Console.WriteLine($"Express Software Components - {expressSoftwareCount}");
                Console.WriteLine($"Light Software Components - {lightSoftwareCount}");
                Console.WriteLine($"Memory Usage: {hardwareMemoryUsed} / {hardwareMaxMemory}");
                Console.WriteLine($"Capacity Usage: {hardwareCapacityUsed} / {hardwareMaxCapacity}");
                Console.WriteLine($"Type: {hardwareType}");
                if (currentHardware.containingSoftware.Count > 0)
                {
                    foreach (var software in currentHardware.containingSoftware)
                    {
                        softwareComponentsList.Add(software.Value.Name);
                    }
                    string softwareComponents = string.Join(", ", softwareComponentsList);
                    Console.WriteLine($"Software Components: {softwareComponents}");
                }
                else
                {
                    Console.WriteLine($"Software Components: None");
                }

            }
        }
    }
}
