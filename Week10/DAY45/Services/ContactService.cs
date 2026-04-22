using System;
using System.Collections.Generic;
using WebApplication12.Models;
using WebApplication12.Repositories;

namespace WebApplication12.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;

        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public void AddContact(Contact contact)
        {
            Validate(contact);
            _repository.Add(contact);
        }

        public void UpdateContact(Contact contact)
        {
            Validate(contact);
            _repository.Update(contact);
        }

        public void DeleteContact(int id)
        {
            _repository.Delete(id);
        }

        public List<Contact> GetAllContacts()
        {
            return _repository.GetAll();
        }

        private void Validate(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            if (string.IsNullOrWhiteSpace(contact.Name))
                throw new Exception("Name required");

            if (string.IsNullOrWhiteSpace(contact.Email))
                throw new Exception("Email required");

            if (string.IsNullOrWhiteSpace(contact.Phone))
                throw new Exception("Phone required");
        }
    }
}