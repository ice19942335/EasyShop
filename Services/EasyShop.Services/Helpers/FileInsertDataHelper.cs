using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using EasyShop.Interfaces.Files;
using Microsoft.AspNetCore.Hosting;

namespace EasyShop.Services.Files
{
    public class FileInsertDataHelper : IFileInsertDataHelper
    {
        private readonly IWebHostEnvironment _environment;
        private readonly string _filename;
        private readonly string _fileType;
        private readonly string _folderInRoot;
        private readonly Dictionary<string, string> _data;

        public FileInsertDataHelper(IWebHostEnvironment environment, string filename, string fileType, string folderInRoot, Dictionary<string, string> data)
        {
            _environment = environment;
            _filename = filename;
            _fileType = fileType;
            _folderInRoot = folderInRoot;
            _data = data;
        }

        public async Task<string> GetFileContent(string fileName, string fileType, string folderInRoot)
        {
            var fileFullPath = Path.Combine(_environment.WebRootPath, folderInRoot, $"{fileName}.{fileType}");

            using var reader = File.OpenText(fileFullPath);
            return await reader.ReadToEndAsync();
        }

        public string ReplaceKeysWithData(string fileContent, Dictionary<string, string> data)
        {
            try
            {
                foreach (var item in data)
                    fileContent = fileContent.Replace($"{{{{{item.Key}}}}}", item.Value);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return fileContent;
        }

        public async Task<string> GetResult()
        {
            string fileContent = await GetFileContent(_filename, _fileType, _folderInRoot);

            var fileContentReady = ReplaceKeysWithData(fileContent, _data);

            return fileContentReady;
        }
    }
}
