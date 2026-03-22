//Requirements:problem-2
//1.Accept a folder path from the user.
//2. Display file name, file size, and creation date.
//3. Count and display the total number of files.


using System;
using System.IO;

namespace FileInfoExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter folder path: ");
                string folderPath = Console.ReadLine();

                // Check if directory exists
                if (!Directory.Exists(folderPath))
                {
                    Console.WriteLine("Invalid folder path!");
                    return;
                }

                // Get all files
                string[] files = Directory.GetFiles(folderPath);

                if (files.Length == 0)
                {
                    Console.WriteLine(" No files found in the folder.");
                    return;
                }

                Console.WriteLine("\n File Details:\n");

                int count = 0;

                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);

                    Console.WriteLine("File Name   : " + fi.Name);
                    Console.WriteLine("File Size   : " + fi.Length + " bytes");
                    Console.WriteLine("Created Date: " + fi.CreationTime);
                    Console.WriteLine("-----------------------------------");

                    count++;
                }

                Console.WriteLine("\n Total number of files: " + count);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access denied to the folder.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}