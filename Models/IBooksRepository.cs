using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public interface IBooksRepository
    {
        IQueryable<Book> Books { get; }
    }
}
