using BlazorInputFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Services
{
    public interface IFileUpload
    {
        Task UploadAsync(IFileListEntry file);
    }
}
