using System.Collections.Generic;

namespace JEMTools.Platforms
{
    public static class macOSModules
    {
        public static List<ToolItem> GetTools()
        {
            var tools = new List<ToolItem>();
            
            // SYSTEM
            tools.Add(new ToolItem { SpecificName = "Activity Monitor", Command = "open -a 'Activity Monitor'", Icon = "📋", Category = "SYSTEM", Description = "Monitor system processes and resources." });
            tools.Add(new ToolItem { SpecificName = "System Information", Command = "open -a 'System Information'", Icon = "ℹ️", Category = "SYSTEM", Description = "Detailed hardware and software specs." });
            tools.Add(new ToolItem { SpecificName = "Disk Utility", Command = "open -a 'Disk Utility'", Icon = "💽", Category = "ADMIN", Description = "Manage disks and partitions." });
            tools.Add(new ToolItem { SpecificName = "Terminal", Command = "open -a 'Terminal'", Icon = "💻", Category = "SYSTEM", Description = "macOS command line interface." });
            
            // NETWORK
            tools.Add(new ToolItem { SpecificName = "Network Utility", Command = "open -a 'Network Utility'", Icon = "🔍", Category = "NETWORK", Description = "Diagnostic tools for networking." });
            tools.Add(new ToolItem { SpecificName = "Flush DNS Cache", Command = "sudo dscacheutil -flushcache; sudo killall -HUP mDNSResponder", Icon = "🧼", Category = "NETWORK", Description = "Purge the macOS DNS resolver cache." });

            // JEMBOOT (macOS Edition)
            tools.Add(new ToolItem { SpecificName = "List USB Drives", Command = "diskutil list | grep external", Icon = "🔌", Category = "JEMBOOT", Description = "Identify connected USB media." });
            
            return tools;
        }
    }
}
