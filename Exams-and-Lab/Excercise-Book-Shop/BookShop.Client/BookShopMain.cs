using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Data;

namespace BookShop.Client
{
    class BookShopMain
    {
        static void Main()
        {
           

            using (var context = new BookShopContext())
            {
                var authors = context.Authors.Count();

                Console.WriteLine(authors);
            }
        }
    }
}