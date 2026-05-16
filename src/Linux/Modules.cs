using System.Collections.Generic;

namespace JEMTools.Platforms
{
    public static class LinuxModules
    {
        public static List<ToolItem> GetTools()
        {
            var tools = new List<ToolItem>();
            
            // SYSTEM
            tools.Add(new ToolItem { SpecificName = "System Monitor", Command = "gnome-system-monitor", Icon = "📋", Category = "SYSTEM", Description = "Resource and process monitoring." });
            tools.Add(new ToolItem { SpecificName = "Terminal", Command = "x-terminal-emulator", Icon = "💻", Category = "SYSTEM", Description = "Linux command shell." });
            tools.Add(new ToolItem { SpecificName = "GParted", Command = "sudo gparted", Icon = "💽", Category = "ADMIN", Description = "Advanced partition management." });
            
            // NETWORK
            tools.Add(new ToolItem { SpecificName = "IP Config (Linux)", Command = "ip addr show", Icon = "🔍", Category = "NETWORK", Description = "Interface configuration." });
            tools.Add(new ToolItem { SpecificName = "Flush DNS", Command = "sudo systemd-resolve --flush-caches", Icon = "🧼", Category = "NETWORK", Description = "Purge systemd-resolved cache." });

            // JEMBOOT (Linux Edition)
            tools.Add(new ToolItem { SpecificName = "List Block Devices", Command = "lsblk", Icon = "🔌", Category = "JEMBOOT", Description = "List all storage devices." });
            
            return tools;
        }
    }
}
