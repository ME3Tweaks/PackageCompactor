using ME3Explorer.Packages;
using System;
using System.Diagnostics;
using System.IO;

namespace PackageCompactor
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.Error.WriteLine("Error: This program only supports a single command line argument: Path to ME1/ME2/ME3 package file.");
                Environment.Exit(1);
                return;
            }

            if (!File.Exists(args[0]))
            {
                Console.Error.WriteLine("Error: Specified file does not exist.");
                Environment.Exit(1);
                return;
            }
            ME3ExplorerMinified.DLL.Startup();
            try
            {
                Console.WriteLine("Opening package: " + args[0]);
                var package = MEPackageHandler.OpenMEPackage(args[0]);
                Console.WriteLine("Compacting package: " + args[0]);
                package.save();
                Console.WriteLine("Compacted package: " + args[0]);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error: " + e.Message);
                Console.ReadKey();
                Environment.Exit(2);
                return;
            }
        }
    }
}
