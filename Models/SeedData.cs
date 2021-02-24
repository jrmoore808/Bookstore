using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
//Creates seed data in the first migration if no data exists in the database yet
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            BooksDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BooksDbContext>();
        
            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if(!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book
                    {
                        Title = "Les Miserables",
                        AuthorFirst = "Victor",
                        AuthorLast = "Hugo",
                        Publisher = "Signet",
                        ISBN = "9780451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95,
                        Pages = 1488
                    },
                    new Book
                    {
                        Title = "Team of Rivals",
                        AuthorFirst = "Doris Kearns",
                        AuthorLast = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "9780743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58,
                        Pages = 944
                    },
                    new Book
                    {
                        Title = "The Snowball",
                        AuthorFirst = "Alice",
                        AuthorLast = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "9780553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54,
                        Pages = 832
                    },
                    new Book
                    {
                        Title = "American Ulysses",
                        AuthorFirst = "Ronald C.",
                        AuthorLast = "White",
                        Publisher = "Random House",
                        ISBN = "9780812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 11.61,
                        Pages = 864
                    },
                    new Book
                    {
                        Title = "Unbroken",
                        AuthorFirst = "Laura",
                        AuthorLast = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "9780812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 13.33,
                        Pages = 528
                    },
                    new Book
                    {
                        Title = "The Great Train Robbery",
                        AuthorFirst = "Michael",
                        AuthorLast = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "9780804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 15.95,
                        Pages = 288
                    },
                    new Book
                    {
                        Title = "Deep Work",
                        AuthorFirst = "Cal",
                        AuthorLast = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "9781455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 14.99,
                        Pages = 304
                    },
                    new Book
                    {
                        Title = "It's Your Ship",
                        AuthorFirst = "Michael",
                        AuthorLast = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "9781455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 21.66,
                        Pages = 240
                    },
                    new Book
                    {
                        Title = "The Virgin Way",
                        AuthorFirst = "Richard",
                        AuthorLast = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "9781591847984",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = 29.16,
                        Pages = 400
                    },
                    new Book
                    {
                        Title = "Sycamore Row",
                        AuthorFirst = "John",
                        AuthorLast = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "9780553393613",
                        Classification = "Fiction",
                        Category = "Thriller",
                        Price = 15.03,
                        Pages = 642
                    },
                    new Book
                    {
                        Title = "Of Mice and Men",
                        AuthorFirst = "John",
                        AuthorLast = "Steinback",
                        Publisher = "Pascal Covici",
                        ISBN = "9780340928653",
                        Classification = "Fiction",
                        Category = "Historical",
                        Price = 14.99,
                        Pages = 107
                    },
                    new Book
                    {
                        Title = "The Way of Kings",
                        AuthorFirst = "Brandon",
                        AuthorLast = "Sanderson",
                        Publisher = "Tor Books",
                        ISBN = "9780765326355",
                        Classification = "Fiction",
                        Category = "Thriller",
                        Price = 29.99,
                        Pages = 1007
                    },
                    new Book
                    {
                        Title = "The Lion, the Witch and the Wardrobe",
                        AuthorFirst = "C. S.",
                        AuthorLast = "Lewis",
                        Publisher = "HarperCollins",
                        ISBN = "9780060276362",
                        Classification = "Fiction",
                        Category = "Religious Fiction",
                        Price = 19.99,
                        Pages = 208
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
