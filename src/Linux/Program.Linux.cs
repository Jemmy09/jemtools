// JEM TOOLS | Linux Entry Point
using System;
using JEMTools.Platforms;

namespace JEMTools
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- JEM TOOLS | Linux Edition v1.2.0 ---");
            Console.WriteLine("Precision System Intelligence for Linux Professionals.\n");
            
            var tools = LinuxModules.GetTools();
            foreach (var tool in tools)
            {
                Console.WriteLine($"[{tool.Icon}] {tool.SpecificName} - {tool.Description}");
            }
            
            Console.WriteLine("\n[!] Linux Support: JEM TOOLS supports GNOME, KDE, and XFCE environments.");
        }
    }
}
