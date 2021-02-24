using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Class for storing values from HomeController model
namespace Bookstore.Models.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
