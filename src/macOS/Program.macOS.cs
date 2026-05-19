// JEM TOOLS | macOS Entry Point
using System.Collections.Generic;
using JEMTools.Platforms;
using JEMTools.Shared;

namespace JEMTools
{
    class Program
    {
        private const string Version = "1.2.3";

        static void Main(string[] args)
        {
            var tools = macOSModules.GetTools();
            TUIEngine.Run(tools, "macOS", Version);
        }
    }
}
