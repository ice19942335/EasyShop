using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EasyShop.Interfaces.Files
{
    public interface IFileInsertDataHelper
    {
        Task<string> GetFileContent(string fileName, string fileType, string filePath);

        string ReplaceKeysWithData(string fileContent, Dictionary<string, string> data);

        Task<string> GetResult();
    }
}
