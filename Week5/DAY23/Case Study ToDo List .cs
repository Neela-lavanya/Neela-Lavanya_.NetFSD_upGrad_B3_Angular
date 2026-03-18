using System;
using System.Collections.Generic;

namespace ConsoleApp11
{
    class TodoApp
    {
        static void Main()
        {
            List<string> tasks = new List<string>();
            int choice;

            do
            {
                Console.WriteLine("\nTo-Do List Manager");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Remove Task");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                // Validate menu input
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        // Add Task
                        Console.Write("Enter task: ");
                        string task = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(task))
                        {
                            tasks.Add(task);
                            Console.WriteLine("Task added!");
                        }
                        else
                        {
                            Console.WriteLine("Task cannot be empty!");
                        }
                        break;

                    case 2:
                        // View Tasks
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("Task list is empty.");
                        }
                        else
                        {
                            Console.WriteLine("Tasks:");
                            for (int i = 0; i < tasks.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {tasks[i]}");
                            }
                        }
                        break;

                    case 3:
                        // Remove Task
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("No tasks to remove.");
                            break;
                        }

                        Console.Write("Enter task number to remove: ");
                        int taskNumber;

                        if (!int.TryParse(Console.ReadLine(), out taskNumber))
                        {
                            Console.WriteLine("Invalid input! Enter a valid number.");
                        }
                        else if (taskNumber < 1 || taskNumber > tasks.Count)
                        {
                            Console.WriteLine("Invalid task number.");
                        }
                        else
                        {
                            string removedTask = tasks[taskNumber - 1];
                            tasks.RemoveAt(taskNumber - 1);
                            Console.WriteLine("Removed: " + removedTask);
                        }
                        break;

                    case 4:
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please select 1-4.");
                        break;
                }

            } while (choice != 4);
        }
    }
}