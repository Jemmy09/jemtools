// JEM TOOLS | macOS Entry Point
using System;
using JEMTools.Platforms;

namespace JEMTools
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- JEM TOOLS | macOS Edition v1.2.0 ---");
            Console.WriteLine("Precision System Intelligence for macOS Professionals.\n");
            
            var tools = macOSModules.GetTools();
            foreach (var tool in tools)
            {
                Console.WriteLine($"[{tool.Icon}] {tool.SpecificName} - {tool.Description}");
            }
            
            Console.WriteLine("\n[!] To launch the High-Fidelity UI on macOS, please ensure Avalonia.Desktop is installed.");
        }
    }
}
