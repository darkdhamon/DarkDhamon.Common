namespace DarkDhamon.Common.IO.Abstract;

public interface IFileManager
{
    void BackupDirectory(string sourceDirectory, string? destinationDirectory = null);
    string[] GetFiles(string directoryPath, string filter = "*");
    void SetWorkingDirectory(string directoryPath);
    void DeleteDirectory(string directoryPath);
    void DeleteFile(string filePath);
}