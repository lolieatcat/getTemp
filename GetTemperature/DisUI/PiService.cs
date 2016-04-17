using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DisUI
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“PiService”。
    public class PiService : IPiService
    {
        public void DoWork(double cpuTemp, double cpuFreq)
        {
            Form1.cpuTemp = cpuTemp.ToString();
            Form1.cpuFreq = cpuFreq.ToString();
        }
    }
}
