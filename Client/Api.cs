using Client.Utils;
using System;
using Client.Options;
using System.Xml.Serialization;
using System.Net.Sockets;
using Core;
using Core.Dto;
using System.IO;

namespace Client
{
    public class Api
    {
        private const string HOST = "localhost";
        private const int PORT = 3000;
        
        private Api()
        {
            
        }

        /// <summary>
        /// Send download request
        /// </summary>
        /// <param name="">TODO</param>
        /// <returns>true if request was successful and false if unsuccessful</returns>
        public static bool Download(string[] args)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Send upload request
        /// </summary>
        /// <param name="">TODO</param>
        /// <returns>true if request was successful and false if unsuccessful</returns>
        public static bool Upload(UploadOptions option)
        {   
                try
                {
                    //Creating container for user passed in information
                    FileObject fileObject = new FileObject();
                    fileObject.UniqueFileName = option.FileName;
                    fileObject.Password = option.Password;
                    fileObject.MaxDownloads = option.MaxDownloads;
                    fileObject.MaxTime = option.TimeToDownload;
                    fileObject.FileByteArray = File.ReadAllBytes(option.Directory);

                    //Creates serialization objects
                    XmlSerializer requestSerializer = new XmlSerializer(typeof(FileObject));
                    XmlSerializer responseSerializer = new XmlSerializer(typeof(FileObject));
                    //Creates new client connection with 
                    TcpClient tcpClient = new TcpClient(HOST, PORT);

                    using (var stream = tcpClient.GetStream())
                    {
                        requestSerializer.Serialize(stream, fileObject);

                        // Hacky solution to read blocking
                        tcpClient.Client.Shutdown(SocketShutdown.Send);

                        var statusResponse = (FileObject)responseSerializer.Deserialize(stream);
                        Console.WriteLine(statusResponse. ? "Success" : "Failure");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
            return true;
            
            //--Take input from commandLine

            /*
             * --Assign data to a FileObject (if no password given in input use 
             *-- PasswordGenerator to assign, then return to user)
            */
            /*
            
         * --Make connection to server, serialize object, send object on request
         * 
         */
        }
    }
}