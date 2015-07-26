using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogAn;

namespace ArtOfUnitTesting
{
    class MainConsole
    {
        static void Main(string[] args)
        {
            LogAnalyzer logAnalyzer = new LogAnalyzer();
            if (logAnalyzer.IsValidLogFileName("hello"))
            {
                System.Console.WriteLine("Valid.");
            }
            else
            {
                System.Console.WriteLine("Invalid.");
            }
            System.Console.ReadKey();
        }
    }
}
