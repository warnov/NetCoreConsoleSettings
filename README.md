# NetCoreConsoleSettings
A sample to show how to handle configuration files in a C# .NET Core Console application.
This code is the sample related with [this original blog post](http://warnov.com/@coresettings) (in spanish)

An English version of the blog post have been reproduced here:

##.NET Core: How to use App Settings in a console application
One of the .NET Core assumptions is to use json-based application configuration files, rather than XML.
This is how the app.config or web.config disappear, as well as the traditional classes to read them.

Today .NET Core lets you create web applications and console applications. In both cases, the configuration file is the one that we define (in general we will call it `appsettings.json`).

To use this mechanism of reading settings of the application in the web the mechanism is well known from the `class Startup.cs`; But for console applications you have to customize some things.

The first thing to do is to add the configuration file per se, as it is not included by default in the .NET Core console application template.

In Visual Studio 2015 there is no direct way to do this, since when we choose add new item, it does not appear for example: "json file".

However I found this good extension:

[![Add new file extension](https://msdnshared.blob.core.windows.net/media/2017/01/image375.png)](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.AddNewFile)

That allows us to easily add any type of file to our solution.
So in the root of our console application we add for example the file `appsettings.json`.
The json template is loaded by default and we simply add the settings we require. For example:

    {
      "Setting1": "value1",
      "Setting2": 2,
      "Setting3": 3.00
    }

Once we have the file, just set up our project so that it knows we will use it.

First, we tell the system to include the settings file in the output. This is done within the "buildOptions" section. Adding the "copyToOutput" entry:

    "BuildOptions": {
        "EmitEntryPoint": true,
        "CopyToOutput": {
          "IncludeFiles": ["appsettings.json"]
        }
      },

Additionally we add the following dependency:

    "Microsoft.Extensions.Configuration.Json": "1.1.0"

Which includes the assembly required to load the configuration.

As is customary, save the file so that Visual Studio under the new added dependency brings the required assemblies from the network or cache the required assemblies and include them in the solution.

Finally, we write the code to access the settings. As a good practice I recommend creating a static class called ConfigHelper.cs or something like this:

The method returns an object from the IConfiguration family. In the end, it is enough to consult the required variable as an index:

public static class ConfigHelper
{
    public static IConfiguration Config
    {
	get
	{
	    var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
	    return builder.Build ();
	}
    }
}

And here and start to use the value of the setting, according to what you need:

using System;
using static NetCoreConsoleSettings.ConfigHelper;

namespace NetCoreConsoleSettings
{
	public class Program
	{
		public static void Main (string [] args)
	    {
		Console.WriteLine($"The value for setting1 is {Config["setting1"]} and for setting2 is {Config["setting2"]}");
		Console.ReadLine();
	    }
	}
}

Note that here we use the C # 6.0 feature through which we make using a static class to be able to directly access its members and properties; For example to `Config["nameSetting"]`.


