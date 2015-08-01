using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.Data;

namespace Phonebook.Client
{
    class PhonebookClient
    {
        static void Main()
        {
            using (var context = new PhonebookContext())
            {
                var contacts = context.Contacts
                    .Select(c => new
                    {
                        ContactName = c.Name,
                        ContactEmails = c.Emails.Select(e => e.EmailAddress),
                        ContactPhones = c.Phones.Select(p => p.PhoneNumber),
                    })
                    .ToList();

                foreach (var contact in contacts)
                {
                    Console.WriteLine(contact.ContactName);
                    Console.WriteLine("Emails: " + string.Join(", ", contact.ContactEmails));
                    Console.WriteLine("Phones: " + string.Join(", ", contact.ContactPhones));
                    Console.WriteLine();
                }
            }
        }
    }
}