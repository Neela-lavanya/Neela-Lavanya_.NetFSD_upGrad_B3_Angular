using System;
using WebApplication12.Models;
using WebApplication12.Repositories;
using WebApplication12.Services;

class Program
{
    static void Main()
    {
        IContactRepository repo = new ContactRepository();
        IContactService service = new ContactService(repo);

        service.AddContact(new Contact
        {
            Id = 1,
            Name = "Anji",
            Email = "anji@gmail.com",
            Phone = "9999999999"
        });

        service.AddContact(new Contact
        {
            Id = 2,
            Name = "Ravi",
            Email = "ravi@gmail.com",
            Phone = "8888888888"
        });

        service.UpdateContact(new Contact
        {
            Id = 1,
            Name = "Anji Updated",
            Email = "new@gmail.com",
            Phone = "7777777777"
        });

        Console.WriteLine("Contacts:");
        foreach (var c in service.GetAllContacts())
        {
            Console.WriteLine($"{c.Id} | {c.Name} | {c.Email} | {c.Phone}");
        }

        service.DeleteContact(2);

        Console.WriteLine("\nAfter Delete:");
        foreach (var c in service.GetAllContacts())
        {
            Console.WriteLine($"{c.Id} | {c.Name} | {c.Email} | {c.Phone}");
        }
    }
}