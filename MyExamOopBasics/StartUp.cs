using StartUp.Hardwares;
using StartUp.Softwares;
using StartUp.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StartUp
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string pattern = @"(\w+)(\((.*?)\))?";
            string inputLine = Console.ReadLine();
            Regex regex = new Regex(pattern);

            while (inputLine != "System Split")
            {
                Match matcher = regex.Match(inputLine);

                if (matcher.Groups[1].Value == "RegisterPowerHardware")
                {
                    string hardwareType = "Power";

                    string[] hardwareData = matcher.Groups[3].Value.Split(',');

                    string hardwareName = hardwareData[0].Trim();

                    int hardwareCapacity = int.Parse(hardwareData[1].Trim());

                    int hardwareMemory = int.Parse(hardwareData[2].Trim());

                    Hardware hardware = new PowerHardware(hardwareName, hardwareType, hardwareCapacity, hardwareMemory);
                    MySystem.RegisterHardware(hardware);
                }

                else if (matcher.Groups[1].Value == "RegisterHeavyHardware")
                {
                    string hardwareType = "Heavy";

                    string[] hardwareData = matcher.Groups[3].Value.Split(',');

                    string hardwareName = hardwareData[0].Trim();

                    int hardwareCapacity = int.Parse(hardwareData[1].Trim());

                    int hardwareMemory = int.Parse(hardwareData[2].Trim());

                    Hardware hardware = new HeavyHardware(hardwareName, hardwareType, hardwareCapacity, hardwareMemory);
                    MySystem.RegisterHardware(hardware);
                }

                else if (matcher.Groups[1].Value == "RegisterExpressSoftware")
                {
                    string softwareType = "ExpressSoftware";

                    string[] softwareData = matcher.Groups[3].Value.Split(',');

                    string hardwareComponentName = softwareData[0].Trim();

                    string softwareName = softwareData[1].Trim();

                    int softwareCapacityConsumption = int.Parse(softwareData[2].Trim());

                    int softwareMemoryconsumption = int.Parse(softwareData[3].Trim());

                    Software software = new ExpressSoftware(softwareName, softwareType, softwareCapacityConsumption, softwareMemoryconsumption);
                    MySystem.RegisterSoftware(hardwareComponentName, software);

                }

                else if (matcher.Groups[1].Value == "RegisterLightSoftware")
                {
                    string softwareType = "LightSoftware";

                    string[] softwareData = matcher.Groups[3].Value.Split(',');

                    string hardwareComponentName = softwareData[0].Trim();

                    string softwareName = softwareData[1].Trim();

                    int softwareCapacityConsumption = int.Parse(softwareData[2].Trim());

                    int softwareMemoryconsumption = int.Parse(softwareData[3].Trim());

                    Software software = new LightSoftware(softwareName, softwareType, softwareCapacityConsumption, softwareMemoryconsumption);
                    MySystem.RegisterSoftware(hardwareComponentName, software);
                }

                else if (matcher.Groups[1].Value == "ReleaseSoftwareComponent")
                {
                    string[] dataForSoftwareRelease = matcher.Groups[3].Value.Split(',');

                    string hardwareComponentName = dataForSoftwareRelease[0].Trim();

                    string softwareComponentName = dataForSoftwareRelease[1].Trim();

                    MySystem.ReleaseSoftowareComponent(hardwareComponentName, softwareComponentName);
                }

                else if (matcher.Groups[1].Value == "Analyze")
                {
                    MySystem.Analyze();
                }

                inputLine = Console.ReadLine();
            }

            MySystem.SystemSplit();
        }
    }
}
