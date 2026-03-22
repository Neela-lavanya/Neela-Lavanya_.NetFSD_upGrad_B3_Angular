
//Problem 4 – Level 2
//Scenario:
//A development team wants to analyze all folders inside a project directory to understand the project structure.
//Requirements:
//1.Accept a root directory path.
//2. Display all subdirectories inside the root folder.
//3. Show the number of files present in each directory



using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // 1. Accept root directory path
            Console.Write("Enter Root Directory Path: ");
            string path = Console.ReadLine();

            // Check if directory exists
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Directory does not exist!");
                return;
            }

            // Create DirectoryInfo object
            DirectoryInfo root = new DirectoryInfo(path);

            Console.WriteLine("\n===== Directory Analysis =====");

            // 2. Get all subdirectories
            DirectoryInfo[] directories = root.GetDirectories();

            // 3. Loop through each directory
            foreach (DirectoryInfo dir in directories)
            {
                try
                {
                    // Get files in each directory
                    FileInfo[] files = dir.GetFiles();

                    // Display folder name and file count
                    Console.WriteLine($"Folder: {dir.Name}");
                    Console.WriteLine($"Number of Files: {files.Length}");
                    Console.WriteLine("--------------------------------");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine($"Folder: {dir.Name}");
                    Console.WriteLine("Access Denied!");
                    Console.WriteLine("--------------------------------");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}