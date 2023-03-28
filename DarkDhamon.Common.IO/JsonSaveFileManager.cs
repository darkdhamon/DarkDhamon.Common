using DarkDhamon.Common.IO.Abstract;
using Newtonsoft.Json;

namespace DarkDhamon.Common.IO;

public class JsonSaveFileManager<TObject>:FileManager, ISaveFileManager<TObject> where TObject : class, new()
{
    public void SaveObj(TObject saveObj, string filePath)
    {
        File.WriteAllText(filePath, JsonConvert.SerializeObject(saveObj));
    }

    public async Task SaveObjAsync(TObject saveObj, string filePath)
    {
        await File.WriteAllTextAsync(filePath, JsonConvert.SerializeObject(saveObj));
    }
        
    public TObject LoadObj(string filePath)
    {
        return JsonConvert.DeserializeObject<TObject>(File.ReadAllText(filePath));
    }

    public async Task<TObject> LoadObjAsync(string filePath)
    {
        return JsonConvert.DeserializeObject<TObject>(await File.ReadAllTextAsync(filePath));
    }
}