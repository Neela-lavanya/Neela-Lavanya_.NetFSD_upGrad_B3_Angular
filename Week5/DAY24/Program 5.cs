using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("===== Disk Storage Monitor =====\n");

            // Retrieve all system drives
            DriveInfo[] drives = DriveInfo.GetDrives();

            // Loop through each drive
            foreach (DriveInfo drive in drives)
            {
                try
                {
                    // Check if drive is ready
                    if (drive.IsReady)
                    {
                        // Get drive details
                        string name = drive.Name;
                        string type = drive.DriveType.ToString();
                        long totalSize = drive.TotalSize;
                        long freeSpace = drive.AvailableFreeSpace;

                        // Calculate free space percentage
                        double freePercent = (double)freeSpace / totalSize * 100;

                        // Display information
                        Console.WriteLine($"Drive Name: {name}");
                        Console.WriteLine($"Drive Type: {type}");
                        Console.WriteLine($"Total Size: {totalSize / (1024 * 1024 * 1024)} GB");
                        Console.WriteLine($"Free Space: {freeSpace / (1024 * 1024 * 1024)} GB");

                        // Warning if space is low
                        if (freePercent < 15)
                        {
                            Console.WriteLine("⚠ Warning: Low Disk Space!");
                        }

                        Console.WriteLine("----------------------------------");
                    }
                    else
                    {
                        Console.WriteLine($"Drive Name: {drive.Name}");
                        Console.WriteLine("Drive is not ready.");
                        Console.WriteLine("----------------------------------");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error accessing drive {drive.Name}: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
    }
}