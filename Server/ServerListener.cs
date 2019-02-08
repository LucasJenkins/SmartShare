using Client;
using Core.Dto;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Server
{
    class ServerListener
    {
        public static readonly XmlSerializer requestSerializer = new XmlSerializer(typeof(FileObject));
        public static readonly XmlSerializer responseSerializer = new XmlSerializer(typeof(FileRequest));

        public static void Listen()
        {

            

            var address = IPAddress.Parse("127.0.0.1");
            var port = 3000;

            TcpListener listener = new TcpListener(address, port);
            listener.Start();

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Task.Run(() => HandleClient(client));
            }
            
        }

        public static void HandleClient (TcpClient client)
        {
            using (var stream = client.GetStream())
            {
                var textRequestDto = (FileRequest)requestSerializer.Deserialize(stream);
                Console.WriteLine(textRequestDto.UniqueFileName);

                var success = SaveTextToDb(textRequestDto);
                var statusResponseDto = new FileRequest {  = success };
                responseSerializer.Serialize(stream, statusResponseDto);
            }
        }
        public static bool SaveTextToDb(FileRequest requestObj)
        {
            FileRequest filerequest = mapTextRequestToTextEntity(requestObj);

            using (SmartShareContext context = new SmartShareContext())
            {
                try
                {
                    context.FilesIn.Add(filerequest);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    return false;
                }
            }
        }
        public static DownloadFile mapTextRequestToTextEntity(FileRequest fileRequest)
        {
            DownloadFile filedownload = new DownloadFile();
            
            if (filedownload.Password.Equals(fileRequest.Password))
            {
                filedownload.Id = fileRequest.Id;
                filedownload.FileByteArray = fileRequest.FileByteArray;
                filedownload.UniqueFileName = fileRequest.UniqueFileName;
                filedownload.TimeCreated = fileRequest.TimeCreated;
                filedownload.ExpirationTime = fileRequest.ExpirationTime - DateTime.UtcNow();
                filedownload.TotalDownloads = fileRequest.TotalDownloads;
                filedownload.Success = true;
                return filedownload;
            }
            fileRequest.Success = false;
            return filedownload;
        }
    }
}
