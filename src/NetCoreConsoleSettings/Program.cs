using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace NetCoreConsoleSettings
{
    public class Program
    {
        static IConfiguration _config = ConfigHelper.Config;
        public static void Main(string[] args)
        {
            Console.WriteLine($"The value for setting1 is {_config["setting1"]} and for setting2 is {_config["setting2"]}");
            Console.ReadLine();
        }
    }
}
