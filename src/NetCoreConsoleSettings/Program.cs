using System;
using static NetCoreConsoleSettings.ConfigHelper;

namespace NetCoreConsoleSettings
{
    public class Program
    {       
        public static void Main(string[] args)
        {
            Console.WriteLine($"The value for setting1 is {Config["setting1"]} and for setting2 is {Config["setting2"]}");
            Console.ReadLine();
        }
    }
}
