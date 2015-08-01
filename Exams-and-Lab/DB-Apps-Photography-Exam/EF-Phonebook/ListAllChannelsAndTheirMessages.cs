using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EF_Phonebook.Model;

namespace EF_Phonebook
{
    class ListAllChannelsAndTheirMessages
    {
        static void Main()
        {
            var context = new PhonebookModel();

            var channels = context.Channels
              .Select(x => new
              {
                  x.Name,
                  ChannelMessages = x.ChannelMessages.Select(c => new
                  {
                      c.Content,
                      c.DateTime,
                      c.User.Username
                  })
              });

            //foreach (var channel in channelsMessages)
            //{
            //    Console.WriteLine("{0}", channel.ChannelName);
            //    Console.WriteLine("-- Messages: --");

            //    foreach (var message in channel.ChannelMessages)
            //    {
            //        Console.WriteLine("Content: {0}, DateTime: {1}, User: {2}", message.Content, message.DateTime, message.User.Username);
            //    }
            //}
        }
    }
}