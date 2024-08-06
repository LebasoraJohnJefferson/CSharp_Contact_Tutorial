using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Maui.Models
{
    internal static class ContactRepository
    {
        public static List<Contact> _contacts = new List<Contact>() {
            new Contact { ContactId=1,Address="A", Phone="09882312311", Name="John Doe",Email="johnDoe@gmail.com"},
            new Contact { ContactId=2,Address="B", Phone="09882312312", Name="Jane Doe",Email="janeDoe@gmail.com"},
            new Contact { ContactId=3,Address="C", Phone="09882312313", Name="Tom Hanks",Email="tomHanks@gmail.com"},
            new Contact { ContactId=4,Address="D", Phone="09882312314", Name="Frank Liu",Email="frankLiu@gmail.com"}
        };


        public static List<Contact> GetContacts() => _contacts;

        public static Contact GetContactById(int contactId)
        {
            var contact = _contacts.FirstOrDefault(contact => contact.ContactId == contactId);
            if (contact != null) 
            {
                return new Contact
                {
                    ContactId = contact.ContactId,
                    Name = contact.Name,
                    Address = contact.Address,
                    Phone = contact.Phone,
                    Email = contact.Email,
                };
                
            }
            return null;
        }

        public static void UpdateContact(int contactId,Contact contact) 
        {
            if (contact.ContactId != contactId) return;

            var contactUpdate = _contacts.FirstOrDefault(contact => contact.ContactId == contactId);
            if (contactUpdate != null)
            {
                contactUpdate.Name = contact.Name;
                contactUpdate.Address = contact.Address;
                contactUpdate.Phone = contact.Phone;
                contactUpdate.Email = contact.Email;
            }

        }


        public static void AddContact(Contact newContact) 
        {
            var maxId = _contacts.Max(contact => contact.ContactId);
            newContact.ContactId = maxId+1;
            _contacts.Add(newContact);
        }

        public static void DeleteContact(int contactId)
        {
            var contact = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contact == null) return;
            _contacts.Remove(contact);
        }

        public static List<Contact> SearchContacts(string contactName)
        {
            var contacts = _contacts.Where(x => x.Name.StartsWith(contactName,StringComparison.OrdinalIgnoreCase))?.ToList();
            return contacts==null ? [] : contacts;
        }
    }
}
