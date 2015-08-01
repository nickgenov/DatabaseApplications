using System;
using Phonebook.Data;
using System.IO;
using Newtonsoft.Json.Linq;
using Phonebook.Models;

namespace Import_Contacts_JSON
{
    class ImportContactsJson
    {
        static void Main()
        {
            var context = new PhonebookContext();
          
            string contactsJson = File.ReadAllText("../../contacts.json");

            var contacts = JArray.Parse(contactsJson);
            foreach (JToken contact in contacts)
            {
                Contact dbContact = new Contact();

                if (contact["name"] == null)
                {
                    Console.WriteLine("Error: name is required");
                    continue;
                }
                    
                dbContact.Name = contact["name"].ToString();

                if (contact["phones"] != null)
                {
                    foreach (var phone in contact["phones"])
                    {
                        dbContact.Phones.Add(new Phone(){PhoneNumber = phone.ToString()});
                    }
                }
                if (contact["emails"] != null)
                {
                    foreach (var email in contact["emails"])
                    {
                        dbContact.Emails.Add(new Email(){EmailAddress = email.ToString()});
                    }
                }

                if (contact["position"] != null)
                {
                    dbContact.Position = contact["position"].ToString();
                }
                if (contact["company"] != null)
                {
                    dbContact.Company = contact["company"].ToString();
                }
                if (contact["url"] != null)
                {
                    dbContact.Url = contact["url"].ToString();
                }
                if (contact["notes"] != null)
                {
                    dbContact.Notes = contact["notes"].ToString();
                }

                context.Contacts.Add(dbContact);
                context.SaveChanges();
                Console.WriteLine("Contact {0} imported", dbContact.Name);
            }
        }
    }
}