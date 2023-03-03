using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    public interface BookstoreProjectRepository
    {
        IQueryable<Book> Books { get; }
    }
}
