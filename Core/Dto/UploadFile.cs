using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Client
{
    [Serializable]
    class UploadFile
    {
        //Property for key or id
        [Key]
        [Column("id")]
        public int Id { get; set; }
        //Property for file name
        [Column("unique_file_name")]
        public string UniqueFileName { get; set; }
        //Property data contained in file
        [Column("file_byte_array")]
        public byte[] FileByteArray { get; set; }
        //Date generated at time file is created and becomes available for download
        [Column("time_created")]
        public DateTime TimeCreated { get; set; }
        //Date/time file becomes unavailable for download
        [Column("expiration_time")]
        public DateTime ExpirationTime { get; set; }
        //Maximum downloads of files allowed 
        [Column("max_download")]
        public int MaxDownloads { get; set; }
        //Current number of downloads conducted
        [Column("total_downloads")]
        public int TotalDownloads { get; set; }
        //Password required for download of file
        [Column("password")]
        public string Password { get; set; }
    }
}
