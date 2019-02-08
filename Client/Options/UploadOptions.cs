using System;
using System.IO;
using Client.Utils;
using CommandLine;

namespace Client.Options
{
    [Verb("upload", HelpText = "Uploads a file")]
    public class UploadOptions
    {
        [Option('f',"Filename", HelpText = "The file to be uploaded", Required = true)]
        public string FileName { get; set; }

        [Option('p', "Password", HelpText = "Password for the file", Required = false)]
        public string Password { get; set; } = PasswordGenerator.Generate();

        [Option('m', "Max downloads", HelpText = "The max nuber of times file can be downloaded", Required = false)]
        public int MaxDownloads { get; set; } = sizeof(long);

        [Option('t', "Time to download", HelpText = "Time limit for allowed downloads. Enter between 1 min and 60 min", Required = false)]
        public int TimeToDownload { get; set; } = 60;

        [Option('d', "Directory", HelpText = "Directory location of file to be uploaded", Required = false)]
        public string Directory { get; set; } = @"C:\Users\ftd-04\source\repos\dotnet-assessment-smart-share-LucasJenkins-master\Core\Dto\Downloads";

        public static string ExecuteUploadAndReturnExitCode(UploadOptions options)
        {
            var file = new FileInfo($"{options.Directory}+{options.FileName}");
            Console.WriteLine($"Uploading {file.FullName}");
            Console.WriteLine($"Password: {options.Password}");
            return Api.Upload(options) == true? "File was properly uploaded":"File was not uploaded properly";
        }
    }
}