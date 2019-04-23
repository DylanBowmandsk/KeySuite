using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Scripting.Hosting;
using IronPython.Runtime;
using IronPython.Hosting;

namespace KeySuite
{
    class PythonUtils
    {
        private static string[] modules = new string[]{
                "C:\\Program Files (x86)\\Microsoft Visual Studio 14.0\\Common7\\IDE\\Extensions\\Microsoft\\Python Tools for Visual Studio\\2.2",
                "C:\\Users\\SlotR\\source\\repos\\KeySuite\\packages\\IronPython.2.7.9",
           " C:\\Users\\SlotR\\source\\repos\\KeySuite\\packages\\IronPython.2.7.9\\lib\\IronPython.Modules.dll"

            };

        public static string getSteamPrice(string url)
        {
            ScriptRuntimeSetup setup = Python.CreateRuntimeSetup(null);
            ScriptRuntime runtime = new ScriptRuntime(setup);
            ScriptEngine engine = Python.GetEngine(runtime);
            engine.SetSearchPaths(modules);
            ScriptSource source = engine.CreateScriptSourceFromFile("C:\\Users\\SlotR\\source\\repos\\KeySuite\\KeySuite\\steam_webscraper.py");
            ScriptScope scope = engine.CreateScope();
            engine.GetSysModule().SetVariable("argv[1]", url);
            source.Execute(scope);
            string price = scope.GetVariable("steam_price");
            return price;
        }
    }
}
