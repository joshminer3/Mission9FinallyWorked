using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mission9.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        public BookstoreContext context;

        public EFOrderRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Buy> buys => context.Buys.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void Saveorder(Buy buy)
        {
            context.AttachRange(buy.Lines.Select(x => x.Book));

            if (buy.BuyId == 0)
            {
                context.Buys.Add(buy);
            }

            context.SaveChanges();
        }
    }
}
