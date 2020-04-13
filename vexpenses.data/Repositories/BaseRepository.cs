using System;
using vexpenses.data.Context;

namespace vexpenses.data.Repositories
{
    public class BaseRepository: IDisposable
    {
        protected readonly VExpensesContext _context;
        public BaseRepository(VExpensesContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            if (this._context != null)
            {
                this._context.Dispose();
            }
        }
    }
}
