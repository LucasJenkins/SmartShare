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
        public static bool Download(DownloadOptions option)
        {
            //Creating container for user passed in information
            FileRequest statusResponse;
            FileObject fileObject = new FileObject();
            try
            {
                //Assigns all information need passed in from command line
                fileObject.UniqueFileName = option.FileName;
                fileObject.Password = option.Password;

                //Creates serialization objects
                XmlSerializer requestSerializer = new XmlSerializer(typeof(FileObject));
                XmlSerializer responseSerializer = new XmlSerializer(typeof(FileObject));

                //Creates new client connection with 
                TcpClient tcpClient = new TcpClient(HOST, PORT);

                //Executes request and listens for response
                using (var stream = tcpClient.GetStream())
                {
                    //Serializing information to be sent to Server
                    requestSerializer.Serialize(stream, fileObject);
                    // Hacky solution to read blocking
                    tcpClient.Client.Shutdown(SocketShutdown.Send);
                    //Deserializes returning information and checks success property
                    statusResponse = (FileRequest)responseSerializer.Deserialize(stream);
                    if(statusResponse.UniqueFileName.Equals)
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            return statusResponse.Success;
        }

        /// <summary>
        /// Send upload request
        /// </summary>
        /// <param name="">TODO</param>
        /// <returns>true if request was successful and false if unsuccessful</returns>
        /*public static bool Upload(UploadOptions option)
        {
            //Creating container for user passed in information
            FileRequest statusResponse;
            FileObject fileObject = new FileObject();
            try
            {
                
                //Assigns all information need passed in from command line
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
                    //Serializing information to be sent to Server
                    requestSerializer.Serialize(stream, fileObject);
                    // Hacky solution to read blocking
                    tcpClient.Client.Shutdown(SocketShutdown.Send);
                    //Deserializes returning information and checks success property
                    statusResponse = (FileRequest)responseSerializer.Deserialize(stream);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            return statusResponse.Success;
        }*/
        /*public static string View(ViewOption option)
        {
            FileRequest statusResponse;
            FileObject fileObject = new FileObject();
            try
            {
                //Creating container for user passed in information
                
                //Assigns all information need passed in from command line
                fileObject.UniqueFileName = option.FileName;
                fileObject.Password = option.Password;
               
                //Creates serialization objects
                XmlSerializer requestSerializer = new XmlSerializer(typeof(FileObject));
                XmlSerializer responseSerializer = new XmlSerializer(typeof(FileObject));

                //Creates new client connection with 
                TcpClient tcpClient = new TcpClient(HOST, PORT);


                using (var stream = tcpClient.GetStream())
                {
                    //Serializing information to be sent to Server
                    requestSerializer.Serialize(stream, fileObject);
                    // Hacky solution to read blocking
                    tcpClient.Client.Shutdown(SocketShutdown.Send);
                    //Deserializes returning information and checks success property
                    statusResponse = (FileRequest)responseSerializer.Deserialize(stream);
                }
             
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            return $"File: {statusResponse.UniqueFileName} \n" +
                      $"Time Created: {statusResponse.TimeCreated}\n" +
                      $"Remaining Download: {statusResponse.MaxDownloads - statusResponse.TotalDownloads}\n";
        }
        */
    }
}