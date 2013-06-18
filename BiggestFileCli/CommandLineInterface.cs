using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using BiggestFiles;
using NDesk.Options;

namespace BiggestFileCli
{
    class CommandLineInterface
    {
        private readonly TextWriter _out = Console.Out;

        private Boolean _startWithDebuggerAttached;
        private Boolean _showHelpAndExit;
        private String _startingPath = ".";// local Path is default
        private readonly OptionSet _optionSet;
        private readonly IEnumerable<String> _args;

        private static String ProgramName
        {
            get { return Environment.CommandLine; }
        }

        private CommandLineInterface(IEnumerable<String> args)
        {
            _args = args;
            _optionSet = new OptionSet
            {
                {"h|help|?|usage", "show this usage message and exit", v => _showHelpAndExit = true},
                {"p|path=", "starting path", v => _startingPath = v},
                {"d|debugger", "start with debugger attached", v => _startWithDebuggerAttached = true},
            };
        }

        private void Start()
        {
            try
            {
                _optionSet.Parse(_args);
            }
            catch (OptionException optionException)
            {
                _out.WriteLine(ProgramName + ": ");
                _out.WriteLine(optionException.Message);
                _out.WriteLine("Try `" + ProgramName + " --help' for more information.");

                return;
            }

            if(_startWithDebuggerAttached) Debugger.Break();
            if(_showHelpAndExit)
            {
                ShowHelp();
                return;
            }
            
            // Main Functionality
            var finder = new Finder(_startingPath);
            foreach (var line in finder.FindRecursivly())
            {
                _out.WriteLine(line);
            }
        }

        private void ShowHelp()
        {
            _out.WriteLine("Usage: " + ProgramName + " [OPTIONS]* ");
        }


        static void Main(String[] args)
        {
            var program = new CommandLineInterface(args);
            program.Start();
        }
    }
}
