using System.Diagnostics;
using DarkDhamon.Common.Extensions;
using DarkDhamon.Common.IO.Abstract;

namespace DarkDhamon.Common.IO;

public class FileManager : IFileManager
{
    protected string WorkingDirectory { get; set; } = Directory.GetCurrentDirectory();
    
    public void BackupDirectory(string sourceDirectory, string? destinationDirectory = null)
    {
        if (destinationDirectory.IsNullOrWhitespace())
        {
            // If Destination Directory is not supplied Create Backup in Parent Folder, If Parent Folder is null Create backup in Application Folder.
            destinationDirectory =
                $"{Directory.GetParent(sourceDirectory)?.FullName ?? WorkingDirectory}\\Backup-{DateTime.Now:yyyyMMddHHmmss}";
        }

        Debug.Assert(destinationDirectory != null, nameof(destinationDirectory) + " != null");
        Directory.CreateDirectory(destinationDirectory);

        // Get information about the source directory
        var dir = new DirectoryInfo(sourceDirectory);

        // Check if the source directory exists
        if (!dir.Exists)
            throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

        // Cache directories before we start copying
        DirectoryInfo[] dirs = dir.GetDirectories();

        // Create the destination directory
        Directory.CreateDirectory(destinationDirectory);

        // Get the files in the source directory and copy to the destination directory
        foreach (FileInfo file in dir.GetFiles())
        {
            string targetFilePath = Path.Combine(destinationDirectory, file.Name);
            file.CopyTo(targetFilePath);
        }

        // If recursive and copying subdirectories, recursively call this method
        foreach (DirectoryInfo subDir in dirs)
        {
            string newDestinationDir = Path.Combine(destinationDirectory, subDir.Name);
            BackupDirectory(subDir.FullName, newDestinationDir);
        }

    }

    public string[] GetFiles(string directoryPath, string filter = "*")
    {
        return Directory.GetFiles(directoryPath, filter);
    }

    public void SetWorkingDirectory(string directoryPath)
    {
        WorkingDirectory = directoryPath;
    }

    public void DeleteDirectory(string directoryPath)
    {
        Directory.Delete(directoryPath);
    }

    public void DeleteFile(string filePath)
    {
        File.Delete(filePath);
    }
}