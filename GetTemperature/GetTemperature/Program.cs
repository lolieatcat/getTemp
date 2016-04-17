using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace GetTemperature
{
    class Program
    {
        public static double fCpuTmp = 0.0f;
        public static double fCpuFreq = 0.0f;
        static void Main(string[] args)
        {

            try
            {
                Thread th = new Thread(new ThreadStart(WebFeed));
                th.Start();
                while (true)
                {
                    string cpuTemp = File.ReadAllText("/sys/class/thermal/thermal_zone0/temp");
                    string cpuFreq = File.ReadAllText("/sys/devices/system/cpu/cpu0/cpufreq/scaling_cur_freq");

                    Console.WriteLine("CPU Temp:{0}℃, CPU freq:{1}MHz", Int32.Parse(cpuTemp) / 1000.0, Int32.Parse(cpuFreq) / 1000.0);
                    fCpuFreq = Int32.Parse(cpuFreq) / 1000.0;
                    fCpuTmp = Int32.Parse(cpuTemp) / 1000.0;
                    
                    
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void WebFeed()
        {
            while (true)
            {
                try
                {
                    ServiceReference1.PiServiceClient client = new ServiceReference1.PiServiceClient();

                    while (true)
                    {
                        client.DoWork(fCpuTmp, fCpuFreq);
                        Thread.Sleep(1000);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(5000);
                }
            }
        }
    }
}
