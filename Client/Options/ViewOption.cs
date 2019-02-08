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
        [Option('f', "filename", HelpText = "Unique name of file to be downloaded", Required = true)]
        public string FileName { get; set; }

        [Option('p', "password", HelpText = "Password used to access file", Required = true)]
        public string Password { get; set; }


        public static void ExecuteViewOptionsAndReturnExitCode(ViewOption options)
        {
            
            Console.WriteLine($"Uploading {file.FullName}");
            Console.WriteLine($"Password: {options.Password}");
            return Api.View(options);

        }
    }
}
