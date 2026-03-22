using System;
using System.IO;
using System.Text;

namespace FileStreamExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "log.txt";

            try
            {
                while (true)
                {
                    Console.Write("Enter your message (type 'exit' to stop): ");
                    string message = Console.ReadLine();

                    if (message.ToLower() == "exit")
                        break;

                    // Convert message to byte array
                    byte[] data = Encoding.UTF8.GetBytes(message + Environment.NewLine);

                    // FileStream for appending data
                    using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                    {
                        fs.Write(data, 0, data.Length);
                    }

                    Console.WriteLine("✅ Message saved successfully!\n");
                }

                Console.WriteLine("Program ended.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("❌ Error: Access denied to the file.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("❌ File error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Unexpected error: " + ex.Message);
            }
        }
    }
}