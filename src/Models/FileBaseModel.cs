using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace FileTidyBase.Models
{
    public class FileBaseModel
    {
        public FileBaseModel(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
                throw new Exception("File does not exist");
            this.FilePath = filePath;
            _fileInfo = new FileInfo(this.FilePath);
        }

        private string _fileName = "";
        private string _fileContentHashValue = "";
        private string _fileSize = "";
        private string _fileType = "";
        private string _filePath = "";

        private FileInfo _fileInfo;

        public string FileName
        {
            get { return _fileName; }
        }

        public string FileContentHashValue
        {
            get { return _fileContentHashValue; }
        }

        public string FileType
        {
            get { return _fileType; }
        }

        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        public string FileSize
        {
            get { return _fileSize; }
        }


        public void DeleteFile()
        {
            File.Delete(this.FilePath);
        }

        private async Task GetFileContentHash()
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(this.FilePath))
                {
                    byte[] contentHashBytes = await md5.ComputeHashAsync(stream);
                    this._fileContentHashValue = BitConverter.ToString(contentHashBytes).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        private void GetFileSize()
        {
            this._fileSize = _fileInfo.Length.ToString();
        }

        private void GetFileType()
        {
            this._fileType = _fileInfo.Extension;
        }

        private void GetFileName()
        {
            this._fileName = _fileInfo.Name;
        }

        public async Task GetFileInfo()
        {
            GetFileName();
            GetFileType();
            GetFileSize();
            await GetFileContentHash();
        }
    }
}
