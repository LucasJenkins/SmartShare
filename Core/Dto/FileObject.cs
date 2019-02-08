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
        //Status response ind
    }
}
