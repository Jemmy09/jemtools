using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JEMTools.Platforms;

namespace JEMTools.Shared
{
    // Shared Unix TUI Engine — used by both macOS and Linux editions.
    // Written for C# 5 / .NET Framework 4.8 compatibility (no interpolated strings).
    public static class TUIEngine
    {
        private static List<ToolItem> _tools;
        private static string _platform;
        private static string _version;

        public static void Run(List<ToolItem> tools, string platform, string version)
        {
            _tools = tools;
            _platform = platform;
            _version = version;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                ShowMainMenu();
            }
        }

        private static void ShowMainMenu()
        {
            Console.Clear();
            PrintBanner();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(string.Format(" [ PLATFORM: {0} | VERSION: {1} | STATUS: OPERATIONAL ]", _platform.ToUpper(), _version));
            Console.ResetColor();
            Console.WriteLine(" -----------------------------------------------------------");
            Console.WriteLine(" Select an Infrastructure Category:");
            Console.WriteLine();

            var categories = _tools.Select(t => t.Category).Distinct().OrderBy(c => c).ToList();

            for (int i = 0; i < categories.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(string.Format(" [{0}] ", i + 1));
                Console.ResetColor();
                Console.WriteLine(categories[i]);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [A] ");
            Console.ResetColor();
            Console.WriteLine("View All Modules");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [H] ");
            Console.ResetColor();
            Console.WriteLine("About JEM TOOLS");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [P] ");
            Console.ResetColor();
            Console.WriteLine("User Policies");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [0] ");
            Console.ResetColor();
            Console.WriteLine("Exit JEM TOOLS");

            Console.WriteLine("\n -----------------------------------------------------------");
            Console.Write(" >> Select Option: ");

            string input = Console.ReadLine();
            if (input != null) input = input.ToUpper();

            if (input == "0") Environment.Exit(0);
            if (input == "A") { ShowToolsByCategory("ALL"); return; }
            if (input == "H") { ShowAbout(); return; }
            if (input == "P") { ShowPolicies(); return; }

            int index;
            if (int.TryParse(input, out index) && index > 0 && index <= categories.Count)
            {
                ShowToolsByCategory(categories[index - 1]);
            }
        }

        private static void ShowToolsByCategory(string category)
        {
            while (true)
            {
                Console.Clear();
                PrintBanner();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(string.Format(" [ CATEGORY: {0} ]", category));
                Console.ResetColor();
                Console.WriteLine(" -----------------------------------------------------------");

                var filteredTools = (category == "ALL")
                    ? _tools
                    : _tools.Where(t => t.Category == category).ToList();

                for (int i = 0; i < filteredTools.Count; i++)
                {
                    var tool = filteredTools[i];
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(string.Format(" [{0}] ", i + 1));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(string.Format("{0} {1}", tool.Icon, tool.SpecificName.PadRight(25)));
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(string.Format(" - {0}", tool.Description));
                }

                Console.ResetColor();
                Console.WriteLine("\n [B] Back to Main Menu");
                Console.WriteLine(" -----------------------------------------------------------");
                Console.Write(" >> Select Node to Launch: ");

                string input = Console.ReadLine();
                if (input != null) input = input.ToUpper();
                if (input == "B") return;

                int index;
                if (int.TryParse(input, out index) && index > 0 && index <= filteredTools.Count)
                {
                    LaunchTool(filteredTools[index - 1]);
                }
            }
        }

        private static void LaunchTool(ToolItem tool)
        {
            Console.Clear();
            PrintBanner();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format(" [ INITIALIZING NODE: {0} ]", tool.SpecificName));
            Console.ResetColor();
            Console.WriteLine(" -----------------------------------------------------------");
            Console.WriteLine(string.Format(" Category:    {0}", tool.Category));
            Console.WriteLine(string.Format(" Description: {0}", tool.Description));
            Console.WriteLine(string.Format(" Command:     {0}", tool.Command));
            Console.WriteLine(" -----------------------------------------------------------");
            Console.WriteLine("\n Executing infrastructure command... Please wait.");

            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = string.Format("-c \"{0}\"", tool.Command),
                    UseShellExecute = false,
                    CreateNoWindow = false
                };

                using (var process = Process.Start(psi))
                {
                    if (process != null) process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(string.Format("\n [!] Execution Error: {0}", ex.Message));
                Console.ResetColor();
            }

            Console.WriteLine("\n Execution Finished. Press any key to return...");
            Console.ReadKey();
        }

        private static void ShowAbout()
        {
            Console.Clear();
            PrintBanner();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" [ ABOUT JEM TOOLS ]");
            Console.ResetColor();
            Console.WriteLine(" -----------------------------------------------------------");
            Console.WriteLine(string.Format(" JEM TOOLS | Admin Edition v{0}", _version));
            Console.WriteLine(string.Format(" Precision System Intelligence for {0} Professionals.", _platform));
            Console.WriteLine("\n Developed by: Jemmy Francisco");
            Console.WriteLine(" Architecture: Multi-Platform C# .NET");
            Console.WriteLine("\n JEM TOOLS is an advanced infrastructure command suite.");
            Console.WriteLine(" Execution is securely isolated to your local machine.");
            Console.WriteLine(" Privacy-First: No telemetry. No external connections.");
            Console.WriteLine(" -----------------------------------------------------------");
            Console.WriteLine(" (C) 2026 JEM TOOLS · Released under MIT License");
            Console.WriteLine(" -----------------------------------------------------------");
            Console.WriteLine("\n Press any key to return...");
            Console.ReadKey();
        }

        private static void ShowPolicies()
        {
            Console.Clear();
            PrintBanner();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" [ USER POLICIES ]");
            Console.ResetColor();
            Console.WriteLine(" -----------------------------------------------------------");
            Console.WriteLine(" 1. ADMINISTRATIVE RESPONSIBILITY");
            Console.WriteLine("    JEM TOOLS performs high-level system modifications.");
            Console.WriteLine("    Use all tools with professional discretion.");
            Console.WriteLine();
            Console.WriteLine(" 2. PRIVACY-FIRST ARCHITECTURE");
            Console.WriteLine("    Operates entirely offline.");
            Console.WriteLine("    No telemetry or data is transmitted externally.");
            Console.WriteLine();
            Console.WriteLine(" 3. NO WARRANTY");
            Console.WriteLine("    Software provided 'AS IS' under MIT License.");
            Console.WriteLine("    Developer not liable for misuse.");
            Console.WriteLine();
            Console.WriteLine(" 4. INTELLECTUAL PROPERTY");
            Console.WriteLine("    Branding and architecture are the exclusive property");
            Console.WriteLine("    of Jemmy Francisco.");
            Console.WriteLine(" -----------------------------------------------------------");
            Console.WriteLine(" (C) 2026 JEM TOOLS · MIT LICENSE");
            Console.WriteLine(" -----------------------------------------------------------");
            Console.WriteLine("\n Press any key to return...");
            Console.ReadKey();
        }

        private static void PrintBanner()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("      _ ______ __  __   _______ ____   ____  _       _____ ");
            Console.WriteLine("     | |  ____|  \\/  | |__   __/ __ \\ / __ \\| |     / ____|");
            Console.WriteLine("     | | |__  | \\  / |    | | | |  | | |  | | |    | (___  ");
            Console.WriteLine(" _   | |  __| | |\\/| |    | | | |  | | |  | | |     \\___ \\ ");
            Console.WriteLine("| |__| | |____| |  | |    | | | |__| | |__| | |____ ____) |");
            Console.WriteLine(" \\____/|______|_|  |_|    |_|  \\____/ \\____/|______|_____/ ");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
