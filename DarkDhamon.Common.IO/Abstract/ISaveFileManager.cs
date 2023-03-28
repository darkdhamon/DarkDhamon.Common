using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkDhamon.Common.IO.Abstract
{
    public interface ISaveFileManager<TObject>:IFileManager where TObject : class, new()
    {
        void SaveObj(TObject saveObj, string filePath);
        Task SaveObjAsync(TObject saveObj, string filePath);
        TObject LoadObj(string filePath);
        Task<TObject> LoadObjAsync(string filePath);
    }
}
