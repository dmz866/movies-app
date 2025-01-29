namespace MoviesApp.Services
{
    public abstract class BaseService<DbContext>
    {
        protected DbContext _context { get; private set; }

        internal BaseService(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            _context = context;
        }
    }
}
