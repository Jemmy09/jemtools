using System.Collections.Generic;
using JEMTools.Platforms;
using JEMTools.Shared;

namespace JEMTools
{
    class Program
    {
        private const string Version = "1.2.2";

        static void Main(string[] args)
        {
            var tools = LinuxModules.GetTools();
            TUIEngine.Run(tools, "Linux", Version);
        }
    }
}
