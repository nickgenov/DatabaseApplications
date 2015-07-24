using System;

namespace Transactions_Example
{
    class Transactions
    {
        static void Main()
        {
            using (var context = new SoftUniEntities())
            {
                AddTownAddressEvent(context);

                //unique constraint in the DB causes exception:
                AddTownAddressEvent(context);
            }
        }

        private static void AddTownAddressEvent(SoftUniEntities context)
        {
            Console.WriteLine("Adding town, address and event...");
            var town = new Town()
            {
                Name = "Borovets"
            };
            context.Towns.Add(town);

            var address = new Address()
            {
                AddressText = "Rila 12",
                Town = town
            };
            context.Addresses.Add(address);

            var conf = new Event()
            {
                Name = "SoftUni Conf 2015",
                Date = new DateTime(2015, 9, 15),
                Address = address,
            };
            context.Events.Add(conf);

            context.SaveChanges();
            Console.WriteLine("done");
        }
    }
}