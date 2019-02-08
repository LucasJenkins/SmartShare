using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Options
{
    [Verb("view", HelpText = "Retrieves a file information table")]
    public class ViewOption
    {
        [Value(0, MetaName = "filename", HelpText = "Unique name of file to be downloaded", Required = true)]
        public string FileName { get; set; }

        [Value(1, MetaName = "password", HelpText = "Password used to access file", Required = true)]
        public string Password { get; set; }

        public static int ExecuteViewOptionsAndReturnExitCode(ViewOption options)
        {
            // TODO
            Console.WriteLine("Attempting to gather data");
            return 0;
        }
    }
}
