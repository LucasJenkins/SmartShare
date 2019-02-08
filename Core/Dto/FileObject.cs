using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Core.Dto
{
    [Serializable]//Declaring that following entity is serializable
    public class FileObject
    {
        //Property for key or id
        public int Id { get; set; }
        //Property for file name
        public string UniqueFileName { get; set; }
        //Property data contained in file
        public byte[] FileByteArray { get; set; }
        //Date generated at time file is created and becomes available for download
        public DateTime TimeCreated { get; set; }
        //Date/time file becomes unavailable for download
        public DateTime ExpirationTime { get; set; }
        //Maximum downloads of files allowed 
        public int MaxDownloads { get; set; }
        //Current number of downloads conducted
        public int TotalDownloads { get; set; }
        //Password required for download of file
        public string Password { get; set; }
        //Maximum time in minutes to download files. 
        public int MaxTime { get; set; }
        //Bool to indicate success of download
        public bool Success { get; set; }
        //Hold list of Items returned from database
        public List<FileObject> Table { get; set; }

        public override bool Equals(object obj)
        {
            var @object = obj as FileObject;
            return @object != null &&
                   UniqueFileName == @object.UniqueFileName &&
                   EqualityComparer<byte[]>.Default.Equals(FileByteArray, @object.FileByteArray) &&
                   TimeCreated == @object.TimeCreated &&
                   ExpirationTime == @object.ExpirationTime &&
                   MaxDownloads == @object.MaxDownloads &&
                   TotalDownloads == @object.TotalDownloads &&
                   Password == @object.Password;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(UniqueFileName, FileByteArray, TimeCreated, ExpirationTime, MaxDownloads, TotalDownloads, Password);
        }
    }
}
